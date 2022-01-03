using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class ScientificCalculator : IScientificCalc
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Div(double x, double y)
        {
            return x / y;
        }

        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }
    }
}
