using Furion.DynamicApiController;
using Furion.Templates;
using Furion.VirtualFileServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using System.Text;

namespace KodPlay_Server.Server.FileSys
{
    public class VerificationFiles 
    {
   

        private static  IFileProvider _physicalFileProvider;// 解析物理文件系统



        // I:\Project\C#\Project\StartClient\KodPlay_CSGO_Clinet\KodPlay-CSGO-Client\KodPlay-Server\bin\Debug\net6.0\

        public static void VerificationFolder()
        {

           
            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Resource\\mod");
            FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos("*", SearchOption.AllDirectories);
            for (int i = 0; i < fileSystemInfos.Length; i++)
            {
                var file = fileSystemInfos[i];
                //Console.WriteLine($"isDir:{file.Attributes == FileAttributes.Directory} name:{file.Name} Path:{file.FullName}");
                var isDir = file.Attributes == FileAttributes.Directory;

                var FileMd5 = ConvertStringToMd5(file.FullName);
                var Fileinfo = TP.Wrapper("GET File Info", "名称" + file.Name,
                                "##文件夹## "+ isDir,
                               "##文件MD5## " + FileMd5,
                               "##最后修改时间" + file.LastAccessTime.ToString(),
                               "文件路径 " + file.FullName
                    );
                Console.WriteLine(Fileinfo);




            }



        }


        //获取文件夹文件个数
        public static void GetFileSizeAndCount(string dir, ref int dirFileCount, ref long dirSize, ref string content)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                DirectoryInfo[] dirs = dirInfo.GetDirectories();
                FileInfo[] files = dirInfo.GetFiles();

                foreach (var item in dirs)
                {
                    GetFileSizeAndCount(item.FullName, ref dirFileCount, ref dirSize, ref content);
                }

                dirFileCount += files.Length;
                foreach (var item in files)
                {
                    dirSize += item.Length;
                    content += item.Length.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取文件夹文件个数失败" + ex.Message);
            }
        }



        // 根据内容计算md5
        private static string ConvertStringToMd5(string content)
        {
            try
            {
                byte[] btcontent = Encoding.ASCII.GetBytes(content);
                System.Security.Cryptography.MD5 file_md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] ret = file_md5.ComputeHash(btcontent);
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < ret.Length; ++i)
                {
                    sBuilder.Append(ret[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
            catch { }
            return "";
        }

    }
}
