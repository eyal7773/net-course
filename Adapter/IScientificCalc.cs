using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    interface IScientificCalc
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Div(double x, double y);
        double Mul(double x, double y);
    }
}
