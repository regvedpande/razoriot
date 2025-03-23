using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BestEmployeeManagement.Helpers
{
    public static class Logger
    {
        private static readonly string LogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        static Logger()
        {
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }

        public static void WriteLog(string message)
        {
            string logFilePath = Path.Combine(LogDirectory, $"log_{DateTime.Now:yyyy-MM-dd}.txt");
            using (StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                sw.WriteLine($"{DateTime.Now:dd-MMM-yyyy HH:mm:ss} - {message}");
            }
        }
    }
}