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
                WorkWithFile wwf = new WorkWithFile();
                System.Console.WriteLine("Enter the path, where you want to create the folder.");
                wwf.SetUpPath();
                wwf.ReadFromFile();
            }
            catch (EmptyFileException emptyFileException)
            {
                Console.WriteLine("Error: File is empty.");
                Logger.AddToLog(emptyFileException.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Something is broken", e.Message);
                Logger.AddToLog(e.Message);
            }
            Console.ReadKey();
        }
    }
}
