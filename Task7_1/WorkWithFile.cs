using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_1
{
    public class WorkWithFile
    {
        string pathToReadFile = string.Empty;
        public void SetPath()
        {
            string keyboardInput = Console.ReadLine();
            while (!File.Exists(keyboardInput))
            {
                Console.WriteLine("Bad path, try again.");
                Log($"Error: File isn't found by path { keyboardInput}.\n");
                keyboardInput = Console.ReadLine();
            }
            this.pathToReadFile = keyboardInput;
        }
        public void ReadFromFile()
        {
            try
            {
                StreamReader fs = new StreamReader(pathToReadFile);
                string temp = String.Empty;
                int stringCounter = 0;
                while (fs.ReadLine() != null)
                {
                    stringCounter++;
                    temp = fs.ReadLine();
                    if (!temp.Equals(String.Empty))
                    {
                        Console.WriteLine(temp.First());
                    }
                    else
                    {
                        Console.WriteLine("Error: Empty string.");
                        Log($"Error: Empty string №{ stringCounter}.\n");
                    }
                }

            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
                Log(ioEx.Message);
            }
        }
        public static void Log(string message)
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
