using System;
using System.Threading;

namespace singelton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var instance = Singelton.GetInstance();
            instance.SomeMethod();
            

            // Proof that it's a single instance.

            Thread.Sleep(1000);
            
            // For stage 1 - proof
            var otherVar = Singelton.GetInstance();
            otherVar.SomeMethod();


            //// for stage 2 - multi thread singelton
            //var mtInstance = SingeltonWithHandlingMultiThread.GetInstance();
            //mtInstance.SomeMethod();

            //// For stage 3 - explain the lock optiomization
            //var ins3 = LockOptimaizedSingelton.GetInstance();
            //ins3.SomeMethod();

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }

    class Singelton
    {
        // PRIVATE CONSTRUCTOR!!!!
        // PRIVATE CONSTRUCTOR!!!!
        // PRIVATE CONSTRUCTOR!!!!
        private Singelton()
        {

        }

        private long TimeStamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        // THE INSTANCE IS ALSO PRIVATE!
        private static Singelton instance;

        // You can get the single instance only from here.
        public static Singelton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singelton();
            }
            return instance;
        }

        public void SomeMethod()
        {
            Console.WriteLine($"timestamp is {TimeStamp}");
        }
    }

    /// ===========================================================================
    /// ===========================================================================
    /// ===========================================================================
    /// ===========================================================================
    /// ===========================================================================
    class SingeltonWithHandlingMultiThread
    {
        private SingeltonWithHandlingMultiThread()
        {
        }

        private static SingeltonWithHandlingMultiThread instance;

        // WE ADD LOCK TO HANDLE MULTI THREADS
        // WE ADD LOCK TO HANDLE MULTI THREADS
        // WE ADD LOCK TO HANDLE MULTI THREADS
        // WE ADD LOCK TO HANDLE MULTI THREADS
        private static readonly object lockObject = new object();


        
        public static SingeltonWithHandlingMultiThread GetInstance()
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new SingeltonWithHandlingMultiThread();
                }
            }
            return instance;
        }

        public void SomeMethod()
        {
            Console.WriteLine("Bli bli SingeltonWithHandlingMultiThread");
        }
    }



    /// ===========================================================================
    /// ===========================================================================
    /// ===========================================================================
    /// ===========================================================================
    /// ===========================================================================


    class LockOptimaizedSingelton
    {
        private LockOptimaizedSingelton()
        {
        }

        private static LockOptimaizedSingelton instance;
        private static readonly object lockObject = new object();



        public static LockOptimaizedSingelton GetInstance()
        {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance = new LockOptimaizedSingelton();
                    }
                }
            return instance;
        }

        public void SomeMethod()
        {
            Console.WriteLine("mmmm mmmm LockOptimaizedSingelton");
        }
    }
}
