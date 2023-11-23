// Made for testing by EmpMgmtTest
using System;
namespace EmpMgmtUI.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public void Deposit(double amt)
        {
            if (amt > 0)
            {
                Balance += amt;
            }
            else
                throw new InvalidOperationException();
        }

        public void Withdraw(double amt)
        {
            if (amt > Balance)
            {
                throw new Exception();
            }
            else if (Balance > 0)
            {
                Balance -= amt;
            }
            else
                throw new InvalidOperationException();
        }

        public double GetInterest()
        {
            if (Balance >= 100000)
                return Balance + Balance * 0.04;
            else
                return Balance;
        }
    }
}
