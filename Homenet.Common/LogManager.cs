using System;
using Homenet.Filesystem;

namespace Homenet.Common
{
    public static class LogManager
    {
        private static readonly string LogDirectory = Environment.GetEnvironmentVariable("Homenet.LogDirectory");
        public static void Log(string logName, string message)
        {
            FileWriter.AppendToFile($@"{LogDirectory}\{logName}.txt", message);
        }
        public static  void Log(string message)
        {
            Log("Debug",message);
        }


    }
}
