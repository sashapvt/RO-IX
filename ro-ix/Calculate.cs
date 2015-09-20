using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO_IX
{
    // Клас для розрахунку проекту 
    class Calculate
    {
        // Конструктор. В параметрі передається посилання на проект
        public Calculate(Project proj)
        {
            this.Proj = proj;
        }

        // Проект, для якого проводиться розрахунок
        Project Proj;

        // Необхідні константи
        const float NaturalGasHeatOfCombustion = 33494.4f; // Питома теплота згоряння природного газу, кДж/кг

        #region Поля результату
        // Величина продувки для осмосу
        public float BoilerBlowdownRO
        {
           get { return BoilerBlowdown(Proj.WaterROConductivity, Proj.WaterROConductivityMax); }
        }

        // Величина продувки для іонного обміну
        public float BoilerBlowdownIX
        {
            get { return BoilerBlowdown(Proj.WaterIXConductivity, Proj.WaterIXConductivityMax); }
        }
        
        // Витрата води на продувку для осмосу
        public float BoilerBlowdownFlowRO
        {
            get { return BoilerBlowdownFlow(BoilerBlowdownRO); }
        }

        // Витрата води на продувку для іонного обміну
        public float BoilerBlowdownFlowIX
        {
            get { return BoilerBlowdownFlow(BoilerBlowdownIX); }
        }

        // Витрата пари за рахунок продувки для осмосу
        public float BoilerBlowdownSteamRO
        {
            get { return BoilerBlowdownSteam(BoilerBlowdownFlowRO); }
        }

        // Витрата пари за рахунок продувки для іонного обміну
        public float BoilerBlowdownSteamIX
        {
            get { return BoilerBlowdownSteam(BoilerBlowdownFlowIX); }
        }

        // Витрата потужності за рахунок продувки для осмосу
        public float BoilerBlowdownPowerRO
        {
            get { return BoilerBlowdownPower(BoilerBlowdownSteamRO); }
        }

        // Витрата потужності за рахунок продувки для іонного обміну
        public float BoilerBlowdownPowerIX
        {
            get { return BoilerBlowdownPower(BoilerBlowdownSteamIX); }
        }

        // Витрата газу на покриття втрат продувки для осмосу
        public float BoilerBlowdownGasRO
        {
            get { return BoilerBlowdownGas(BoilerBlowdownPowerRO); }
        }

        // Витрата газу на покриття втрат продувки для іонного обміну
        public float BoilerBlowdownGasIX
        {
            get { return BoilerBlowdownGas(BoilerBlowdownPowerIX); }
        }

        // Витрата коштів на покриття втрат газу на продувку для осмосу
        public float BoilerBlowdownMoneyRO
        {
            get { return BoilerBlowdownMoney(BoilerBlowdownGasRO); }
        }

        // Витрата коштів на покриття втрат газу на продувку для іонного обміну
        public float BoilerBlowdownMoneyIX
        {
            get { return BoilerBlowdownMoney(BoilerBlowdownGasIX); }
        }

        // Витрата коштів на покриття річних втрат газу на продувку для осмосу
        public float BoilerBlowdownMoneyAnnualRO
        {
            get { return BoilerBlowdownMoneyAnnual(BoilerBlowdownMoneyRO); }
        }

        // Витрата коштів на покриття річних втрат газу на продувку для іонного обміну
        public float BoilerBlowdownMoneyAnnualIX
        {
            get { return BoilerBlowdownMoneyAnnual(BoilerBlowdownMoneyIX); }
        }
        #endregion

        #region Розрахунокові функції
        // Розрахунок величини продувки
        float BoilerBlowdown(float FeedConductivity, float BlowdownConductivity)
        {
            return FeedConductivity / (BlowdownConductivity - FeedConductivity);
        }

        // Розрахунок витрати продувочної води
        float BoilerBlowdownFlow(float BoilerBlowdown)
        {
            return Proj.BoilerProductivity * (1 + BoilerBlowdown) * BoilerBlowdown;
        }
        
        // Розрахунок витрати пари за рахунок продувки
        float BoilerBlowdownSteam(float BoilerBlowdownFlow)
        {
            return BoilerBlowdownFlow * (EnthalpyWaterFromPres(Proj.BoilerPressure) - EnthalpyWaterFromTemp(Proj.WaterInTemperature))
                / (EnthalpySteamFromPres(Proj.BoilerPressure) - EnthalpyWaterFromTemp(Proj.WaterInTemperature));
        }

        // Розрахунок втрати потужності за рахунок продувки
        float BoilerBlowdownPower(float BoilerBlowdownSteam)
        {
            return BoilerBlowdownSteam * (Proj.BoilerEfficiency / 100) * Proj.BolerPower / Proj.BoilerProductivity;
        }

        // Розрахунок витрати газу на покриття втрат продувки
        float BoilerBlowdownGas(float BoilerBlowdownPower)
        {
            return 3600 * BoilerBlowdownPower / NaturalGasHeatOfCombustion;
        }

        // Розрахунок витрат газу на покриття втрат продувки
        float BoilerBlowdownMoney(float BoilerBlowdownGas)
        {
            return (float)(Proj.OptionsPricesData[0].Price * Proj.ProjectCurRate) * BoilerBlowdownGas;
        }

        // Розрахунок річної витрати газу на покриття втрат продувки
        float BoilerBlowdownMoneyAnnual(float BoilerBlowdownMoney)
        {
            return (Proj.BoilerAnnnualLoad / 100) * 365 * 24 * BoilerBlowdownMoney;
        }
        #endregion

        #region Розрахунок продуктивності систем водопідготовки
        public void CalculateProductivity()
        {
            if (Proj.OptionsROEditOn)
            {
                Proj.OptionsROIXProductivity = Round(Proj.BoilerProductivity + BoilerBlowdownFlowRO);
                Proj.OptionsROROProductivity = Round(Proj.OptionsROIXProductivity/(Proj.OptionsROIXPermeate / 100));
                Proj.OptionsROUFProductivity = Round(Proj.OptionsROROProductivity / (Proj.OptionsROROPermeate / 100));
            }
            if (Proj.OptionsIXEditOn)
            {
                Proj.OptionsIXIX2Productivity = Round(Proj.BoilerProductivity + BoilerBlowdownFlowIX);
                Proj.OptionsIXIX1Productivity = Round(Proj.OptionsIXIX2Productivity / (Proj.OptionsIXIX2Permeate / 100));
                Proj.OptionsIXUFProductivity = Round(Proj.OptionsIXIX1Productivity / (Proj.OptionsIXIX1Permeate / 100));
            }
        }

        #endregion

        #region Допоміжні функції
        // Розрахунок питомої ентальпії води в залежності від температури  
        float EnthalpyWaterFromTemp(float Temperature)
        {
            return 0.141f + Temperature * 4.1859f; // кДж/кг
        }

        // Розрахунок питомої ентальпії води в залежності від тиску  
        float EnthalpyWaterFromPres(float Pressure)
        {
            return 0.0064f * (float)Math.Pow(Pressure, 5) - 0.3481f * (float)Math.Pow(Pressure, 4) + 6.9705f * (float)Math.Pow(Pressure, 3) - 63.365f * (float)Math.Pow(Pressure, 2) + 280.11f * Pressure + 161.83f; // кДж/кг
        }

        // Розрахунок питомої ентальпії пару в залежності від тиску
        float EnthalpySteamFromPres(float Pressure)
        {
            return 2679.6f + 41.9f * (float)Math.Log(Pressure); // кДж/кг
        }

        // Округлення до двох знаків у більшу сторону
        float Round(float number)
        {
            return (float)Math.Round(number, 2, MidpointRounding.AwayFromZero);
        }

        #endregion
    }
}
