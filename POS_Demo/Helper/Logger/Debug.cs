using POS_Demo.Helper;
using System.IO;

namespace POS_Demo
{
    public static class Debug
    {
        public static void Log(string log)
        {
            string filePath = Files.CreateIfNotExist($@"~/Logs/Debug/Log_{System.DateTime.Now.ToString("yyyy_MM")}.txt");
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("------------------------------------------------------------");
                writer.WriteLine(log);
            }
        }
    }
}