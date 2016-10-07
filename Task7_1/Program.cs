using System;
using Task7_1.Exceptions;

namespace Task7_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WorkWithFile workWithFile = new WorkWithFile();
                workWithFile.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something is broken", e.Message);
                Logger.AddToLog(e);
            }
            Console.ReadKey();
        }
    }
}
