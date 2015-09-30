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

        // Витрата коштів на покриття річних витрат електроенергії для осмосу
        public float ReportElectricityMoneyAnnualRO
        {
            get { return ReportMoneyAnnualReagents(Proj.OptionsROIXProductivity, ((Proj.OptionsROUFOn) ? Proj.OptionsPricesData[1].UF : 0) + ((Proj.OptionsROROOn) ? Proj.OptionsPricesData[1].RO : 0) + ((Proj.OptionsROIXOn) ? Proj.OptionsPricesData[1].IX2 : 0), Proj.OptionsPricesData[1].Price); }
        }

        // Витрата коштів на покриття річних витрат електроенергії для іонного обміну
        public float ReportElectricityMoneyAnnualIX
        {
            get { return ReportMoneyAnnualReagents(Proj.OptionsIXIX2Productivity, ((Proj.OptionsIXUFOn) ? Proj.OptionsPricesData[1].UF : 0) + ((Proj.OptionsIXIX1On) ? Proj.OptionsPricesData[1].IX1 : 0) + ((Proj.OptionsIXIX2On) ? Proj.OptionsPricesData[1].IX2 : 0), Proj.OptionsPricesData[1].Price); }
        }

        // Витрата коштів на покриття річних витрат антискаланту для осмосу
        public float ReportAntiscalantMoneyAnnualRO
        {
            get { return ReportMoneyAnnualReagents(Proj.OptionsROIXProductivity, ((Proj.OptionsROROOn) ? Proj.OptionsPricesData[3].RO : 0), Proj.OptionsPricesData[3].Price); }
        }

        // Витрата коштів на покриття річних витрат реагентів для хімпромивки для осмосу
        public float ReportCIPMoneyAnnualRO
        {
            get { return ReportMoneyAnnualReagents(Proj.OptionsROIXProductivity, ((Proj.OptionsROROOn) ? Proj.OptionsPricesData[4].RO : 0), Proj.OptionsPricesData[4].Price); }
        }

        // Витрата коштів на покриття річних витрат солі таблетованої для осмосу
        public float ReportSaltMoneyAnnualRO
        {
            get { return ReportMoneyAnnualReagents(Proj.OptionsROIXProductivity, ((Proj.OptionsROIXOn) ? Proj.OptionsPricesData[2].IX2 : 0), Proj.OptionsPricesData[2].Price); }
        }

        // Витрата коштів на покриття річних витрат солі таблетованої для іонного обміну
        public float ReportSaltMoneyAnnualIX
        {
            get { return ReportMoneyAnnualReagents(Proj.OptionsIXIX2Productivity, ((Proj.OptionsIXIX1On) ? Proj.OptionsPricesData[2].IX1 : 0) + ((Proj.OptionsIXIX2On) ? Proj.OptionsPricesData[2].IX2 : 0), Proj.OptionsPricesData[2].Price); }
        }

        // Витрата коштів на покриття річних витрат гіпохлориту натрію для осмосу
        public float ReportNaOClMoneyAnnualRO
        {
            get { return ReportMoneyAnnualReagents(Proj.OptionsROIXProductivity, ((Proj.OptionsROUFOn) ? Proj.OptionsPricesData[5].UF : 0), Proj.OptionsPricesData[5].Price); }
        }

        // Витрата коштів на покриття річних витрат гіпохлориту натрію для іонного обміну
        public float ReportNaOClMoneyAnnualIX
        {
            get { return ReportMoneyAnnualReagents(Proj.OptionsIXIX2Productivity, ((Proj.OptionsIXUFOn) ? Proj.OptionsPricesData[5].UF : 0), Proj.OptionsPricesData[5].Price); }
        }

        // Витрата коштів на покриття річних витрат соляної кислоти для осмосу
        public float ReportHClMoneyAnnualRO
        {
            get { return ReportMoneyAnnualReagents(Proj.OptionsROIXProductivity, ((Proj.OptionsROUFOn) ? Proj.OptionsPricesData[6].UF : 0), Proj.OptionsPricesData[6].Price); }
        }

        // Витрата коштів на покриття річних витрат соляної кислоти для іонного обміну
        public float ReportHClMoneyAnnualIX
        {
            get { return ReportMoneyAnnualReagents(Proj.OptionsIXIX2Productivity, ((Proj.OptionsIXUFOn) ? Proj.OptionsPricesData[6].UF : 0), Proj.OptionsPricesData[6].Price); }
        }

        // Витрата коштів на покриття річних витрат їдкого натру для осмосу
        public float ReportNaOHMoneyAnnualRO
        {
            get { return ReportMoneyAnnualReagents(Proj.OptionsROIXProductivity, ((Proj.OptionsROUFOn) ? Proj.OptionsPricesData[7].UF : 0), Proj.OptionsPricesData[7].Price); }
        }

        // Витрата коштів на покриття річних витрат їдкого натру для іонного обміну
        public float ReportNaOHMoneyAnnualIX
        {
            get { return ReportMoneyAnnualReagents(Proj.OptionsIXIX2Productivity, ((Proj.OptionsIXUFOn) ? Proj.OptionsPricesData[7].UF : 0), Proj.OptionsPricesData[7].Price); }
        }

        // Витрата коштів на покриття заміни МО мембран для осмосу
        public float ReportMembranesROMoneyAnnualRO
        {
            get { return ReportMoneyAnnualMaterials(Proj.OptionsROIXProductivity, ((Proj.OptionsROROOn) ? Proj.OptionsPricesData[8].RO : 0), Proj.OptionsPricesData[8].Price); }
        }

        // Витрата коштів на покриття заміни УФ мембран для осмосу
        public float ReportMembranesUFMoneyAnnualRO
        {
            get { return ReportMoneyAnnualMaterials(Proj.OptionsROIXProductivity / 4, ((Proj.OptionsROUFOn) ? Proj.OptionsPricesData[9].UF : 0), Proj.OptionsPricesData[9].Price); }
        }

        // Витрата коштів на покриття заміни УФ мембран для іонного обміну
        public float ReportMembranesUFMoneyAnnualIX
        {
            get { return ReportMoneyAnnualMaterials(Proj.OptionsIXIX2Productivity / 4, ((Proj.OptionsIXUFOn) ? Proj.OptionsPricesData[9].UF : 0), Proj.OptionsPricesData[9].Price); }
        }
        #endregion

        #region Розрахункові функції
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

        // Розрахунок річної вартості електроенергії, реагентів і т.п.
        float ReportMoneyAnnualReagents(float WaterProductivity, float Quantity, decimal Price)
        {
            return WaterProductivity * Quantity * (float)Price * 365 * 24 * (Proj.BoilerAnnnualLoad / 100) * (float)Proj.ProjectCurRate;
        }

        // Розрахунок річної вартості мембран та катіоніту.
        float ReportMoneyAnnualMaterials(float WaterProductivity, float YearsToReplacement, decimal Price)
        {
            if (YearsToReplacement == 0) return 0;
            return WaterProductivity * (float)Price * (float)Proj.ProjectCurRate / YearsToReplacement;
        }
        #endregion

        #region Розрахунок продуктивності систем водопідготовки
        public void CalculateProductivity()
        {
            if (Proj.OptionsROEditOn)
            {
                Proj.OptionsROIXProductivity = Round(Proj.BoilerProductivity + BoilerBlowdownFlowRO);
                Proj.OptionsROROProductivity = Round(Proj.OptionsROIXProductivity / ((Proj.OptionsROIXOn) ? Proj.OptionsROIXPermeate / 100 : 1));
                Proj.OptionsROUFProductivity = Round(Proj.OptionsROROProductivity / ((Proj.OptionsROROOn) ? Proj.OptionsROROPermeate / 100 : 1));
                Proj.OptionsRORawProductivity = Round(Proj.OptionsROUFProductivity / ((Proj.OptionsROUFOn) ? Proj.OptionsROUFPermeate / 100 : 1));
            }
            if (Proj.OptionsIXEditOn)
            {
                Proj.OptionsIXIX2Productivity = Round(Proj.BoilerProductivity + BoilerBlowdownFlowIX);
                Proj.OptionsIXIX1Productivity = Round(Proj.OptionsIXIX2Productivity / ((Proj.OptionsIXIX2On) ? Proj.OptionsIXIX2Permeate / 100 : 1));
                Proj.OptionsIXUFProductivity = Round(Proj.OptionsIXIX1Productivity / ((Proj.OptionsIXIX1On) ? Proj.OptionsIXIX1Permeate / 100 : 1));
                Proj.OptionsIXRawProductivity = Round(Proj.OptionsIXUFProductivity / ((Proj.OptionsIXUFOn) ? Proj.OptionsIXUFPermeate / 100 : 1));
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
