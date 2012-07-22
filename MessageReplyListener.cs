using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    interface MessageReplyListener
    {
        bool MessageReplyListenerCallback(DAN_gui_msg msg, DateTime arrivalTime);
    }
}
