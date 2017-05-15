using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    class SumOperation : IOperation
    {
        public string Name
        {
            get { return "sum"; }
        }

        public double Calc(double x, double y)
        {
            return x + y;
        }
    }
}
