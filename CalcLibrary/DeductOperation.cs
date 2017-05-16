using CalcLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    class DeductOperation : IOperationArgs
    {
        public string Name
        {
            get { return "deduct"; }
        }

        public double Calc(double x, double y)
        {
            return x - y;
        }

        public double Calc(IEnumerable<double> args)
        {
            return 0;
        }
    }
}
