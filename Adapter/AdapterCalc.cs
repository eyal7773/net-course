using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class AdapterCalc : IScientificCalc
    {
        private ISimpleCalc _simpleCalc = new SimpleCalculator();
        public double Add(double x, double y)
        {
            return _simpleCalc.Add((int)x, (int)y);
        }

        public double Div(double x, double y)
        {
            return _simpleCalc.Div((int)x, (int)y);
        }

        public double Mul(double x, double y)
        {
            return _simpleCalc.Mul((int)x, (int)y);
        }

        public double Sub(double x, double y)
        {
            return _simpleCalc.Sub((int)x, (int)y);
        }
    }
}
