using System;
using System.IO;
using System.Linq;
using Task7_1.Exceptions;

namespace Task7_1
{
    public class WorkWithFile
    {
        string pathToReadFile = string.Empty;
        public void SetUpPath()
        {
            bool isValidPath=false;
            const string EXTENSION = ".txt";
            string keyboardInput = Console.ReadLine();
            while (!isValidPath)
            {
                try
                {
                    if (!Path.GetExtension(keyboardInput).Equals(EXTENSION))
                    {
                        throw new InvalidExtensionException($"Error: File by path {keyboardInput} has invalid extension.\n");
                    }
                    if (!File.Exists(keyboardInput))
                    {
                        throw new FileNotFoundException($"Error: File isn't found by path {keyboardInput}.\n");
                    }
                    isValidPath = true;
                }
                catch (InvalidExtensionException invalidExtensionException)
                {
                    Console.WriteLine("Bad expension in path, try again.");
                    Logger.AddToLog(invalidExtensionException.Message);
                    keyboardInput = Console.ReadLine();
                }
                catch (FileNotFoundException fileNotFoundException)
                {
                    Console.WriteLine("Bad path, try again.");
                    Logger.AddToLog(fileNotFoundException.Message);
                    keyboardInput = Console.ReadLine();
                }
            }
            this.pathToReadFile = keyboardInput;
        }

        public void ReadFromFile()
        {
            StreamReader fs = new StreamReader(pathToReadFile);
            string temp = String.Empty;
            int stringCounter = 0;
            temp = fs.ReadLine();
            if (temp == null)
            {
                throw new EmptyFileException("Error: File is empty.\n");
            }
            while (temp != null)
            {
                try
                {
                    stringCounter++;
                    if (temp.Equals(String.Empty))
                    {
                        throw new EmptyStringException($"Error: Empty string № {stringCounter}.\n");
                    }
                    else
                    {
                        Console.WriteLine(temp.First());
                    }
                }
                catch (EmptyStringException emptyStringException)
                {
                    Console.WriteLine("Error: Empty string.");
                    Logger.AddToLog(emptyStringException.Message);
                }
                finally
                {
                    temp = fs.ReadLine();
                }
            }
        }
    }
}
