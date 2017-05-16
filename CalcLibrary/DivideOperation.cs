using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    class DivideOperation : IOperationArgs
    {
        public string Name
        {
            get { return "divide"; }
        }

        public double Calc(double x, double y)
        {
            return y == 0 ? Double.NaN : x * 1d / y;
        }

        public double Calc(IEnumerable<object> args)
        {
            return args.Select(o => double.Parse(o.ToString()))
                .Aggregate((res, next) => res / next); 
        }


    }
}
