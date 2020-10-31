using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingAppExceptions;

namespace BankingApp
{
    public class BankAccount
    {
        public string CustomerName { get; private set; }
        public double Balance { get; private set; }

        public bool IsFrozen { get; private set; }


        public BankAccount(string customerName, double balance)
        {
            CustomerName = customerName;
            Balance = balance;
            IsFrozen = false;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (IsFrozen)
                throw new WithdrawFromFrozenAccountException();

            if (amount > Balance)
                throw new WithdrawAmountExceedsBalanceException();


            if (amount <= 0)
                throw new WithdrawAmountLessThanOrEqualToZeroException();

            Balance -= amount; // bug fixed
        }

        public void Freeze()
        {
            IsFrozen = true;
        }

    }
}
