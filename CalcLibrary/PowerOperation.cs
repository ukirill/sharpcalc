using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    class PowerOperation : IOperationArgs
    {
        public string Name
        {
            get { return "power"; }
        }

        public double Calc(IEnumerable<object> args)
        {
            return args.Select(o => double.Parse(o.ToString()))
                .Aggregate((res, next) => Math.Pow(res, next));
        }

        public double Calc(double x, double y)
        {
            return Math.Pow(x, y);
        }
    }
}
