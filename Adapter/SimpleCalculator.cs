using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class SimpleCalculator : ISimpleCalc
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Div(int x, int y)
        {
            return x / y;
        }

        public int Mul(int x, int y)
        {
            return x * y;
        }

        public int Sub(int x, int y)
        {
            return x - y;
        }
    }
}
