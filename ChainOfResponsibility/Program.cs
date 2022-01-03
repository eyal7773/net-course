using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chain of resposibility");
            BillHandler bill200 = new BillHandler200();
            BillHandler bill100 = new BillHandler100();
            BillHandler bill50 = new BillHandler50();
            BillHandler bill20 = new BillHandler20();

            bill200.SetNext(bill100);
            bill100.SetNext(bill50);
            bill50.SetNext(bill20);
            bill20.SetNext(null);

            // Use cases
            Console.WriteLine("770");
            bill200.HandleRequest(770);

            Console.WriteLine("100");
            bill200.HandleRequest(100);

            Console.WriteLine("210");
            bill200.HandleRequest(210);

            // if there are no more 100 bills
            bill200.SetNext(bill50);
            Console.WriteLine("Now, no more of 100 ");
            bill200.HandleRequest(770);

        }
    }
}
