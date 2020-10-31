using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingAppExceptions;

namespace BankingApp.Tests
{
    [TestClass()]
    public class BankAccountTests
    {

        [TestMethod()]
        public void Deposit_ValidAmount_BalanceIncreases()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount("Pleb", 100.00);
            double depositAmount = 50.00;
            double expectedBalance = 150.00;

            // Act 
            bankAccount.Deposit(depositAmount);
            double actualBalance = bankAccount.Balance;

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance);

        }

        [TestMethod()]
        public void Withdraw_ValidAmount_BalanceDecreases()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount("Pleb", 100.00);
            double withdawlAmmount = 50.00;
            double expectedBalance = 50.00;

            // Act
            bankAccount.Withdraw(withdawlAmmount);
            double actualBalance = bankAccount.Balance;

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance);
        }

       [TestMethod()]
       [ExpectedException(typeof(WithdrawAmountExceedsBalanceException))]
       public void Withdrawl_InvalidAmount_AmountExceedsBalance_ThrowException()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount("Pleb", 100.00);
            double withdrawAmount = 150;

            // Act 
            bankAccount.Withdraw(withdrawAmount);

            // Assert
            // Not needed because we are using the ExpectedException annotation

        }

        [TestMethod()]
        [ExpectedException(typeof(WithdrawAmountLessThanOrEqualToZeroException))]
        public void Withdrawl_InvalidAmount_AmountLessThanOrEqualToZero_ThrowException()
        {
            BankAccount bankAccount = new BankAccount("Pleb", 100.00);
            double withdrawAmount = 0.00;

            bankAccount.Withdraw(withdrawAmount);
        }

        [TestMethod()]
        [ExpectedException(typeof(WithdrawFromFrozenAccountException))]
        public void Withdrawl_InvalidAccount_AccountFrozen_ThrowException()
        {
            BankAccount bankAccount = new BankAccount("Pleb", 100.00);
            bankAccount.Freeze();
            double withdrawAmount = 0;

            bankAccount.Withdraw(withdrawAmount);

        }


    }
}