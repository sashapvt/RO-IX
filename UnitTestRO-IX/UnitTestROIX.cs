using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RO_IX;

namespace UnitTestRO_IX
{
    [TestClass]
    public class UnitTestROIX

    {
        [TestMethod]
        public void TestMethodCalc()
        {
            // arrange
            Project Proj = new Project();
            Proj.New();
            Calculate Calc = new Calculate(Proj);

            // act


            // assert
            Assert.AreEqual(0.0204, Calc.BoilerBlowdownRO, 0.00001, "BoilerBlowdownRO - incorrect value.");
            Assert.AreEqual(0.0997, Calc.BoilerBlowdownIX, 0.00001, "BoilerBlowdownIX - incorrect value.");
        }
    }
}
