using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace luofu_InterestShare.Common.Log
{
    public class FileLog
    {

        public static readonly object _lock = new object();
        private static void Log(string ex)
        {
            try
            {
                lock (_lock)
                {

                    //修改记录日志的目录结构；
                    string basePath = AppDomain.CurrentDomain.BaseDirectory + "logs\\txtlogs";
                    if (!Directory.Exists(basePath))
                    {
                        Directory.CreateDirectory(basePath);
                    }
                    string path = Path.Combine(basePath, DateTime.Now.ToString("yyyy-MM-dd") + "-Infrastructurelog.txt");

                    using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
                    {
                        sw.WriteLine(ex);
                        sw.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                        sw.Close();//关闭文件流
                        sw.Dispose();//执行清理
                    }
                }
            }
            catch { }
        }
        public static void WriteLog(string ex)
        {
            string logdate = " 记录时间：" + DateTime.Now.ToString();
            Log(ex + logdate);
        }
    }
}
