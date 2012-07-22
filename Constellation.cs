using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    class Constellation
    {
        private static Process matlabProcess = null;
        //public static string cmd = @"C:\PTP\logic_004\logic.exe";
        public static string constellationExecutable = @"C:\PTP\logic_007\logic.exe";
        // See PhyConstellationData for dataFileFolder
        public static string folderRoot = @"C:\PTP\";

        private int Channel_estimation_graph_enable = 0;
        public static bool PLLDebug = true;
        public static int persistence = 0;
        private PhyConstellationData[] constellations;
        public static int[] FFTsizes = { 256, 512 };
        public static int selectedFFT = 0; // 256
        public static bool New_Matlab = true;
        // TODO: Re-enable this, if you want automatic FFT size selection,
        // based on current modulation.  But, the design wasn't complete - when
        // the MCS changes, no code in here was smart enough to stop/restart matlab.
        // Then again, the best way to handle rapidly changing FFT size is to put it
        // in the data files, not stop/restart logic.exe.
        public int constellationMode = 256;  //  4, 16, 64, 256
        
        public enum TRIGGER_RETURN_CODE
        {
            OK,
            SOC_UNRESPONSIVE,
            EXECUTABLE_FAILURE,
            FILE_WRITE_FAILURE
        };

        public bool isRunning { get {
            if (matlabProcess != null && (!matlabProcess .HasExited)) {
                return true;
            }
            return false;
        }}

        public Constellation()
        {
            constellations = new PhyConstellationData[4];
            // Order is important, for logic.exe command line expects 1After, 2After, 1Before, 2Before
            constellations[0] = new PhyConstellationData(PhyConstellationData.Antenna.ANT1, PhyConstellationData.EqPosition.AFTER,PLLDebug);
            constellations[1] = new PhyConstellationData(PhyConstellationData.Antenna.ANT2, PhyConstellationData.EqPosition.AFTER, PLLDebug);
            constellations[2] = new PhyConstellationData(PhyConstellationData.Antenna.ANT1, PhyConstellationData.EqPosition.BEFORE, PLLDebug);
            constellations[3] = new PhyConstellationData(PhyConstellationData.Antenna.ANT2, PhyConstellationData.EqPosition.BEFORE, PLLDebug);
        }

        /*
         * Starts constellation process, or refreshes the data files it reads.
         * If the process dies, tries to restart it.
         * 
         * If the EVB does not reply with the constellation data within
         * a reasonable time, returns SOC_UNRESPONSIVE.
         */
        public TRIGGER_RETURN_CODE trigger()
        {
            string[] log = new string[20];
            int logIndex = 0;
            System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
            //System.Console.WriteLine("\nStarting trigger()");
            st.Start();
            //string[logIndex ++] = new String("Starting: " + st.ElapsedMilliseconds.ToString());
            foreach (PhyConstellationData constellation in constellations)
            {
                int loop = 0;
                constellation.refreshData();
                Thread.Sleep(3); // 3 ms
                // Waits, at most, 3 seconds for the EVB replies
                while (!constellation.isDataReady() && (loop++ < 300))
                {
                    Thread.Sleep(10);
                    //System.Console.WriteLine("    sleep {0} complete (elapsed ms={1})", loop, st.ElapsedMilliseconds);

                }
                //System.Console.WriteLine("Data ready {0} for constellation part {3}, after {1} loops (elapsed ms={2})",
                //    constellation.isDataReady().ToString(), loop, st.ElapsedMilliseconds, logIndex);
                if (loop >= 300)
                {
                    return TRIGGER_RETURN_CODE.SOC_UNRESPONSIVE;
                }
                logIndex++;
                if (!constellation.flushToTempFile())
                {
                    // flushToFile only returns false after retrying several times,
                    // so it's appropriate to cancel the constellation process (i.e.,
                    // no need to continue for the other constellation files)
                    return TRIGGER_RETURN_CODE.FILE_WRITE_FAILURE;
                }
                //System.Console.WriteLine("flushToTempFile {0} complete (elapsed ms={1})", constellation.fileName, st.ElapsedMilliseconds);
                    
            }
            foreach (PhyConstellationData constellation in constellations)
            {
                if (!constellation.moveToMatlabFile())
                {
                    return TRIGGER_RETURN_CODE.FILE_WRITE_FAILURE; // failed
                }
            }
            uint modulation = PHY.phy.controlChannelRx.txAnnounced1;
            string modString = MCS.getMCS(MCS.BANDWIDTH.MHZ80, modulation).modulation;
            int constellationMode = 256;
            if (modString.Contains("16"))
            {
                constellationMode = 16;
            }
            else if (modString.Contains("64"))
            {
                constellationMode = 64;
            }
            else if (modString.Contains("256"))
            {
                constellationMode = 256;
            }
            else if (modString.Contains("1024"))
            {
                constellationMode = 1024;
            }
            else
            {
                constellationMode = 4;
            }

            if (PhyProfile.profiles[FormNodeProperties.instance.RunningProfile].Bandwidth > 30)
                { selectedFFT = 1; }
            else
                { selectedFFT = 0; }


            string args_logic4 = String.Format("{0} {1} {2} {3} {4} {5}",
                constellations[0].filePath, constellations[1].filePath, constellations[2].filePath, constellations[3].filePath,
                constellationMode, FFTsizes[selectedFFT]);
            
            //create new file - MatLab params file that will include: 4 file names, FFTsize, constallation, 
            // persistence enable/disable.
            
            string file_name = "params.txt";
            string paramsfilePath = folderRoot + file_name;
            string args_logic5 = paramsfilePath;
            Exception eSaved = null;

            try
            {
                File.Delete(paramsfilePath);
            }
            catch (Exception e)
            {
                eSaved = e;
            }
            try
            {
                TextWriter tw = new StreamWriter(paramsfilePath);
                tw.WriteLine(constellations[0].filePath + "\n" + constellations[1].filePath + "\n" +
                             constellations[2].filePath + "\n" + constellations[3].filePath + "\n" +                             
                             constellationMode.ToString() + "\n" + FFTsizes[selectedFFT].ToString() + "\n" + persistence.ToString()
                             + "\n" + Channel_estimation_graph_enable);
                tw.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error writing params file at {0} - {1} ", paramsfilePath, ex.Message);
            }

            //System.Console.WriteLine("moveToMatlabFile complete (elapsed ms={0})", st.ElapsedMilliseconds);
            if (matlabProcess != null)
            {
                // can we tell if it's still alive?
                if (!matlabProcess.HasExited)
                {
                    // The process periodically reads the data files, so
                    // now that they're refreshed, this task is complete.               
                    
                    return TRIGGER_RETURN_CODE.OK;
                }
                // If the process has exited, fall thru and restart it.
            }
            string args = "";
            if (New_Matlab)
            { args = args_logic5; }
            else
            { args = args_logic4; }
            
            try
            {
                matlabProcess = Process.Start(constellationExecutable, args);
                return TRIGGER_RETURN_CODE.OK;
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error starting Matlab process '{0}' - {1}", constellationExecutable, e.Message);
                return TRIGGER_RETURN_CODE.EXECUTABLE_FAILURE;
            }
        }

        /* Attempt to stop the matlab process, if running. */
        public void shutDown()
        {
            foreach (PhyConstellationData constellation in constellations)
            {
                constellation.cancelListener();
            }

            if (matlabProcess != null)
            {
                try
                {
                    // can we tell if it's still alive?
                    if (!matlabProcess.HasExited)
                    {
                        matlabProcess.Kill();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error closing matlab: {0}", e.Message);
                }
                matlabProcess = null;
            }
        }


    }
}
