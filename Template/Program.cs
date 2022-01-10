using System;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Template Example.");
            // it is SIMPLY to create TEMPLATES....
            // it is SIMPLY to create TEMPLATES....
            // it is SIMPLY to create TEMPLATES....
            // it is SIMPLY to create TEMPLATES....
            // nothing more than it - just template to some process...

            Interview interview = new DevInterview();

            if (interview.PerformInterview() == true)
                Console.WriteLine("The candidate was hired for the job!");
            else
                Console.WriteLine("The candidate was rejected");
        }
    }

    public enum HRResult
    {
        Passed,
        Failed
    }

    public abstract class Interview
    {
        public abstract bool InitialInterview();
        public abstract int TechnicalQuiz();
        public abstract int Test();

        public HRResult HRInterview()
        {
            Console.WriteLine("Please fill you name, address, marial status...");
            return HRResult.Passed;
        }

        public bool PerformInterview()
        {
            if (InitialInterview() == false)
                return false;

            if (TechnicalQuiz() < 6)
                return false;

            if (Test() < 6)
                return false;

            if (HRInterview() == HRResult.Failed)
                return false;

            return true;
        }
    }

    public class DevInterview : Interview
    {
        public override bool InitialInterview()
        {
            string interviewer = "Dev Manager";
            Console.WriteLine("Hello, welcome to out company! My name is: " + interviewer);
            Console.WriteLine("Please tell us about yourself...");
            return true;
        }

        public override int TechnicalQuiz()
        {
            Console.WriteLine("What is binary serach?");
            Console.WriteLine("Calculate the complexity of this algorithm...");
            Console.WriteLine("Implement a singleton");
            return new Random().Next(10);
        }

        public override int Test()
        {
            string test = "Software development text";
            Console.WriteLine("Complete the test. good luck: " + test);
            return new Random().Next(10);
        }
    }

    public class QAInterview : Interview
    {
        public override bool InitialInterview()
        {
            string interviewer = "QA Manager";
            Console.WriteLine("Hello, welcome to out company! My name is: " + interviewer);
            Console.WriteLine("Please tell us about yourself...");
            return true;
        }

        public override int TechnicalQuiz()
        {
            Console.WriteLine("What is an automation?");
            Console.WriteLine("Write a test to check stability of a coin");
            Console.WriteLine("What issues can occur on a vending machine?");
            return new Random().Next(10);
        }

        public override int Test()
        {
            string test = "QA test";
            Console.WriteLine("Complete the test. good luck: " + test);
            return new Random().Next(10);
        }
    }
}
