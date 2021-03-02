using System;
using System.IO;

namespace cs_gb_1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Задание 1.");

            Console.WriteLine("Введите строку:");
            string text = Console.ReadLine();
            string filename = "Задание 1.txt";
            File.WriteAllText(filename, text);

            Console.WriteLine("\nЗадание 2.");

            string fileStartUpName = "startup.txt";
            string dateContent = DateTime.Now.ToString() + Environment.NewLine;

            if (File.Exists(fileStartUpName))
            {
                File.AppendAllText(fileStartUpName, dateContent);
            }
            else
            {
                File.WriteAllText(fileStartUpName, dateContent);
            }

            Console.WriteLine($"Выполнена запись в {fileStartUpName}");

            Console.WriteLine("\nЗадание 3.");

            byte[] massByte = new byte[10];

            Console.WriteLine("Введите 10 чисел через пробел");

            for (int i = 0; i < 10; i++)
            {
                massByte[i] = byte.Parse(Console.ReadLine());
            }

            string byteMassFileName = "byteMassFile.bin";
            File.WriteAllBytes(byteMassFileName, massByte);

            Console.WriteLine($"Выполнена запись введёных чисел в {byteMassFileName}");

        }
    }
}
