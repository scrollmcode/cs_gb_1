using System;

namespace cs_gb_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // задание 1
            double minT;
            double maxT;
            double midT;

            Console.WriteLine("1");
            Console.WriteLine("Введите минимальную темпереатуру");
            minT = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите максимальную темпереатуру");
            maxT = double.Parse(Console.ReadLine());

            midT = (minT + maxT) / 2;
            Console.WriteLine($"Среднесуточная температура: {midT}");

            // задание 2

            int m;
            Console.WriteLine("\n2");
            Console.WriteLine("Ведиете номер месяца");
            m = int.Parse(Console.ReadLine());

            switch (m)
            {
                case 1: Console.WriteLine("Январь"); break;
                case 2: Console.WriteLine("Февраль"); break;
                case 3: Console.WriteLine("Март"); break;
                case 4: Console.WriteLine("Апрель"); break;
                case 5: Console.WriteLine("Май"); break;
                case 6: Console.WriteLine("Июнь"); break;
                case 7: Console.WriteLine("Июль"); break;
                case 8: Console.WriteLine("Август"); break;
                case 9: Console.WriteLine("Сентябрь"); break;
                case 10: Console.WriteLine("Октябрь"); break;
                case 11: Console.WriteLine("Ноябрь"); break;
                case 12: Console.WriteLine("Декабрь"); break;
                default: Console.WriteLine("Не корректный номер месяца"); break;
            }

            // задание 5
            if ((m == 1 || m == 2 || m == 12) && midT > 0)
            {
                Console.WriteLine("Дождливая зима.");
            }

            // задание 3
            Console.WriteLine("\n3");
            Console.WriteLine("Ведиете целое число");
            int c = int.Parse(Console.ReadLine());
            string otvet3 = c % 2 == 0 ? "чётное число" : "не чётное число";
            Console.WriteLine($"{c} {otvet3}");

            // задание 4
            Console.WriteLine("\n4");
            decimal total = 123 + 234 + 345;
            string checkExample =
                $"        Пример чека       \n" +
                $"\n" +
                $"товар 1\t123р\n" +
                $"товар 2\t234р\n" +
                $"товар 3\t345р\n" +
                $"\n" +
                $"Итого\t{total}\n" +
                $"Дата\t{DateTime.Now}\n";

            Console.WriteLine(checkExample);

            // задание 6
            Console.WriteLine("\n6");

            dayOfWork calendarOffice1 = dayOfWork.вторник | dayOfWork.среда | dayOfWork.четверг | dayOfWork.пятница;
            dayOfWork calendarOffice2 = dayOfWork.понедельник | dayOfWork.вторник | dayOfWork.среда | 
                dayOfWork.четверг | dayOfWork.пятница | dayOfWork.суббота | dayOfWork.воскресенье;

            Console.WriteLine($"понедельник \tОфис1 \t" +
                $"{(calendarOffice1 & dayOfWork.понедельник) == dayOfWork.понедельник } " +
                $"\tОфис2 \t{(calendarOffice2 & dayOfWork.понедельник) == dayOfWork.понедельник }");
            Console.WriteLine($"вторник \tОфис1 \t" +
                $"{(calendarOffice1 & dayOfWork.вторник) == dayOfWork.вторник} " +
                $"\tОфис2 \t{(calendarOffice2 & dayOfWork.вторник) == dayOfWork.вторник }");
            Console.WriteLine($"среда \t\tОфис1 \t" +
                $"{(calendarOffice1 & dayOfWork.среда) == dayOfWork.среда } " +
                $"\tОфис2 \t{(calendarOffice2 & dayOfWork.среда) == dayOfWork.среда }");
            Console.WriteLine($"четверг \tОфис1 \t" +
                $"{(calendarOffice1 & dayOfWork.четверг) == dayOfWork.четверг } " +
                $"\tОфис2 \t{(calendarOffice2 & dayOfWork.четверг) == dayOfWork.четверг }");
            Console.WriteLine($"пятница \tОфис1 \t" +
                $"{(calendarOffice1 & dayOfWork.пятница) == dayOfWork.пятница } " +
                $"\tОфис2 \t{(calendarOffice2 & dayOfWork.пятница) == dayOfWork.пятница }");
            Console.WriteLine($"суббота \tОфис1 \t" +
                $"{(calendarOffice1 & dayOfWork.суббота) == dayOfWork.суббота } " +
                $"\tОфис2 \t{(calendarOffice2 & dayOfWork.суббота) == dayOfWork.суббота }");
            Console.WriteLine($"воскресенье \tОфис1 \t" +
                $"{(calendarOffice1 & dayOfWork.воскресенье) == dayOfWork.воскресенье } " +
                $"\tОфис2 \t{(calendarOffice2 & dayOfWork.воскресенье) == dayOfWork.воскресенье }");

        }
        [Flags]
        enum dayOfWork
        {
            понедельник = 0b_0000001,
            вторник = 0b_0000010,
            среда = 0b_0000100,
            четверг = 0b_0001000,
            пятница = 0b_0010000,
            суббота = 0b_0100000,
            воскресенье = 0b_1000000
        }
    }
}
