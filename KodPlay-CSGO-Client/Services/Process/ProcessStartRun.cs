using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Text;
using System.Threading;

namespace KodPlay_CSGO_Client.Services.ProcessStartRun
{
    internal class ProcessStartRun
    {


        //检测Steam是否在线
        public static bool Cheak_Process_In_Run()
        {
            Process[] processes = Process.GetProcesses();
            foreach (var item in processes)
            {
                if (item.ProcessName == "steam")
                {
                    return true;
                }
            }
            return false;

        }
    }
}
