using System;
using System.Globalization;
using System.IO;


namespace Task7_1
{
    public static class Logger
    {
        public static void AddToLog(string message)
        {
            DateTime localDate = DateTime.Now;
            string PATHTOLOG = @"D:\logger.txt";
            File.AppendAllText(PATHTOLOG, "[" +
                localDate.ToString("G", CultureInfo.CreateSpecificCulture("ru-RU")) +
                "] " +
                message);
        }
    }
}
