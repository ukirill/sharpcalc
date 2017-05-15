using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    class PowerOperation : IOperation
    {
        public string Name
        {
            get { return "power"; }
        }

        public double Calc(double x, double y)
        {
            return Math.Pow(x, y);
        }
    }
}
