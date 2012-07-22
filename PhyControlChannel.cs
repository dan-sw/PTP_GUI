using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class PhyControlChannel
    {
        private UInt32 hiWord;

        /*
         * Difficult - impossible - to rely on how the xtensa compiler might
         * be packing these fields.  C99 Ss6.7.2.1 "The order of allocation of bit-fields within
         * a unit (high-order to low-order or low-order to high-order) is implementation-defined."
         * 
         * By trial and error, I believe that the high 4 nibbles are announded and recommended MMC.
         * Oren confirmed.
         */
        public uint frameNum { get { return (hiWord & 0xff); } }
        public string antennaMethod
        {
            // TODO: Is it this, or is it (hiWord & 0x00000100) ? 
            // TODO: Does 1 mean SISO, or does 0 mean SISO?
            // Current note from Oren is that this is reserved for future atpc:
            get { if ((hiWord & 0x00008000) == 0) { return "SISO"; } else { return "MIMO"; } }
        }
        public uint atpcPowerAdj { get { return (hiWord >> 8) & 0x3f; } }
        public uint rxRecommended2 { get{ return (hiWord >> 16) & 0xf; } }
        // Temp Debugging: To show a moving target...  That is, I think this >> 20 is correct,
        // but never see the announced values change.  But using ">> 8" and ">> 0" interprets
        // the (ever changing) frame number as the MCS, which helps in debugging the Graphs.
        public uint txAnnounced2 { get { return (hiWord >> 20) & 0xf; } }
        public uint rxRecommended1 { get { return (hiWord >> 24) & 0xf; } }
        public uint txAnnounced1 { get { return (hiWord >> 28) & 0xf; } }
        
        public PhyControlChannel(UInt32 channelHiWord)
        {
            hiWord = channelHiWord;
        }
    }
}
