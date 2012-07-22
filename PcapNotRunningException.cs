using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class PcapNotRunningException : Exception 
    {
        public PcapNotRunningException()
        {
        }
        public PcapNotRunningException(string s) : base(s)
        {
        }
    }
}
