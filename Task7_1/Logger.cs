using System;
using System.Globalization;
using System.IO;


namespace Task7_1
{
    public static class Logger
    {
        public static void AddToLog(Exception e)
        {
            DateTime localDate = DateTime.Now;
            string PATHTOLOG = Environment.CurrentDirectory+"\\logger.txt";
            File.AppendAllText(PATHTOLOG, "[" +
                localDate.ToString("G", CultureInfo.CreateSpecificCulture("ru-RU")) +
                "] " + e.GetType().FullName+
                e.Message);
        }
    }
}
