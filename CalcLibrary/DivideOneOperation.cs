using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    class DivideOneOperation : IOperation
    {
        public string Name { get { return "divide"; } }

        public double Calc(double x, double y)
        {
            return x / 2;
        }
    }
}
