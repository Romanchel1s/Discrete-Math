using System;
namespace basdaun
{
    struct teacher
    {
        public string fio;
        public string birt;
        public string org;
        public string subject;
        public string[,] book;
        public teacher(string a, string b, string c, string d, string[,] f)
        {
            fio = a;
            birt = b;
            org = c;
            subject = d;
            book = f;
        }
        public void info()
        {
            Console.WriteLine($"{fio}\t{birt}\t{org}\t{subject}");
            for (int i = 0; i < book.GetLength(1); i++)
            {
                Console.WriteLine($"{book[i, 0]} | {book[i, 1]} | {book[i, 2]}");
            }
        }
        public static string[,] mass(int n)
        {
            string[,] m = new string[n, 3];
            for (int k = 0; k < n; k++)
            {
                Console.WriteLine("Введите дата начала");
                m[k, 0] = Console.ReadLine();
                Console.WriteLine("Введите дата конца");
                m[k, 1] = Console.ReadLine();
                Console.WriteLine("Введите org");
                m[k, 2] = Console.ReadLine();
            }
            return m;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string []data = "20.02.2023".Split('.');
            int startday = Convert.ToInt32(data[0]);
            int startmonth = Convert.ToInt32(data[1]);
            int startyear = Convert.ToInt32(data[2]);
            Console.WriteLine("Введите колво");
            int n = Convert.ToInt32(Console.ReadLine());
            teacher[] teachers = new teacher[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите фио");
                string a = Console.ReadLine();
                Console.WriteLine("Введите дату");
                string b = Console.ReadLine();
                Console.WriteLine("Введите орг");
                string c2 = Console.ReadLine();
                Console.WriteLine("Введите предмет");
                string d = Console.ReadLine();
                Console.WriteLine("Введите колво организаций");
                int l = Convert.ToInt32(Console.ReadLine());
                string[,] f = teacher.mass(l);
                teachers[i] = new teacher(a, b, c2, d, f);
            }


            //foreach (teacher teacher in teachers)
            //{
            //    teacher.info();
            //}


            //Console.WriteLine("Введите предмет");
            //var selectedTeachers = from t in teachers
            //                     where t.subject == Console.ReadLine()
            //                     select t;
            //foreach ( var person in selectedTeachers)
            //    Console.WriteLine($"{person.fio} - {person.subject}");


            Console.WriteLine("Введите стаж (в годах)");
            int c = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var c1 = teachers[i].book;
                string[] d = c1[c1.GetLength(0)-1, 0].Split('.');
                int days = Convert.ToInt32(d[0]);
                int months = Convert.ToInt32(d[1]);
                int years = Convert.ToInt32(d[2]);
                int count = (startday + startmonth * 30 + startyear * 365) - (days + months * 30 + years * 365);
                years = count / 360;
                months = (count % 360) / 30;
                days = months % 30;
                Console.WriteLine($"{teachers[i].fio}, стаж работы: {years} год, {months} месяц,{days} день");
            }
        }
    }
}