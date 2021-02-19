using System;
using System.ComponentModel;
using System.Diagnostics;

namespace ModuleEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Name of Process (Input ALL to check all processes): ");
            string procName = Console.ReadLine();
            Console.ResetColor();
            string procNameNew = procName.ToLower();
            Console.WriteLine("");
            if (procNameNew == "all")
            {
                Process[] processCollection = Process.GetProcesses(Environment.MachineName);
                foreach (Process proc in processCollection)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--------------------");
                        Console.ResetColor();
                        Console.WriteLine("Process: " + proc.ProcessName);
                        Console.WriteLine("Process ID: " + proc.Id);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--------------------");
                        foreach (ProcessModule module in proc.Modules)
                        {
                            Console.WriteLine(module.FileName);
                        }
                        Console.WriteLine("--------------------");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.ResetColor();
                    }
                    catch (Win32Exception w)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[!] Error Retrieving Modules");
                        Console.WriteLine(w.Message);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--------------------");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.ResetColor();
                    }
               
                }
            }
            else
            {
                Process[] identifiedProcess = Process.GetProcessesByName(procNameNew);
                foreach (Process IDproc in identifiedProcess)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("--------------------");
                    Console.ResetColor();
                    Console.WriteLine("Process: " + IDproc.ProcessName);
                    Console.WriteLine("Process ID: " + IDproc.Id);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("--------------------");
                    foreach (ProcessModule module in IDproc.Modules)
                    try
                    {
                        Console.WriteLine(module.FileName);
                    }
                    catch (Win32Exception w)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[!] Error Retrieving Modules");
                        Console.WriteLine(w.Message);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--------------------");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.ResetColor();
                    }

                    Console.WriteLine("--------------------");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.ResetColor();
                    }
            }
            Console.ResetColor();
            Console.WriteLine("");
        }
    }
}
