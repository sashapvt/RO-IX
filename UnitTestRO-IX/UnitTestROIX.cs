using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RO_IX;

namespace UnitTestRO_IX
{
    [TestClass]
    public class UnitTestROIX

    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            Project Proj = new Project();
            Calculate Calc = new Calculate(Proj);

            // act


            // assert
            //double actual = account.Balance;
            Assert.AreEqual(1, 1, "OK");
            //Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
    }
}
