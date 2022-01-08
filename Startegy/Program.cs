using System;
using System.Collections.Generic;

namespace Startegy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Strategy Pattern example.");

            // JUST FOR EXAMPLE
            // I SET THE SMALL SCALE SORTER TO ASC
            // AND THE LARGE TO DESC.

            ListManager listManager = new ListManager();

            listManager.AddNumber(1);
            listManager.AddNumber(2);
            listManager.Sort(); // small sacle
            Console.WriteLine("Numbers after small scale ----");
            listManager.PrintNumbers();

            listManager.AddNumber(3);
            listManager.AddNumber(4);
            listManager.AddNumber(1001);
            // ...
            Console.WriteLine("Numbers after large scale ----");
            listManager.Sort(); // large sacle
            listManager.PrintNumbers();
        }
    }

        public interface ISort
        {
            void Sort(List<int> numbers);
        }

        public class SmallScaleSorter : ISort
        {
            public void Sort(List<int> numbers)
            {
                numbers.Sort();
            }
        }
        public class LargeScaleSorter : ISort
        {
            public void Sort(List<int> numbers)
            {
                numbers.Reverse();
            }
        }
    public class ListManager
    {
        private ISort _sorter = new SmallScaleSorter(); // Start with the small sorter.
        private List<int> _numbers = new List<int>();
        private const int LIST_THREASHOLD = 3;

        public ListManager()
        {
        }
        public void AddNumber(int item)
        {
            _numbers.Add(item);
            if(_numbers.Count>= LIST_THREASHOLD)
            {
                _sorter = new LargeScaleSorter();
            }
        }
        public void RemoveNumber(int item)
        {
            _numbers.Remove(item);
            if (_numbers.Count < LIST_THREASHOLD)
            {
                _sorter = new SmallScaleSorter();
            }
        }
        public void Sort()
        {
            _sorter.Sort(_numbers);
        }
        public void PrintNumbers()
        {
            _numbers.ForEach(x => Console.Write($"{x},"));
            Console.WriteLine("------");
        }
    }
}
