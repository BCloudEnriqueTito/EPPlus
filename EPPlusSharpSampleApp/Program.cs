using System;
using System.IO;

namespace EPPlusSharpSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Sample 3, 4 and 12 uses the Adventureworks database. Enter the connectionstring to the Adventureworks database(2016 CTP3) into the variable below...
                //Leave this blank if you don't have access to the Adventureworks database 
                string
                    connectionStr =
                        ""; //for example "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=AdventureWorks2016CTP3;Data Source=MySqlServer"

                //Set the output directory to the SampleApp folder where the app is running from. 
                Utils.OutputDir = new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory}SampleApp");

                // Sample 1 - simply creates a new workbook from scratch
                // containing a worksheet that adds a few numbers together 
                Console.WriteLine("Running sample 1");
                string sample1Path = Sample1.RunSample1();
                Console.WriteLine("Sample 1 created: {0}", sample1Path);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Genereted sample workbooks can be found in {Utils.OutputDir.FullName}");
            Console.ForegroundColor = prevColor;

            Console.WriteLine();
            Console.WriteLine("Press the return key to exit...");
            Console.Read();
        }
    }
}
