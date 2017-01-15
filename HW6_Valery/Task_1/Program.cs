using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_Valery
// Изменить программу вывода функции так, чтобы можно было передавать
// функции типа double(double, double). Продемонстрировать работу функции
// с функцией a*x^2 и функцией a*sin(x)
{
    public delegate double Func(double x, double a);

    class Program
    {
        public static void Table(Func F, double a, double x, double b)
        {
            Console.WriteLine("------X-----Y------");
            while (x <= b)
            {
                Console.WriteLine($"|{x,8:0.000}|{F(x, a),8:0.000}|");
                x += 1;
            }
            Console.WriteLine("-------------------");
        }

        public static double MyFunc1(double x, double a)
        {
            return a * Math.Pow(x, 2);
        }

        public static double MyFunc2(double x, double a)
        {
            return a * Math.Sin(x);
        }

        static void Main(string[] args)
        {
            // MyFunc1 - a*x*x
            // MyFunc2 - a*Sin(x)
            Table(MyFunc1, 5, -5, 5);

            Console.ReadKey();
        }
    }
}
