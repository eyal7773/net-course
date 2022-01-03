using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class BillHandler200 : BillHandler
    {

        public override void HandleRequest(int amount)
        {
            if (amount >= 200)
            {
                Console.WriteLine("Giving 200 X " + amount / 200);
            } 
            
            if (amount % 200 > 0)
            {
                if (next != null)
                {
                    next.HandleRequest(amount % 200);
                }
            }
        }
    }
    public class BillHandler100 : BillHandler
    {

        public override void HandleRequest(int amount)
        {
            if (amount >= 100)
            {
                Console.WriteLine("Giving 100 X " + amount / 100);
            }

            if (amount % 100 > 0)
            {
                if (next != null)
                {
                    next.HandleRequest(amount % 100);
                }
            }
        }
    }
    public class BillHandler50 : BillHandler
    {

        public override void HandleRequest(int amount)
        {
            if (amount >= 50)
            {
                Console.WriteLine("Giving 50 X " + amount / 50);
            }

            if (amount % 50 > 0)
            {
                if (next != null)
                {
                    next.HandleRequest(amount % 50);
                }
            }
        }
    }

    public class BillHandler20 : BillHandler
    {

        public override void HandleRequest(int amount)
        {
            if (amount >= 20)
            {
                Console.WriteLine("Giving 20 X " + amount / 20);
            }

            if (amount % 20 > 0)
            {
                if (next != null)
                {
                    next.HandleRequest(amount % 20);
                }
            }
        }
    }
}
