using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Example - Adapter");

            IScientificCalc scientificCalc = new ScientificCalculator();
            double x = new Random().NextDouble() * 1000.0;
            double y = new Random().NextDouble() * 1000.0;
            PrintMathResults(scientificCalc, x, y);

            // THIS WILL NOT COMPILE!!
            // THIS WILL NOT COMPILE!!
            // THIS WILL NOT COMPILE!!
            // THIS WILL NOT COMPILE!!
            //ISimpleCalc simpleCalc = new SimpleCalculator();
            //int xInt = new Random().Next(1000);
            //int yInt = new Random().Next(1000);
            //PrintMathResults(simpleCalc, xInt, yInt);

            // BUT IF WE WILL USE THE ADAPTER - IT WILL WORK!
            // BUT IF WE WILL USE THE ADAPTER - IT WILL WORK!
            // BUT IF WE WILL USE THE ADAPTER - IT WILL WORK!
            // BUT IF WE WILL USE THE ADAPTER - IT WILL WORK!
            IScientificCalc adapterCalc = new AdapterCalc();
            int xInt = new Random().Next(1000);
            int yInt = new Random().Next(1000);
            PrintMathResults(adapterCalc, xInt, yInt);

        }

        static void PrintMathResults(IScientificCalc calculator, double x, double y)
        {
            Console.WriteLine(calculator.Add(x, y));

            Console.WriteLine(calculator.Sub(x, y));

            Console.WriteLine(calculator.Div(x, y));

            Console.WriteLine(calculator.Mul(x, y));
        }
    }
}
