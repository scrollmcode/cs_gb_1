using System;

namespace cs_gb_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name; // имя
            Console.WriteLine("Введите имя");
            name = Console.ReadLine();
            Console.WriteLine($"Привет {name}, сегодня {DateTime.Now.Date.ToString("dd.MM.yyyy")}");
        }
    }
}
