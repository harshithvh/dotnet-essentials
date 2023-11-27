using System;

namespace InterfaceDemo
{
    class Account
    {
        public int Id { get; set; }
    }
    // Two interfaces
    interface IAccount
    {
        // Two functions and one property
        // there is no need to implement the body, classes using these interfaces shd implement them
        void Deposit(double amt);
        void Withdraw(double amt);

        double Balance { get; set; }

    }

    interface IOverdraft
    {
        void Overdraft(double amt);
    }

    // SBAccount must strictly implement all the methods and property of interface IAccount
    // Observe that the body of the interface is implemented here
    class SBAccount : Account, IAccount
    {
        public SBAccount() { }

        public double Balance { get; set; }

        public void Deposit(double amt)
        {
            Console.WriteLine("Depositing {0} into sb account {1}", amt, Id);
        }

        public void Withdraw(double amt)
        {
            string msg = $"Withdraw {amt} from sb account {Id}";
            Console.WriteLine(msg);
        }
    }

    class SalaryAccount : Account, IOverdraft, IAccount
    {

        public SalaryAccount()
        {

        }
        //auto prop proc
        public double Balance { get; set; }

        public void Deposit(double amt)
        {
            Console.WriteLine("Depositing {0} into salary account {1}", amt, Id);
        }

        public void Overdraft(double amt)
        {
            string msg = $"Overdrafting {amt} from salary account {Id}";
            Console.WriteLine(msg);
        }

        public void Withdraw(double amt)
        {
            string msg = $"Withdraw {amt} from salary account {Id}";
            Console.WriteLine(msg);
        }
    }

    class Bank
    {
        public void Transfer(IAccount ac1, IAccount ac2)
        {
            ac1.Deposit(1000);
            ac2.Withdraw(1000);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // This cannot be done when using an interface
            //IAccount ac = new IAccount();
            Bank bank = new Bank();

            SBAccount ac1 = new SBAccount();
            ac1.Id = 11111;
            ac1.Balance = 10000;

            SalaryAccount ac2 = new SalaryAccount();
            ac2.Id = 3434343;
            ac2.Balance = 2000;

            //bank.Transfer(ac1, ac2);
            ac1.Deposit(1000);
            ac2.Withdraw(1000);
        }
    }
}
