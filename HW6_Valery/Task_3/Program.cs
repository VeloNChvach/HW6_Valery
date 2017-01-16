using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_3
{
    class Student
    {
        public string LastName;
        public string FirstName;
        public string Univercity;
        public string Faculty;
        public string Depertment;
        public int Age;
        public int Course;
        public int Group;
        public string City;

        public Student(string LastName, string FirstName, string Univercity, string Faculty, string Depertment, int Age, int Course, int Group, string City)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Univercity = Univercity;
            this.Faculty = Faculty;
            this.Course = Course;
            this.Depertment = Depertment;
            this.Group = Group;
            this.City = City;
            this.Age = Age;
        }
    }

    class Program
    {
        static List<Student> CreateStudentList()
        {
            List<Student> list = new List<Student>();
            StreamReader sr = new StreamReader("students_1.csv");

            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[5]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            sr.Close();
            return list;
        }

        static void Print(List<Student> list)
        {
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"{list[i].LastName}; {list[i].FirstName}; {list[i].Univercity}; {list[i].Faculty}; {list[i].Course}; {list[i].Depertment}; {list[i].Group}; {list[i].City}; {list[i].Age}");
        }

        static int sortAge(Student st1, Student st2)
        {
            return st1.Age.CompareTo(st2.Age);
        }

        static int countAge(List<Student> list)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
                if (list[i].Age >= 18 && list[i].Age <= 20)
                    count++;
            return count;
        }

        static void Main(string[] args)
        {
            Console.WindowWidth = 150;
            List<Student> list = CreateStudentList();
            // Сортировка по годам учеников
            list.Sort(new Comparison<Student>(sortAge));
            // Отображение сортированого листа
            Print(list);
            Console.WriteLine($"Количество студентов в возрасте от 18 до 20 лет: {countAge(list)}");
            Console.ReadKey();
        }
    }
}
