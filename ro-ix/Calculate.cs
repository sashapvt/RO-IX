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

        // Величина продувки для осмосу
        public float BoilerBlowdownIX
        {
            get { return BoilerBlowdown(Proj.WaterIXConductivity, Proj.WaterIXConductivityMax); }
        }
        #endregion

        #region Допоміжні функції
        // Розрахунок величини продувки
        float BoilerBlowdown(float FeedConductivity, float BlowdownConductivity)
        {
            return 100 * FeedConductivity / (BlowdownConductivity - FeedConductivity);
        } 

        #endregion
    }
}
