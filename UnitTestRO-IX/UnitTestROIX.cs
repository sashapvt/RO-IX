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
            // Ініціалізація
            Project Proj = new Project();
            Proj.New();
            Calculate Calc = new Calculate(Proj);
            Calc.CalculateProductivity();

            // Базовий разрахунок (без повернення конденсату)
            // Перевірка розрахунку проекту
            // Водно-хімічний режим
            Assert.AreEqual(0.0204, Calc.BoilerBlowdownRO, 0.00001, "BoilerBlowdownRO - incorrect value.");
            Assert.AreEqual(0.0997, Calc.BoilerBlowdownIX, 0.00001, "BoilerBlowdownIX - incorrect value.");
            Assert.AreEqual(0.21, Calc.BoilerBlowdownFlowRO, 0.01, "BoilerBlowdownFlowRO - incorrect value.");
            Assert.AreEqual(1.1, Calc.BoilerBlowdownFlowIX, 0.01, "BoilerBlowdownFlowIX - incorrect value.");
            Assert.AreEqual(0.05, Calc.BoilerBlowdownSteamRO, 0.01, "BoilerBlowdownSteamRO - incorrect value.");
            Assert.AreEqual(0.29, Calc.BoilerBlowdownSteamIX, 0.01, "BoilerBlowdownSteamIX - incorrect value.");
            Assert.AreEqual(35.58, Calc.BoilerBlowdownPowerRO, 0.01, "BoilerBlowdownPowerRO - incorrect value.");
            Assert.AreEqual(187.36, Calc.BoilerBlowdownPowerIX, 0.01, "BoilerBlowdownPowerIX - incorrect value.");
            Assert.AreEqual(3.82, Calc.BoilerBlowdownGasRO, 0.01, "BoilerBlowdownGasRO - incorrect value.");
            Assert.AreEqual(20.14, Calc.BoilerBlowdownGasIX, 0.01, "BoilerBlowdownGasIX - incorrect value.");
            Assert.AreEqual(33.66, Calc.BoilerBlowdownMoneyRO, 0.01, "BoilerBlowdownMoneyRO - incorrect value.");
            Assert.AreEqual(177.21, Calc.BoilerBlowdownMoneyIX, 0.01, "BoilerBlowdownMoneyIX - incorrect value.");
            Assert.AreEqual(147412, Calc.BoilerBlowdownMoneyAnnualRO, 1, "BoilerBlowdownMoneyAnnualRO - incorrect value.");
            Assert.AreEqual(776171, Calc.BoilerBlowdownMoneyAnnualIX, 1, "BoilerBlowdownMoneyAnnualIX - incorrect value.");
            // Водопідготовка
            Assert.AreEqual(13.89, Proj.OptionsRORawProductivity, 0.01, "OptionsRORawProductivity - incorrect value.");
            Assert.AreEqual(11.93, Proj.OptionsIXRawProductivity, 0.01, "OptionsIXRawProductivity - incorrect value.");
            Assert.AreEqual(10.21, Proj.OptionsROIXProductivity, 0.01, "OptionsROIXProductivity - incorrect value.");
            Assert.AreEqual(11.10, Proj.OptionsIXIX2Productivity, 0.01, "OptionsIXIX2Productivity - incorrect value.");
        }
    }
}
