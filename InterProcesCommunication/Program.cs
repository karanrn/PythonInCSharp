using System;
using System.Diagnostics;
using System.IO;

namespace PythonInCSharp
{
    public class Program
    {
        private static string exePath = "C:\\Users\\dell\\AppData\\Local\\Programs\\Python\\Python37-32\\python.exe";
        static void Main(string[] args)
        {
            Console.Write("Pass full file path of python script to be run: ");
            string filePath = Console.ReadLine();
            string output = ExecutePythonScript(filePath);
            Console.WriteLine("\nOutput from python execution : \n" + output);
        }

        ///<summary>
        ///Executes the python script 
        ///</summary>
        public static string ExecutePythonScript(string filePath)
        {
            string outputText = string.Empty;
            try
            {
                using(Process process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo(exePath)
                    {
                        Arguments = filePath,
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = false
                    };
                    process.Start();

                    Console.Write("Enter your name: ");
                    string inputText = Console.ReadLine();
                    StreamWriter pySW = process.StandardInput;
                    pySW.WriteLine(inputText);
                    pySW.Close();
                    outputText = process.StandardOutput.ReadToEnd();
                    
                    process.WaitForExit();

                }
            }
            catch (System.Exception ex)
            {                
                Console.WriteLine(ex.Message);
            }
            return outputText;

        }
    }
}
