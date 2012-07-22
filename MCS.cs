using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class MCS
    {
        // TODO: make this PhyProfile.BANDWIDTH,
        // and provide a decimal for CalcTput
       

        public enum BANDWIDTH
        {
            MHZ80,
            MHZ56,
            MHZ40,
            MHZ28,
            MHZ20,
            MHZ10 
        };

        private static uint[] cinrThresholdsUp = { 1, 7, 9, 13, 15, 19, 24, 27, 30 };
        private static string[] modulations = { "QPSK", "16 QAM", "64 QAM", "256 QAM", "1024 QAM" };
        private static string[] upDownRatioDescr = { "1/2", "2/3", "3/4", "5/8", "6/8", "7/8", "8/10", "9/10", "13/16", "29/32", "30/32", "31/32","19/20", "31/40","17/20" };


        public static MCS[] mcsSet80 = {
                                     new MCS(1, 0, 0, 64, 120),
                                     new MCS(2, 0, 2, 96, 190),
                                     new MCS(3, 1, 0, 128, 250),
                                     new MCS(4, 1, 2, 192, 380),
                                     new MCS(5, 2, 1, 256, 510),
                                     new MCS(6, 3, 3, 320, 640),
                                     new MCS(7, 3, 4, 384, 770),
                                     new MCS(8, 3, 5, 448, 900),
                                     new MCS(9, 4, 6, 448, 900),        //  1024 QAM 8/10 
                                     new MCS(10,4, 7, 448, 900),        //  1024 QAM 9/10 
           //                          new MCS(11,4,10, 448, 900)         //  1024 QAM 30/32 
                                        };
        public static MCS[] mcsSet40 = {
                                     new MCS(1, 0, 0, 32, 50),
                                     new MCS(2, 0, 2, 48, 70),
                                     new MCS(3, 1, 0, 64, 90),
                                     new MCS(4, 1, 2, 96, 140),
                                     new MCS(5, 2, 1, 128, 250),
                                     new MCS(6, 3, 3, 160, 240),
                                     new MCS(7, 3, 4, 192, 280),
                                     new MCS(8, 3, 5, 224, 330),
                                     new MCS(9, 4, 6, 448, 900),        //  1024 QAM 8/10 
                                     new MCS(10,4, 7, 448, 900),        //  1024 QAM 9/10 
            //                         new MCS(11,4,10, 448, 900)         //  1024 QAM 30/32 
                                        };
        public static MCS[] mcsMiroWaveSet3 = {
                                     new MCS(1, 0, 0, 64, 120),         //  QPSK 1/2
                                     new MCS(2, 1, 10, 96, 190),         //  16 QAM 30/32
                                     new MCS(3, 2, 10, 192, 380),        //  64 QAM 30/32
                                     new MCS(4, 3, 9, 192, 380),        //  256 QAM 29/32
                                     new MCS(5, 3, 10, 256, 510),        //  256 QAM 30/32
                                     new MCS(6, 4, 13, 320, 640),        //  1024 QAM 31/40
                                     new MCS(7, 4, 6, 384, 770),        //  1024 QAM 8/10 
                                     new MCS(8, 4, 14, 448, 900),        //  1024 QAM 17/20 
                                     new MCS(9, 4, 5, 448, 900),        //  1024 QAM 7/8 
                                     new MCS(10,4, 7, 448, 900),        //  1024 QAM 9/10 
            //                         new MCS(11,4,12, 448, 900)         //  1024 QAM 30/32 
                                              };
        public static MCS[] mcsMiroWaveSet2 = {
                                     new MCS(1, 0, 0, 64, 120),         //  QPSK 1/2
                                     new MCS(2, 1,10, 96, 190),         //  16 QAM 30/32
                                     new MCS(3, 2, 5, 128, 250),        //  64 QAM 7/8 
                                     new MCS(4, 2,10, 192, 380),        //  64 QAM 30/32 
                                     new MCS(5, 3, 8, 256, 510),        //  256 QAM 13/16 
                                     new MCS(6, 3, 9, 320, 640),        //  256 QAM 29/32
                                     new MCS(7, 3,10, 384, 770),        //  256 QAM 30/32 
                                     new MCS(8, 4,13, 448, 900),        //  1024 QAM 31/40 
                                     new MCS(9, 4, 6, 448, 900),        //  1024 QAM 8/10 
                                     new MCS(10,4, 7, 448, 900),        //  1024 QAM 9/10 
            //                         new MCS(11,4,12, 448, 900)         //  1024 QAM 30/32 
                                        };
        public static MCS[] mcsMiroWaveSet1 = {
                                     new MCS(1, 0, 0, 64, 120),
                                     new MCS(2, 0, 2, 96, 190),
                                     new MCS(3, 1, 0, 128, 250),
                                     new MCS(4, 1, 2, 192, 380),
                                     new MCS(5, 2, 1, 256, 510),
                                     new MCS(6, 3, 3, 320, 640),
                                     new MCS(7, 3, 4, 384, 770),
                                     new MCS(8, 3, 5, 448, 900),
                                     new MCS(9, 4, 6, 448, 900),        //  1024 QAM 8/10 
                                     new MCS(10,4, 7, 448, 900),        //  1024 QAM 9/10 
                //                     new MCS(11,4,12, 448, 900)         //  1024 QAM 30/32 
                                        };

        public static MCS[] Current_MCS_scheme = {
                                    new MCS(1, 0, 0, 64, 120),         //  QPSK 1/2
                                     new MCS(2, 1,11, 96, 190),         //  16 QAM 30/32
                                     new MCS(3, 2, 5, 128, 250),        //  64 QAM 7/8 
                                     new MCS(4, 2,11, 192, 380),        //  64 QAM 30/32 
                                     new MCS(5, 3, 8, 256, 510),        //  256 QAM 13/16 
                                     new MCS(6, 3, 9, 320, 640),        //  256 QAM 29/32
                                     new MCS(7, 3,10, 384, 770),        //  256 QAM 30/32 
                                     new MCS(8, 4,13, 448, 900),        //  1024 QAM 31/40 
                                     new MCS(9, 4, 6, 448, 900),        //  1024 QAM 8/10 
                                     new MCS(10,4, 7, 448, 900),        //  1024 QAM 9/10 
            //                         new MCS(11,4,10, 448, 900)         //  1024 QAM 30/32 
                                        };




        private static MCS[] mcsSet56;
        private static MCS[] mcsSet28;

        public static uint getMaxMCS()
        {
            return (uint)mcsSet80.Length;
        }

        public static MCS getMCS(BANDWIDTH b, uint id)
        {
            // Note assumption that all bandwidths have same number of modes
            if (id < 1)
            {
                id = 1;
            }
            int Max_length;            
            { Max_length = Current_MCS_scheme.Length; }            
            if (id > Max_length)
            {
                { id = (uint)Current_MCS_scheme.Length; }              
            }
            return Current_MCS_scheme[id - 1];
        }
        

        public static void Current_MCS(bool Specific_BW_MCS, BANDWIDTH BW)
        {
            if (Specific_BW_MCS)
            {
                switch (BW)
                {
                    case (BANDWIDTH.MHZ80): Current_MCS_scheme = mcsSet80;
                        break;
                    case (BANDWIDTH.MHZ56): Current_MCS_scheme = mcsSet56;
                        break;
                    case (BANDWIDTH.MHZ28): Current_MCS_scheme = mcsSet28;
                        break;
                }
            }
            else
            {
                switch (FormNodeProperties.instance.MCSSet)
                {
                    case (1): Current_MCS_scheme = mcsMiroWaveSet1;
                        break;
                    case (2): Current_MCS_scheme = mcsMiroWaveSet2;
                        break;
                    case (3): Current_MCS_scheme = mcsMiroWaveSet3;
                        break;
                }
//}
//if (FormNodeProperties.instance.MCSSet == 1)
//{ Current_MCS_scheme = mcsMiroWaveSet2; }
//else
//{ Current_MCS_scheme = mcsMiroWaveSet1; }
            }
        }

        public static double CalcTput(double BW, string AntMethod, string MCS_modulation,string MCS_Rate , string range, bool isFDD)
        {
            double bit = 1;
            double code_rate;
            double MIMO;
            double Rolloff_Micrwave = 0.1085;
            double Delay_Spread = 0.12;
            double Baud_Rate = BW * (1 - Rolloff_Micrwave);
            double preamble_oh = ((128 + 64 + 12 + 12) / (35536.0 * BW / 40.0) + 24.0 / 6000.0 + 12.0 / 1536.0);
            double GI_Len = Delay_Spread * Baud_Rate;
            double block_length;
            double Guard;
            double PLL_Pilots = 0;
           
            if (BW > 30)
            { block_length = 512; }
            else
            { block_length = 256; }

            Guard = (GI_Len / (GI_Len + block_length));
            string[] temp_code_rate = MCS_Rate.Split('/');
            code_rate = (Convert.ToDouble(temp_code_rate[0]) / Convert.ToDouble(temp_code_rate[1]));

            if (AntMethod == "XPIC")
            {
                MIMO = 2;
            }
            else
            {
                MIMO = 1;
            }

            switch (MCS_modulation)
            {
                case "QPSK":
                    bit = 2;
                    break;
                case "16 QAM":
                    bit = 4;
                    break;
                case "64 QAM":
                    bit = 6;
                    break;
                case "256 QAM":
                    bit = 8;
                    break;
                case "1024 QAM":
                    bit = 10;
                    break;               
            }

            double Tput = 0;

          Tput = (bit * code_rate * Baud_Rate * MIMO * (1 - preamble_oh - Guard - PLL_Pilots));

            return Tput;
        }

        public int id { get; private set; }
        public string modulation { get { return modulations[modIndex]; }}
        public string upDownRatio { get { return upDownRatioDescr[upDownRatioIndex]; } }
        private int modIndex;
        private int upDownRatioIndex;
        public int tbSizeBytes { get; private set; }
        public int shaperCode { get; private set; }
        public uint cinrThresholdUp { 
            get {
                return cinrThresholdsUp[id];
            }
        }
 
        private MCS(int id, int mod, int upDownIndex, int tbSize, int shaperCode)
        {
        //    if (id >= cinrThresholdsUp.Length)
            if (id >= upDownRatioDescr.Length)
            {
                System.Console.WriteLine("BUG: invalid MCS ID {0}", id);
                throw new System.IndexOutOfRangeException("MCS index unexpected");
            }
            this.id = id;
            if (mod >= modulations.Length ) 
            {
                System.Console.WriteLine("Invalid input to MCS: Modulation {0}", mod);
                mod = modulations.Length - 1;
            }
            this.modIndex = mod;
            this.upDownRatioIndex = upDownIndex;
            this.tbSizeBytes = tbSize;
            this.shaperCode = shaperCode;
        }

        public override string ToString()
        {
            return modulation + " " + upDownRatio;
        }

    }
}
