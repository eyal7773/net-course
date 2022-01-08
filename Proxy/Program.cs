using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Proxy Example");
            
            // Regular usage 
            Car myCar = new Car();
            myCar.OpenDoor();
            myCar.Drive();
            myCar.Stop();


            // Rescue usage 
            IRescue carProxy = new CarProxy(myCar);

            Rescue(carProxy);
        }

        static void Rescue(IRescue carProxy)
        {
            GPS carGps = carProxy.GetLocation();
            float gas = carProxy.GetGasReport();

            // ... send rescue
        }
    }
    public interface ICar
    {
        void OpenDoor();
        void CloseDoor();
        void Drive();
        void Stop();
        void Reverse();
    }

    public interface IRescue
    {
        GPS GetLocation();
        float GetGasReport();
        void StartRepair();
        void EndRepair();
    }
    public class GPS
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class Car : ICar,IRescue
    {
        private GPS gps;

        private float gas;

        public void CloseDoor()
        {
            // ...
        }

        public void Drive()
        {
            // ...
        }

        public void EndRepair()
        {
            // ...
        }

        public float GetGasReport()
        {
            return gas;
        }

        public GPS GetLocation()
        {
            return gps;
        }

        public void OpenDoor()
        {
            // ...
        }

        public void Reverse()
        {
            // ...
        }

        public void StartRepair()
        {
            // ...
        }

        public void Stop()
        {
            // ...
        }
    }

    public class CarProxy : IRescue
    {
        private Car real_car;

        public CarProxy(Car real_car)
        {
            this.real_car = real_car;
        }

        public void EndRepair()
        {
            real_car.EndRepair();
        }

        public float GetGasReport()
        {
            return real_car.GetGasReport();
        }

        public GPS GetLocation()
        {
            return real_car.GetLocation();
        }

        public void StartRepair()
        {
            real_car.StartRepair();
        }
    }
}
