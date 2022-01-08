using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("State Pattern example");

            Context ctx = new Context(new IAmOff()); // starting as Off
            ctx.TurnOnRequest(); // turn on
            ctx.TurnOnRequest(); // do nothing. already on
            ctx.TurnOffRequest(); // turn off
            ctx.TurnOffRequest(); // break the switch ...
            ctx.TurnOnRequest(); // do nothing (broken)
            ctx.TurnOffRequest(); // do nothing (broken)
        }
    }
    public interface ILightState
    {
        ILightState TurnOn();

        ILightState TurnOff();
    }
    public class IAmOn: ILightState
    {
        public ILightState TurnOff()
        {
            Console.WriteLine("Turning off the light....");
            return new IAmOff();
        }

        public ILightState TurnOn()
        {
            Console.WriteLine("already on...");
            return this;
        }
    }
    public class IAmOff : ILightState
    {
        public ILightState TurnOff()
        {
            Console.WriteLine("Light is already off... now it is broken....");
            return new IAmBroken();
        }

        public ILightState TurnOn()
        {
            Console.WriteLine("Turning on the light!");
            return new IAmOn();
        }
    }
    public class IAmBroken : ILightState
    {
        public ILightState TurnOff()
        {
            Console.WriteLine("broken ... please call technician");
            return this;
        }

        public ILightState TurnOn()
        {
            Console.WriteLine("broken ... please call technician");
            return this;
        }
    }
    public class Context
    {
        private ILightState _state;
        public Context(ILightState state)
        {
            _state = state;
        }
        public void TurnOnRequest()
        {
            _state = _state.TurnOn();
        }

        public void TurnOffRequest()
        {
            _state = _state.TurnOff();
        }
    }
}
