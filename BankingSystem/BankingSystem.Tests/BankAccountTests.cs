using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BankingSystem;

namespace BankingSystem.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void DepositShouldIncreaseBalance()
        {
            int id = 123;
            decimal amount = 500;
            BankAccount bankAccount = new BankAccount(id,amount);
            decimal depositAmount = 100;
            bankAccount.Deposit(depositAmount);
            Assert.AreEqual(depositAmount+amount, bankAccount.Balance);
        }
        [TestCase(123,500)]
        [TestCase(123, 500.7896)]
        [TestCase(123, 0)]
        public void ConstructorShouldSetBalanceCorrectly(int id, decimal amount)
        {
            BankAccount bankAccount = new BankAccount(id, amount);
            Assert.AreEqual(amount, bankAccount.Balance);
        }
        [Test]
        public void NegativeAmountShouldThrowInvalidOperateException()
        {
            {
                //Arange
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = -100;


                //Act and Assert
                Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));
            }
        }
        [Test]
        public void BalanceShouldThrowArgumentExceptionWhenAmountIsNegative()
        {
            {
                int id = 123;
                decimal amount = -100.123m;
                
                Assert.Throws<ArgumentException>(() => new BankAccount(id, amount));
            }
        }
        [Test]
        public void BalanceShouldThrowCurrentMessageWhenAmountIsNegative()
        {
            {
                int id = 123;
                decimal amount = -100.123m;
                string message = "Balance must be positive or zero";

                var ex = Assert.Throws<ArgumentException>(() => new BankAccount(id, amount));
                Assert.AreEqual(message, ex.Message);
            }
        }

        [Test]
        public void AccountInitializeWithPositiveValue()
        {
            BankAccount bankAccount = new BankAccount(123, 2000m);
            Assert.AreEqual(2000m, bankAccount.Balance);
        }
        [Test]
        public void ConstructorShouldSetZeroBalance()
        {
            int id = 123;
            BankAccount account = new BankAccount(id);
            Assert.AreEqual(0, account.Balance);
        }
        [Test]
        public void ConstructorShouldInitializeId()
        {
            int id = 123;
            BankAccount account = new BankAccount(id);
            Assert.AreEqual(id, account.Id);
        }
        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExceptionsWithMessage()
        {
            {
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = -100;

                var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));
                Assert.AreEqual(ex.Message, "Negative amount");
            }
        }

    }
}
