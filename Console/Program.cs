using CalcLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Output = System.Console;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Calc();

            string x, y, operation;
            double result = 0;

            try
            {
                x = args[0];
                y = args[1];
                operation = args[2];
                result = (double)test.Execute(args[2], new object[] { x, y });
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Возможно, неверные параметры");
                return;
            }
            System.Console.WriteLine($"{x} {operation} {y} = {result}");
        }
    }
}
