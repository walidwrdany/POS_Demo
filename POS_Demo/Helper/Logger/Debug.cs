using POS_Demo.Helper;
using System.IO;

namespace POS_Demo
{
    public static class Debug
    {
        public static void Log(object log)
        {
            string filePath = Files.CreateIfNotExist($@"~/Logs/Debug/debugging mode [{System.DateTime.Now.ToString("yyyy_MM_dd")}].txt");
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(log);
            }
        }
    }
}