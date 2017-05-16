using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    class SumOperation : IOperationArgs
    {
        public string Name
        {
            get { return "sum"; }
        }

        public double Calc(IEnumerable<object> args)
        {
            return args.Select(o => double.Parse(o.ToString()))
                .Aggregate((res, next) => res + next);
        }

        public double Calc(double x, double y)
        {
            return x + y;
        }
    }
}
