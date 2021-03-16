using System;
using System.Diagnostics;
using HelloLibrary;

namespace cs_gb_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Задание 1.");
            var processes = Process.GetProcesses();

            ShowProcesses(processes);

            Console.WriteLine("\nВведите ID просесса, который нужно завершить:");

            try
            {
                int procID = int.Parse(Console.ReadLine());
                Process.GetProcessById(procID).Kill();
            }
            catch
            {
                Console.WriteLine("Ошибка при завершении процесса.");
            }

            Console.WriteLine($"\nЗадание 2.");

            HelloClass hello = new HelloClass();

            hello.WriteHello();
            hello.WriteHello("Welcome!");
            Console.WriteLine(hello.GetHelloString() + " " + Environment.UserName + "!");
        }

        private static void ShowProcesses(Process[] processes)
        {
            Console.WriteLine("ID\tName");
            for (int i = 0; i < processes.Length; i++)
            {
                Console.WriteLine(processes[i].Id + "\t" + processes[i].ProcessName);
            }
        }
    }
}
