﻿using System;
namespace menu
{
    class teacher
    {
        string fio;
        string birt;
        string org;
        string subject;
        string[,] book;
        static int n;
        static teacher[] teachers;
        public teacher(string fio, string birt, string org, string subject, string[,] book)
        {
            this.fio = fio;
            this.birt = birt;
            this.org = org;
            this.subject = subject;
            this.book = book;
        }
        static void Main()
        {
            bool rgrka = true;
            while (rgrka)
            {
                rgrka = MainMenu();
            }
        }
        public static bool MainMenu()
        {

            Console.Clear();
            Console.WriteLine("Меню");
            Console.WriteLine("1) Добавить учителя");
            Console.WriteLine("2) Выбрать учителей по предмету");
            Console.WriteLine("3) Выбрать учителей по стажу работы в последней организации");
            Console.WriteLine("4) Показать всех учителей");
            Console.WriteLine("5) Показать общий стаж работы всех учителей");
            Console.WriteLine("6) Выход");
            Console.Write("\r\nВыберите действие: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Hello();
                    return true;
                case "2":
                    if (n > 0)
                    {
                        subjects();
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("В базе данных нет учителей");
                        return false;
                    }
                case "3":
                    if (n > 0)
                    {
                        work();
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("В базе данных нет учителей");
                        return false;
                    }
                case "4":
                    if (n > 0)
                    {
                        info();
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("В базе данных нет учителей");
                        return false;
                    }
                case "5":
                    if (n > 0)
                    {
                        all_time();
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("В базе данных нет учителей");
                        return false;
                    }

                case "6":
                    return false;
                default:
                    return true;
            }
        }
        public static void Hello()
        {
            Console.Clear();
            Console.WriteLine("Введите колво");
            n = Convert.ToInt32(Console.ReadLine());
            teachers = new teacher[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите фио");
                string a = Console.ReadLine();
                Console.WriteLine("Введите дату рождения(день.месяц.год)");
                string b = Console.ReadLine();
                Console.WriteLine("Введите орг");
                string c = Console.ReadLine();
                Console.WriteLine("Введите предмет");
                string d = Console.ReadLine();
                Console.WriteLine("Введите колво организаций");
                int l = Convert.ToInt32(Console.ReadLine());
                string[,] f = mass(l);
                teachers[i] = new teacher(a, b, c, d, f);
                Console.Clear();
            }
            Console.Write("\r\nНажмите Enter, чтобы вернуться в главное меню");
            Console.ReadLine();
        }
        public static void subjects()
        {
            Console.Clear();
            Console.Write("По какому предмету выбрать учителей? ");
            string f = Console.ReadLine();
            foreach (teacher teacher in teachers)
            {
                if (f == teacher.subject) Console.WriteLine(teacher.fio);
            }
            Console.Write("\r\nНажмите Enter, чтобы вернуться в главное меню");
            Console.ReadLine();
        }
        public static void work()
        {
            Console.Clear();
            Console.Write("Введите сколько должен работать учитель в формате лет,месяцев,дней ");
            string f = Console.ReadLine();
            string[] data = f.Split(',');
            foreach (teacher teacher in teachers)
            {
                string[] data1 = teacher.book[teacher.book.GetLength(0) - 1, 0].Split('.');
                string[] data2 = teacher.book[teacher.book.GetLength(0) - 1, 2].Split('.');
                int dat = Convert.ToInt32(data[0]) * 360 + Convert.ToInt32(data[1]) * 30 + Convert.ToInt32(data[2]);
                int dat1 = Convert.ToInt32(data1[2]) * 360 + Convert.ToInt32(data1[1]) * 30 + Convert.ToInt32(data1[0]);
                int dat2 = Convert.ToInt32(data2[2]) * 360 + Convert.ToInt32(data2[1]) * 30 + Convert.ToInt32(data2[0]);
                if (dat == dat2 - dat1) Console.WriteLine(teacher.fio);
            }
            Console.Write("\r\nНажмите Enter, чтобы вернуться в главное меню");
            Console.ReadLine();
        }
        public static void all_time()
        {
            Console.Clear();
            foreach (teacher teacher in teachers)
            {
                string[] first_time = teacher.book[0, 0].Split('.');
                string[] last_time = teacher.book[teacher.book.GetLength(0)-1, 2].Split('.');
                int all_time = (Convert.ToInt32(last_time[2]) * 365 + Convert.ToInt32(last_time[1]) * 30 + Convert.ToInt32(last_time[0])) - (Convert.ToInt32(first_time[2]) * 365 + Convert.ToInt32(first_time[1]) * 30 + Convert.ToInt32(first_time[0]));
                int years = all_time / 365;
                int months = (all_time % 365)/30;
                int days = months % 30;
                Console.WriteLine($"{teacher.fio} общий стаж:{years}г. {months}м. {days}д.");

            }
            Console.Write("\r\nНажмите Enter, чтобы вернуться в главное меню");
            Console.ReadLine();
        }
        public static void info()
        {
            Console.Clear();
            foreach (teacher teacher in teachers)
            {
                Console.WriteLine(teacher.fio);
            }
            Console.Write("\r\nНажмите Enter, чтобы вернуться в главное меню");
            Console.ReadLine();
        }
        public static string[,] mass(int l)
        {
            string[,] m = new string[l, 3];
            for (int k = 0; k < l; k++)
            {
                Console.WriteLine("Введите дату поступления(день.месяц.год)");
                m[k, 0] = Console.ReadLine();
                Console.WriteLine("Введите организацию");
                m[k, 1] = Console.ReadLine();
                Console.WriteLine("Введите дату увольнения(день.месяц.год)");
                m[k, 2] = Console.ReadLine();
            }
            return m;
        }
    }
}
