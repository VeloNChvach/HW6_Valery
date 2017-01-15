using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_2
// Модифицировать программу нахождения минимума функции так, чтобы можно
// было передавать функцию в виде делегата. Сделать меню с различными
// функциями и представьте пользователю выбор для какой функции и на каком
// отрезке находить минимум
{
    class Program
    {
        public delegate double Func(double x);

        public static void Save(string fname, Func F, double a, double b, double h)
        {
            FileStream fs = new FileStream(fname, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (double i = a; i <= b; i+=h)
            {
                bw.Write(i);
                bw.Write(F(i));
            }
            bw.Close();
            fs.Close();
        }

        public static double[] Load(string fname)
        {
            FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            double[] data = new double[fs.Length / sizeof(double)];

            for (int i = 0; i < fs.Length / sizeof(double); i++)
                data[i] = br.ReadDouble();
            return data;
        }

        public static double FindMin(double[] data, double a, double b)
        {
            double min = data[1];
            for (int i = 0; i < data.Length - 1; i++)
                if (i % 2 == 0 && data[i] >= a && data[i] <= b && data[i + 1] < min)
                    min = data[i + 1];
            return min;
        }

        public static void Print(double[] data)
        {
            for (int i = 0; i < data.Length - 1; i += 2)
                Console.WriteLine($"arg: {data[i]}; F(x): {data[i + 1]}");
        }

        public static void  Choice(double a, double b, double step)
        {
            string fname = "data.txt";
            Console.WriteLine(@"Выберите функцию которая вам интересна:
1 - Sin
2 - Cos
3 - Tan
4 - Exp");
            switch (Console.ReadLine())
            {
                case "1":
                    Save(fname, Math.Sin, a, b, step);
                    break;
                case "2":
                    Save(fname, Math.Cos, a, b, step);
                    break;
                case "3":
                    Save(fname, Math.Tan, a, b, step);
                    break;
                case "4":
                    Save(fname, Math.Exp, a, b, step);
                    break;
            }
        }

        static void Main(string[] args)
        {
            Choice(-4, 4, 0.5); // перегрузка (начало, конец, шаг)
            // Сохраняем файл с значениями функции которые вы выберете
            double[] data = Load("data.txt");

            Print(data);

            double Min = FindMin(data, -1, 1);
            Console.WriteLine($"Минимальное значение функции: {Min}");
            Console.ReadKey();
        }
    }
}
