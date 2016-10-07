using System;
using System.IO;
using System.Linq;
using Task7_1.Exceptions;

namespace Task7_1
{
    public class WorkWithFile
    {
        public string PathToReadFile { get; set; }
        const string EXTENSION = ".txt";
        public void Start()
        {
            bool isValidFile = false;
            while (!isValidFile)
            {
                try
                {
                    System.Console.WriteLine("Enter the path, where you want to read the txt file.");
                    this.SetUpPath();
                    this.ShowFirstCharOfValidString();
                    isValidFile = true;
                }
                catch (EmptyFileException emptyFileException)
                {
                    Console.WriteLine("Error: File is empty.");
                    Logger.AddToLog(emptyFileException);
                }
            }
        }
        private void SetUpPath()
        {
            bool isValidPath = false;
            string keyboardInput = Console.ReadLine();
            while (!isValidPath)
            {
                try
                {
                    if (!File.Exists(keyboardInput))
                    {
                        throw new FileNotFoundException($"Error: File is't found by path {keyboardInput}.{Environment.NewLine}");
                    }
                    if (!Path.GetExtension(keyboardInput).Equals(EXTENSION))
                    {
                        throw new InvalidExtensionException($"Error: File by path {keyboardInput} has invalid extension.{Environment.NewLine}");
                    }
                    isValidPath = true;
                }
                catch (FileNotFoundException fileNotFoundException)
                {
                    Console.WriteLine("Bad path, try again.");
                    Logger.AddToLog(fileNotFoundException);
                    keyboardInput = Console.ReadLine();
                }
                catch (InvalidExtensionException invalidExtensionException)
                {
                    Console.WriteLine("Bad extension in path, try again.");
                    Logger.AddToLog(invalidExtensionException);
                    keyboardInput = Console.ReadLine();
                }
            }
            this.PathToReadFile = keyboardInput;
        }

        private void ShowFirstCharOfValidString()
        {
            StreamReader fs = new StreamReader(PathToReadFile);
            string temp = String.Empty;
            int stringCounter = 0;
            temp = fs.ReadLine();
            if (temp == null)
            {
                throw new EmptyFileException($"Error: File is empty.{Environment.NewLine}");
            }
            while (temp != null)
            {
                try
                {
                    stringCounter++;
                    if (temp.Equals(String.Empty))
                    {
                        throw new EmptyStringException($"Error: Empty string № {stringCounter}.{Environment.NewLine}");
                    }
                    else
                    {
                        Console.WriteLine(temp.First());
                    }
                }
                catch (EmptyStringException emptyStringException)
                {
                    Console.WriteLine("Error: Empty string.");
                    Logger.AddToLog(emptyStringException);
                }
                finally
                {
                    temp = fs.ReadLine();
                }
            }
            fs.Close();
        }
    }
}
