using System;
using IronPython;
using IronPython.Hosting;
using IronPython.Runtime;
using Microsoft.Scripting.Hosting;

namespace WithIronPython
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running python in C# application.");
            ScriptEngine engine = Python.CreateEngine();
            string inputText = String.Empty;            
            while(true)
            {
                Console.Write(">>>");
                inputText = Console.ReadLine();
                if(inputText == "exit()")
                    break;
                var outputText = engine.Execute(inputText);
                Console.WriteLine(outputText.ToString());
            }
            
        }
    }
}
