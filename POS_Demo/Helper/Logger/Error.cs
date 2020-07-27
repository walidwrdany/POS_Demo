using POS_Demo.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Demo
{
    public static class Error
    {
        public static void Log(Exception exception)
        {
            string filePath = Files.CreateIfNotExist($@"~/Logs/Error/Log_{System.DateTime.Now.ToString("yyyy_MM")}.txt");
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
            {
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine($"Date : {DateTime.Now.ToString("dd-MMM-yyyy HH:mm")}");
                writer.WriteLine();

                while (exception != null)
                {
                    writer.WriteLine(exception.GetType().FullName);
                    writer.WriteLine("Message : " + exception.Message);
                    writer.WriteLine("StackTrace : " + exception.StackTrace);
                    exception = exception.InnerException;
                }
            }
        }
    }
}