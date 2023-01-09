﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Xml.Linq;
using HandyControl.Controls;
using HtmlAgilityPack;

namespace KodPlay_CSGO_Client.Services.Analysis_Userdata
{
    internal class Analysis_Userdata
    {

        public static string GetWebInfo(string url, string encoder)
        {
            WebClient myWebClient = new WebClient();
            byte[] myDataBuffer = myWebClient.DownloadData(url);
            string SourceCode = Encoding.GetEncoding(encoder).GetString(myDataBuffer);
            return SourceCode;
        }



        //解析头部三要素
        // Analysis URL: https://shequfu.kodplay.com/
        ///html/body/div[1]/div[1]/div[1]/div/div[1]/div/text()

        static string PageUrl = "https://shequfu.kodplay.com/";

        public static void Analysis_Userdata_handinfoAsync()
        {
            KodPlay_CSGO_Client.Services.Control.Control_HTMLUser_Data control_HTMLUser_Data = new Control.Control_HTMLUser_Data();

         

        }

        public static void Analysis_Userdata_ServerInfo()
        {
            HtmlWeb Webs = new HtmlWeb();
            HtmlDocument DOCc = Webs.Load(PageUrl);
            HtmlNode Table = DOCc.DocumentNode.SelectSingleNode("//table[@lay-filter='demo']//tbody"); //server_count
            HtmlNodeCollection aCollection = Table.ChildNodes;
            HtmlNode node = DOCc.CreateElement("//tr//td");
            aCollection = Table.ChildNodes;
            foreach (var item in aCollection)
            {
                string aInterText = item.InnerText;
                Console.WriteLine("标签内容:" + aInterText);
            }
        }


    }
}
