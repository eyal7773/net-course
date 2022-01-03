using System;

namespace factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Factory pattern example");
            /*
             *Sometimes we need to avoid the new keyword.
             *and construct class by another class.
             *we will build a class that it's mission will be
             *to be the factory for some type of objects.
             *
             **/

            // Look at this : 
            var myObject =  ObjectFactory.Create();
            var myObject1 = ObjectFactory.Create();
            var myObject2 = ObjectFactory.Create();
            var myObject3 = ObjectFactory.Create());
            // The problem :
            // if I want to swap this to other type,
            // I can't because I hard coded it to this type.
            // How can we make it less evil ? 

            // So we can use another class, to bring us
            // the desired object :
            var myNewObject = ObjectFactory.Create();

            // but.... what so good about it ? 
            // it seems that we just move code around.
            // why is it good ? 

            // BUT , there are 2 benefits : 
            // 1) future changes in the way we construct the object
            //    are centrally located in the factory class.
            
            // Example - add argument to constructor. =====> step 2
            // (I created new version of the classes)

            var myObject_1 = ObjectFactory_1.Create();

            //
            // 2 ) what if we have more than 1 business object type ? 
            //
            //  let's add an abstraction. ======> step 3

            IBuisnessThing myObject_3 = ObjectFactory_3.Create();
            myObject_3.SomethingIntersting();

            // ^^^^ The factory now produce the abstraction,
            //      So we can do logic to return what we needed.
            // so if the boss come and say that now we have 
            // SecondConcreteBuisnessObject , that also implement IBuisnessThing 
            // So we can change the Factory class to create the corect object
            // each time. ====> see step 4 COMMENTED inside 3

            // We can also put the configuration inside 
            // enviorment, or setting-file,
            // and we don't need to deal with new version...

            // WHAT NOT TO DO ? 
            // 1. don't wrap build in .net methods in a factory - it's sealy!
            //      For example - don't wrap StringBuilder or List<T> with Factory.

            // 2. Don't use factory for simple objects (DTOs...).

            // What GOOD to do ?
            // Any external dependency - need abstraction. (i.e. file, DB).
            // Why ? to make things testable, and replaceable.


            // Last issue - Fatocy method.

        }
    }

    public class ConcreteBuisnessObject
    {
        public ConcreteBuisnessObject(string name)
        {

        }
    } 

    public static class ObjectFactory
    {
        public static ConcreteBuisnessObject Create()
        {
            return new ConcreteBuisnessObject("Moshe");
        }
    }

    /// =======================================================
    /// ===================== step 2 ==========================
    /// =======================================================
    public class ConcreteBuisnessObject_1
    {
        public ConcreteBuisnessObject_1(string name)
        {

        }
    }
    public static class ObjectFactory_1
    {
        public static ConcreteBuisnessObject_1 Create()
        {
            return new ConcreteBuisnessObject_1("Moshe");
        }
    }
    /// =======================================================
    /// =================== step 3 ============================
    /// =======================================================
    public interface IBuisnessThing
    {
        void SomethingIntersting();
    }

    public class ConcreteBuisnessObject_3 : IBuisnessThing
    {
        public ConcreteBuisnessObject_3(string name)
        {
            
        }

        public void SomethingIntersting()
        {
            
        }
    }

    public static class ObjectFactory_3
    {
        public static IBuisnessThing Create()
        {
            return new ConcreteBuisnessObject_3("Moshe");
            // step 4
            //var someSetting = true;
            //if (someSetting)
            //{
            //    return new ConcreteBuisnessObject_3("Moshe");
            //}
            //else
            //{
            //    return new SecondConcreteBuisnessObject("bzzzzz");
            //}
        }
    }

    /// =======================================================
    /// =================== step 4 ============================
    /// =======================================================
    public class SecondConcreteBuisnessObject : IBuisnessThing
    {
        public SecondConcreteBuisnessObject(string name)
        {

        }

        public void SomethingIntersting()
        {

        }
    }
}
