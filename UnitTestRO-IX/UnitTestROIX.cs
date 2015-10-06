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
            Assert.AreEqual(69852, Calc.ReportElectricityMoneyAnnualRO, 1, "ReportElectricityMoneyAnnualRO - incorrect value.");
            Assert.AreEqual(2139, Calc.ReportElectricityMoneyAnnualIX, 1, "ReportElectricityMoneyAnnualIX - incorrect value.");
            Assert.AreEqual(41951, Calc.ReportAntiscalantMoneyAnnualRO, 1, "ReportAntiscalantMoneyAnnualRO - incorrect value.");
            Assert.AreEqual(13223, Calc.ReportCIPMoneyAnnualRO, 1, "ReportCIPMoneyAnnualRO - incorrect value.");
            Assert.AreEqual(2656, Calc.ReportSaltMoneyAnnualRO, 1, "ReportSaltMoneyAnnualRO - incorrect value.");
            Assert.AreEqual(205042, Calc.ReportSaltMoneyAnnualIX, 1, "ReportSaltMoneyAnnualIX - incorrect value.");
            Assert.AreEqual(0, Calc.ReportNaOClMoneyAnnualRO, 1, "ReportNaOClMoneyAnnualRO - incorrect value.");
            Assert.AreEqual(0, Calc.ReportNaOClMoneyAnnualIX, 1, "ReportNaOClMoneyAnnualIX - incorrect value.");
            Assert.AreEqual(0, Calc.ReportHClMoneyAnnualRO, 1, "ReportHClMoneyAnnualRO - incorrect value.");
            Assert.AreEqual(0, Calc.ReportHClMoneyAnnualIX, 1, "ReportHClMoneyAnnualIX - incorrect value.");
            Assert.AreEqual(0, Calc.ReportNaOHMoneyAnnualRO, 1, "ReportNaOHMoneyAnnualRO - incorrect value.");
            Assert.AreEqual(0, Calc.ReportNaOHMoneyAnnualIX, 1, "ReportNaOHMoneyAnnualIX - incorrect value.");
            Assert.AreEqual(51303, Calc.ReportMembranesROMoneyAnnualRO, 1, "ReportMembranesROMoneyAnnualRO - incorrect value.");
            Assert.AreEqual(0, Calc.ReportMembranesUFMoneyAnnualRO, 1, "ReportMembranesUFMoneyAnnualRO - incorrect value.");
            Assert.AreEqual(0, Calc.ReportMembranesUFMoneyAnnualIX, 1, "ReportMembranesUFMoneyAnnualIX - incorrect value.");
            Assert.AreEqual(5718, Calc.ReportResineUFMoneyAnnualRO, 1, "ReportResineUFMoneyAnnualRO - incorrect value.");
            Assert.AreEqual(15887, Calc.ReportResineUFMoneyAnnualIX, 1, "ReportResineUFMoneyAnnualIX - incorrect value.");
            Assert.AreEqual(184704, Calc.ReportWaterTotalMoneyAnnualRO, 1, "ReportWaterTotalMoneyAnnualRO - incorrect value.");
            Assert.AreEqual(223068, Calc.ReportWaterTotalMoneyAnnualIX, 1, "ReportWaterTotalMoneyAnnualIX - incorrect value.");
        }
    }
}
