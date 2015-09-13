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

        #endregion
    }
}
