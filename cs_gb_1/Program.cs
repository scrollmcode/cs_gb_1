using System;
using System.IO;
using System.Text.Json;

namespace cs_gb_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1.");
            string workDir = ".\\testDirectories";
            string reportFile = ".\\testDirectories\\report.txt";
            if (!Directory.Exists(workDir))
            {
                Directory.CreateDirectory(workDir);
            }

            GetDirectoryContent(workDir, reportFile);

            Console.WriteLine("\nЗадание 2.");

            string tasksPath = ".\\todo";
            string tasksFileName = "tasks.json";
            if (!Directory.Exists(tasksPath))
            {
                Directory.CreateDirectory(tasksPath);
            }

            //test
            #region test data
            //ToDo[] tasks = new ToDo[5];

            //for (int i = 0; i < 5; i++)
            //{
            //    tasks[i] = new ToDo("t" + (i + 1).ToString(), false);
            //}
            //string jsonData = JsonSerializer.Serialize(tasks);
            //File.WriteAllText(Path.Combine(tasksPath, tasksFileName), jsonData);
            #endregion

            string jsonTasksText = File.ReadAllText(Path.Combine(tasksPath, tasksFileName));
            ToDo[] currentTasks = 
                JsonSerializer.Deserialize<ToDo[]>(jsonTasksText);

            int indexTasksList = 0;
            foreach (ToDo t in currentTasks)
            {
                Console.WriteLine(string.Format("{0} {1} {2}",
                    ++indexTasksList,
                    t.IsDone == true ? "X" : " ",
                    t.Title));
            }

            Console.WriteLine("Введите номер выполненной задачи:");
            int taskNumber = int.Parse(Console.ReadLine());
            currentTasks[taskNumber - 1].IsDone = true;

            string jsonCurrentData = JsonSerializer.Serialize(currentTasks);
            File.WriteAllText(Path.Combine(tasksPath, tasksFileName), jsonCurrentData);

            Console.WriteLine("\nЗадание 3.");

            string[,] mas = new string[4,4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mas[i, j] = $"{j}";
                }
            }
            // generate error
            mas[2, 3] = "X";

            ControlMass(mas);

            Console.WriteLine("\nЗадание 4.");

            Person[] persArray = new Person[5];
            persArray[0] = new Person("p1", Prof.Engineer, "abc@abc.abc", "0000000", 100000, 30);
            persArray[1] = new Person("p2", Prof.manager, "abc@abc.abc", "0000000", 100000, 45);
            persArray[2] = new Person("p3", Prof.constructor, "abc@abc.abc", "0000000", 100000, 50);
            persArray[3] = new Person("p4", Prof.programmer, "abc@abc.abc", "0000000", 100000, 20);
            persArray[4] = new Person("p5", Prof.programmer, "abc@abc.abc", "0000000", 100000, 30);

            for (int i = 0; i < persArray.Length; i++)
            {
                if (persArray[i].age > 40)
                {
                    persArray[i].ShowPersonInfo();
                }
            }
        }

        private static void GetDirectoryContent(string workDir, string reportFile)
        {
            foreach (var dir in Directory.GetDirectories(workDir))
            {
                GetDirectoryContent(dir, reportFile);
            }

            var content = Directory.GetFileSystemEntries(workDir);
            foreach (string str in content)
            {
                File.AppendAllText(reportFile, str + Environment.NewLine);
                //Console.WriteLine(str);
            }
        }
        
        private static void ControlMass(string[,] mas)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{mas[i,j]} ");
                }
                Console.WriteLine();
            }

            if (mas.Length != 16)
            {
                throw new MyArraySizeException();
            }

            try
            {
                int sum = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        try
                        {
                            sum += int.Parse(mas[i, j]);
                        }
                        catch
                        {
                            throw new MyArrayDataException(i, j);
                        }
                    }
                }
                Console.WriteLine($"Сумма массива : {sum}");
            }
            catch (MyArrayDataException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    class ToDo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDo()
        { }

        public ToDo(string title, bool isDone)
        {
            this.Title = title;
            this.IsDone = isDone;
        }
    }

    class MyArraySizeException : Exception
    {

    }

    class MyArrayDataException : Exception
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public MyArrayDataException(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
        public override string Message => $"Ошибка данных в ячейке {Row} {Col}.";
    }

    class Person
    {
        public string FIO;
        public Prof prof;
        public string email;
        public string phone;
        public decimal cost;
        public int age;

        public Person(string FIO, Prof prof, string email, string phone, decimal cost, int age)
        {
            this.FIO = FIO;
            this.prof = prof;
            this.email = email;
            this.phone = phone;
            this.cost = cost;
            this.age = age;
        }

        public void ShowPersonInfo()
        {
            Console.WriteLine($"{FIO} {prof} {email} {phone} {cost} {age}");
        }
    }

    enum Prof
    {
        Engineer,
        programmer,
        manager,
        constructor
    }
}
