using System;
using System.Collections.Generic;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Meidator Pattern example.");

            IChatMediator mediator = new ChatMediator();

            IUser moshe = new User(mediator, "Moshe");
            IUser haim = new User(mediator, "Haim");
            IUser ronen = new User(mediator, "Ronen");

            mediator.RegisterUser(moshe);
            mediator.RegisterUser(haim);
            mediator.RegisterUser(ronen);

            moshe.Send("Hello everyone!");
            haim.Send("What's up?");
        }

    }
    public interface IUser
    {
        void Send(string message);
        void Receive(string message);
    }
    public class User : IUser
    {
        private IChatMediator mediator;
        private string name;

        public User(IChatMediator mediator, string name)
        {
            this.mediator = mediator;
            this.name = name;
        }

        public void Receive(string message)
        {
            Console.WriteLine(this.name + ": Received Message:" + message);
        }

        public void Send(string message)
        {
            Console.WriteLine(this.name + ": Sending Message: " + message + "\n");
            mediator.SendMessage(message, this);
        }
    }

    public interface IChatMediator
    {
        void SendMessage(string msg, IUser user);
        void RegisterUser(IUser user);
    }
    public class ChatMediator : IChatMediator
    {
        private List<IUser> usersList = new List<IUser>();

        public void RegisterUser(IUser user)
        {
            usersList.Add(user);
        }

        public void SendMessage(string message, IUser user)
        {
            foreach (IUser u in usersList)
            {
                // message should not be received by the user sending it.
                if (u != user)
                {
                    u.Receive(message);
                }
            }
        }
    }

}
