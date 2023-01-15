using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Shapes;

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

        //运行第三方APP
        public static void CheakOtherAccessApp()
        {
            var kacDownloadURL = "";

            string kacpath = System.AppDomain.CurrentDomain.BaseDirectory + "kac.exe";
            string updaterpath = System.AppDomain.CurrentDomain.BaseDirectory + "updater.exe";
            if (System.IO.File.Exists(kacpath) && System.IO.File.Exists(updaterpath))
            {
                System.Diagnostics.Process.Start(kacpath);
                //System.Diagnostics.Process.Start(updaterpath);
            }
            else
            {
                if (!System.IO.File.Exists(kacpath))
                {
                    using (var web = new WebClient())
                    {
                        web.DownloadFile("https://kodplay.com/kac.exe", kacpath);
                    }
                }
                else
                {
                    using (var web = new WebClient())
                    {
                        web.DownloadFile("https://kodplay.com/updater.exe", updaterpath);
                    }
                }
                CheakOtherAccessApp();








            }



        }



    }
}
