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

            double x, y;
            double.TryParse(args[0], System.Globalization.NumberStyles.Any,
                CultureInfo.InvariantCulture, out x);
            double.TryParse(args[1], System.Globalization.NumberStyles.Any,
                CultureInfo.InvariantCulture, out y);

            var operation = args[2];

            double result = 0;
            result = (double)test.Execute(args[2], new object[] { x, y }) ;
            System.Console.WriteLine($"{x} {operation} {y} = {result}");
        }
    }
}
