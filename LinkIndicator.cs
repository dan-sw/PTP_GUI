using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    /*
     * Registers indicating Link Status
     *   In order of sequence, the status becomes good:
     *   1.        Sync. Achieved - 0xd01900c0 (o – Fail / >0 - Pass).
     *   2.       Timing loop. - 0xd01900e0 (0 - Fail / 1 – Pass).
     *   3.       TX on. – Ant0: 0xc6520008, ant1: 0xc6524008
     *       (0 - on / 606 - off ) -> if both antenna are On then pass else fail
     *   4.       PLL lock – 0xd01900f0 (will be implemented next release).
     */
    class LinkIndicator : MessageReplyListener
    {
        // These regs are available in 3 block requests
        private const int BLOCK_COUNT = 6;
        private readonly string[] blockNames = { "SyncTimingPll", "TxOn0", "TxOn1", "GONG", "PLL Ant0 Lock", "PLL Ant1 Lock" };
        private readonly UInt32[] blockAddrs = { 0xd0190078, 0xc6520008, 0xc6524008, 0xe045800C, 0xd0190430, 0xd0190440 };
        private readonly byte[] blockWordCounts = { 1, 1, 1, 1, 1, 1};

        // Block 0 
      //  private const int SYNC_ACHIEVED_index = 0; // 0xd01900c0
        private const int TIMING_LOOP_index = 8;   // 0xd01900e0
     //   private const int PLL_LOCK_index = 12;  // 0xd01900f0

        private delegate void ProcessMessageDelegate(DAN_gui_msg msg);
        private ProcessMessageDelegate[] handlers;

        private bool syncAchieved;
        private bool timingLoopOK;
        private bool pllLock;
        private bool txOnAnt0;
        private bool txOnAnt1;
        private bool gongOn;
        private bool pllLockAnt0;
        private bool pllLockAnt1;

        public bool SyncAchieved { get { return syncAchieved; } }
        public bool TimingLoopOK { get { return timingLoopOK; } }
        public bool PllLock { get { return pllLock; } }
        public bool TxOnAnt0 { get { return txOnAnt0; } }
        public bool TxOnAnt1 { get { return txOnAnt1; } }
        public bool GongOn { get { return gongOn; } }
//        public bool TxOn { get { return txOnAnt0 && txOnAnt1 && gongOn; } }
        public bool TxOn { get { return gongOn; } }
        public bool PllLockAnt0 { get { return pllLockAnt0; } }
        public bool PllLockAnt1 { get { return pllLockAnt1; } }

        public static LinkIndicator links = new LinkIndicator();

        private LinkIndicator()
        {
            handlers = new ProcessMessageDelegate[6];
            handlers[0] = this.handleSyncTimingPll;
            handlers[1] = this.handleTxOn0;
            handlers[2] = this.handleTxOn1;
            handlers[3] = this.handleGong;
            handlers[4] = this.handlePLLAnt0;
            handlers[5] = this.handlePLLAnt1;

            // Register for message responses
            PcapConnection.pcap.addListener(this);
        }

        private void handleSyncTimingPll(DAN_gui_msg msg)
        {
      //      syncAchieved = (msg.data[SYNC_ACHIEVED_index] == 0 ? false : true);
            timingLoopOK = (((msg.data[0] == 2) || (msg.data[0] == 0))? true : false);
        //    pllLock = (msg.data[PLL_LOCK_index] == 0 ? false : true);
        }

        private void handlePLLAnt0(DAN_gui_msg msg)
        {
            pllLockAnt0 = (msg.data[0] == 1 ? true : false);
        }

        private void handlePLLAnt1(DAN_gui_msg msg)
        {
            pllLockAnt1 = (msg.data[0] == 1 ? true : false);
        }

        private void handleTxOn0(DAN_gui_msg msg)
        {
            txOnAnt0 = (msg.data[0] == 0 ? true : false);
        }

        private void handleTxOn1(DAN_gui_msg msg)
        {
            txOnAnt1 = (msg.data[0] == 0 ? true : false);
        }

        private void handleGong(DAN_gui_msg msg)
        {
            gongOn = (msg.data[0] == 1 ? true : false);
        }

        // Returns true if the msg represents data for this listener; false if 
        // the address is not recognized (reply is for some other listener)
        public bool MessageReplyListenerCallback(DAN_gui_msg msg, DateTime arrivalTime)
        {
            for (int i = 0; i < BLOCK_COUNT; i++)
            {
                if (msg.address == blockAddrs[i])
                {
                    if (msg.size != blockWordCounts[i])
                    {
                        Console.WriteLine("BUG: msg reply {0} wrong size = {0}", blockNames[i], msg.size);
                        return true; // won't bother any other object with parsing it, since it IS for this object
                    }
                    handlers[i](msg);
                    return true;
                }
            }
            return false;
        }

        // Request register contents (three block requests)
        // Responses are handled on another thread by MessageReplyListenerCallback
        public void getNextValues()
        {
            for (int i = 0; i < BLOCK_COUNT; i++)
            {
                DAN_read_array_msg msg = new DAN_read_array_msg(blockAddrs[i], blockWordCounts[i]);
                PcapConnection.pcap.sendDanMsg(msg);
            }
        }
    }
}
