using NUnit.Framework;
using System;

namespace TDDBank.Tests
{
    [TestFixture]
    public class BankAccountTests
    {

        [Test]
        public void BankAccount_new_Account_should_have_zero_balance()
        {
            var ba = new BankAccount();

            Assert.AreEqual(0m, ba.Balance);
        }

        [Test]
        public void BankAccount_can_deposit()
        {
            var ba = new BankAccount();

            ba.Deposit(12m);
            ba.Deposit(4m);

            Assert.AreEqual(16m, ba.Balance);
        }

        [Test]
        public void BankAccount_deposit_should_not_be_a_negative_value()
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Deposit(-4.5m));

            Assert.Throws<ArgumentException>(() => ba.Deposit(0m));

        }

        [Test]
        public void BankAccount_can_withdraw()
        {
            var ba = new BankAccount();

            ba.Deposit(20m);

            ba.Withdraw(5m);

            Assert.AreEqual(15m, ba.Balance);
        }

        [Test]
        public void BankAccount_withdraw_should_not_be_a_negative_value()
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Withdraw(-4.5m));

            Assert.Throws<ArgumentException>(() => ba.Withdraw(0m));
        }

        [Test]
        public void BankAccount_withdraw_balance_should_not_be_below_zero()
        {
            var ba = new BankAccount();

            ba.Deposit(12m);

            Assert.Throws<InvalidOperationException>(() => ba.Withdraw(20m));
        }

    }
}
