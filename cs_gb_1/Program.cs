using System;

namespace cs_gb_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Задание 1");
            GetFullName("Иванов", "Иван", "Иванович");
            GetFullName("Полиграф", "Полиграфович", "Шариков");
            GetFullName("Фёдор", "Бильбович", "Сумкин");
            GetFullName("Эраст", "Петрович", "Фандорин");

            Console.WriteLine($"\nЗадание 2");

            Console.WriteLine($"Введите целые числа через пробел.");
            string numbersString = Console.ReadLine();
            int sum = CalcSum(numbersString);
            Console.WriteLine($"Сумма введёных чисел равна {sum}");

            Console.WriteLine($"\nЗадание 3");

            Console.WriteLine($"Введите номер месяца:");
            int month = int.Parse(Console.ReadLine());

            Seasons s = GetSeason(month);

            if (s == 0)
            {
                Console.WriteLine("Ошибка: введите число от 1 до 12");
            }
            else
            {
                Console.WriteLine($"Время года: {s}");
            }
        }

        private static void GetFullName(string firstName, string lastName, string patronymic)
        {
            Console.WriteLine($"{firstName} {lastName} {patronymic}");
        }

        private static int CalcSum(string enterString)
        {
            int sum = 0;

            var numbers = enterString.Split(' ');

            foreach (string n in numbers)
            {
                sum += int.Parse(n);
            }

            return sum;
        }

        private static Seasons GetSeason(int month)
        {
            return month switch
            {
                12 => Seasons.Winter,
                1 => Seasons.Winter,
                2 => Seasons.Winter,
                3 => Seasons.Spring,
                4 => Seasons.Spring,
                5 => Seasons.Spring,
                6 => Seasons.Summer,
                7 => Seasons.Summer,
                8 => Seasons.Summer,
                9 => Seasons.Autumn,
                10 => Seasons.Autumn,
                11 => Seasons.Autumn,
                _ => 0,
            };
        }

        private enum Seasons
        {
            Winter, 
            Spring, 
            Summer, 
            Autumn
        }
    }
}
