using System;
using System.Diagnostics;

namespace PythonInCSharp
{
    public class Program
    {
        private static string exePath = "C:\\Users\\dell\\AppData\\Local\\Programs\\Python\\Python37-32\\python.exe";
        static void Main(string[] args)
        {
            Console.WriteLine("Pass full file path of python script to be run.");
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
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = false
                    };
                    process.Start();
                    outputText = process.StandardOutput.ReadToEnd();
                    //outputText = outputText.Replace(Environment.NewLine, string.Empty);
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
