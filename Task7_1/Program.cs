using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WorkWithFile wwf = new WorkWithFile();
                System.Console.WriteLine("Enter the path, where you want to create the folder.");
                wwf.SetPath();
                wwf.ReadFromFile();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: something is broken", e.Message);
                Log(ioEx.Message);
                Console.ReadKey();
            }

        }
    }
}
