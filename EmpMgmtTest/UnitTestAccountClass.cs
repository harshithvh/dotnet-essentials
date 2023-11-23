using EmpMgmtUI.Models;
using NUnit.Framework;
using System;

namespace EmpMgmtTest
{
    [TestFixture] //  [TestFixture] attribute is used to indicate that a class contains one or more test methods
    public class UnitTestAccountClass
    {
        Account account;

        [SetUp] // acts like a constructor
        public void MySetup()
        {
            account = new Account();
            account.Id = 1;
            account.Name = "Test";
            account.Balance = 100000;

        }

        [Test]
        public void Account_Deposit_Amount_Gt_0_Adds_Amount_ToBalance()
        {
            //Arrange

            //Act
            account.Deposit(10000);

            //Assert

            double actbalance = 110000;
            double availbalance = account.Balance;

            Assert.IsInstanceOf(typeof(Account), account); // is variable account of type Account
            Assert.IsNotNull(account); // Is the account object NULL

            Assert.AreEqual(actbalance, availbalance);
        }

        [Test]
        public void Account_Deposit_Amount_LtE_0_Throws_Exception()
        {
            //arrange not required

            //Assert
            Assert.Throws<InvalidOperationException>(() => account.Deposit(0));
        }

        [Test]
        public void Account_GetInterest_Amount_Eq_1Lakh_Return_4percent_interest()
        {
            //arrange not required
            //act
            double actinterest = account.GetInterest();
            double expected = 104000;

            //Assert
            Assert.AreEqual(expected, actinterest);
        }

    }
}