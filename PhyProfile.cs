using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class PhyProfile
    {
        public string Name { get; private set; }
        // TODO: Use MCS.BANDWIDTH enum (or, move that here; s/be Profile attribute.)
        public int Bandwidth { get; private set; }
        public string DuplexMode { get; private set; }
        public int Range { get; private set; }
        // TODO: Not sure this belongs with the profile, but calcTPut needs it:
        public string AntennaMode { get; private set; }  // "XPIC" or "MIMO"

        static public PhyProfile[] profiles = {
                new PhyProfile ("80Mhz FDD Demo", 0, "FDD", 0, "XPIC"),                //0
                new PhyProfile ("56Mhz FDD Microwave", 56, "FDD", 20, "XPIC"),         //1
                new PhyProfile ("28Mhz FDD Microwave", 28, "FDD", 20, "XPIC"),         //2
                new PhyProfile ("14Mhz FDD Microwave", 14, "FDD", 20, "XPIC"),         //3
                new PhyProfile ("7Mhz FDD Microwave", 7, "FDD", 20, "XPIC"),           //4
                new PhyProfile ("50Mhz FDD Microwave", 50, "FDD", 20, "XPIC"),         //5
                new PhyProfile ("40Mhz FDD Microwave", 40, "FDD", 20, "XPIC"),         //6
                new PhyProfile ("30Mhz FDD Microwave", 30, "FDD", 20, "XPIC"),         //7
                new PhyProfile ("20Mhz FDD Microwave", 20, "FDD", 20, "XPIC"),         //8
                new PhyProfile ("10Mhz FDD Microwave", 10, "FDD", 20, "XPIC"),         //9
                new PhyProfile ("125Mhz FDD EBAND", 125, "FDD", 20, "XPIC"),           //10
                new PhyProfile ("56Mhz FDD Microwave", 56, "FDD", 20, "XPIC"),         //11
                new PhyProfile ("28Mhz FDD Microwave", 28, "FDD", 20, "XPIC"),         //12
                new PhyProfile ("Microwave", 28, "FDD", 2, "XPIC"),                    //13
                new PhyProfile ("Microwave", 28, "FDD", 2, "XPIC"),                    //14
                new PhyProfile ("Microwave", 28, "FDD", 2, "XPIC"),                    //15
                new PhyProfile ("Microwave", 28, "FDD", 2, "XPIC"),                    //16
                new PhyProfile ("Microwave", 28, "FDD", 2, "XPIC"),                    //17
                new PhyProfile ("Microwave", 28, "FDD", 2, "XPIC"),                    //18
                new PhyProfile ("Microwave", 28, "FDD", 2, "XPIC"),                    //19
                new PhyProfile ("40Mhz FDD NLOS", 40, "FDD", 20, "XPIC"),              //20
                new PhyProfile ("20Mhz FDD NLOS", 20, "FDD", 20, "XPIC"),              //21
                new PhyProfile ("10Mhz FDD NLOS", 10, "FDD", 20, "XPIC")               //22
                                              };

        private PhyProfile(string name, int bandwidth, string duplexmode, int range, string ant)
        {
            this.Name = name;
            this.Bandwidth = bandwidth;
            this.DuplexMode = duplexmode;
            this.Range = range;
            this.AntennaMode = ant;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
