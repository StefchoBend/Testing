using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BankingSystem.Tests
{
    public class BankAccountTests
    {
        public void DepositShouldIncreaseBalance()
        {
            BankAccount bankAccount = new BankAccount(123);
            decimal depositAmount = 100;
            bankAccount.Deposit(depositAmount);
            Assert.AreEqual(depositAmount, bankAccount.Balance);
        }
        public void AccountInicializeWithPositiveValue()
        {
            BankAccount bankAccount = new BankAccount(123, 2000m);
            Assert.AreEqual(2000m, bankAccount.Balance);
        }
    }
}
