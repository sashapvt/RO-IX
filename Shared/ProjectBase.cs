using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO_IX
{
    public abstract class ProjectBase
    {
        // Public consructor
        public ProjectBase()
        {            
            // Initialisation of OptionsPrices
            OptionsPricesData = new List<ProjectPricesItem>();
        }

        // Ініціалізація проекту по замовчуванню
        public void New()
        {
            // Ініціалізація нового проекту
            ProjectName = "Project1";
            ProjectCurRate = 22.00m;
            ProjectComment = "no comments";
            ProjectDate = DateTime.Now;

            // Параметри котла
            BoilerName = "";
            BolerPower = 6888;
            BoilerProductivity = 10;
            BoilerPressure = 10.3f;
            BoilerEfficiency = 94.6f;
            BoilerAnnnualLoad = 50;

            // Водно-хімічний режим
            WaterInConductivity = 544;
            WaterInHardness = 4.3f;
            WaterInTemperature = 12;
            WaterCondensateReturn = 0;
            WaterCondensateConductivity = 100;
            WaterCondensateTemperature = 60;
            WaterROConductivity = 80;
            WaterROConductivityMax = 4000;
            WaterIXConductivity = 544;
            WaterIXConductivityMax = 6000;

            // Налаштування (зворотній осмос)
            OptionsROUFPermeate = 93;
            OptionsROROPermeate = 75;
            OptionsROIXPermeate = 98;
            OptionsROROOn = true;
            OptionsROIXOn = true;
            OptionsROEditOn = true;

            // Налаштування (пом'якшення)
            OptionsIXUFPermeate = 93;
            OptionsIXIX1Permeate = 95;
            OptionsIXIX2Permeate = 98;
            OptionsIXIX1On = true;
            OptionsIXIX2On = true;
            OptionsIXEditOn = true;

            // Вартості ресурсів та витрати реагентів
            // ProjectPricesItem(0, "Назва", ціна, витрата для МУ, витрата для МО, витрата для ФУ1, витрата для УФ2);
            OptionsPricesData.Add(new ProjectPricesItem(0, "Газ, м3", 0.40m, 0F, 0F, 0F, 0F));
            OptionsPricesData.Add(new ProjectPricesItem(1, "Електроенергія, кВт", 0.10m, 0.07F, 0.7F, 0.01F, 0.01F));
            OptionsPricesData.Add(new ProjectPricesItem(2, "Сіль таблетована, кг", 0.27m, 0F, 0F, 0.7F, 0.01F));
            OptionsPricesData.Add(new ProjectPricesItem(3, "Антискалант, кг", 5.33m, 0F, 0.008F, 0F, 0F));
            OptionsPricesData.Add(new ProjectPricesItem(4, "Реаг. хімпром, кг ", 8.40m, 0F, 0.0016F, 0F, 0F));
            OptionsPricesData.Add(new ProjectPricesItem(5, "NaOCl, 19%, кг", 0.35m, 0.018F, 0F, 0F, 0F));
            OptionsPricesData.Add(new ProjectPricesItem(6, "HCl, 35%, кг", 0.14m, 0.0035F, 0F, 0F, 0F));
            OptionsPricesData.Add(new ProjectPricesItem(7, "NaOH, 45%, кг", 0.35m, 0.013F, 0F, 0F, 0F));
            OptionsPricesData.Add(new ProjectPricesItem(8, "Мембрана МО, шт", 1142.00m, 0F, 5F, 0F, 0F)); // Ціна за одну мембрану XLE-440, період заміни, роки
            OptionsPricesData.Add(new ProjectPricesItem(9, "Мембрана УФ, шт", 2600.00m, 5F, 0F, 0F, 0F)); // Ціна за одну мембрану SFP2880, період заміни, роки
            OptionsPricesData.Add(new ProjectPricesItem(10, "Катіоніт, л", 3.96m, 0F, 0F, 5F, 7F)); // Ціна за один л HCRS/S, період заміни, роки
        }

        #region Інформація про проект
        // Інформація про проект
        public string ProjectName { get; set; }
        public decimal ProjectCurRate { get; set; }
        public string ProjectComment { get; set; }
        public DateTime ProjectDate { get; set; }
        #endregion

        #region Котел
        // Котел
        public string BoilerName { get; set; }
        public float BolerPower { get; set; }
        public float BoilerProductivity { get; set; }
        public float BoilerPressure { get; set; }
        public float BoilerEfficiency { get; set; }
        public float BoilerAnnnualLoad { get; set; }
        #endregion

        #region Водно-хімічний режим
        // Водно-хімічний режим
        public float WaterInConductivity { get; set; }
        public float WaterInHardness { get; set; }
        public float WaterInTemperature { get; set; }
        public float WaterCondensateReturn { get; set; }
        public float WaterCondensateConductivity { get; set; }
        public float WaterCondensateTemperature { get; set; }
        public float WaterROConductivity { get; set; }
        public float WaterROConductivityMax { get; set; }
        public float WaterIXConductivity { get; set; }
        public float WaterIXConductivityMax { get; set; }
        #endregion

        #region Налаштування (зворотній осмос)
        // Налаштування (зворотній осмос)
        public float OptionsRORawProductivity { get; set; }
        public bool OptionsROUFOn { get; set; }
        public float OptionsROUFPermeate { get; set; }
        public float OptionsROUFProductivity { get; set; }
        public bool OptionsROROOn { get; set; }
        public float OptionsROROPermeate { get; set; }
        public float OptionsROROProductivity { get; set; }
        public bool OptionsROIXOn { get; set; }
        public float OptionsROIXPermeate { get; set; }
        public float OptionsROIXProductivity { get; set; }
        public bool OptionsROEditOn { get; set; }
        #endregion

        #region Налаштування (пом'якшення)
        // Налаштування (пом'якшення)
        public float OptionsIXRawProductivity { get; set; }
        public bool OptionsIXUFOn { get; set; }
        public float OptionsIXUFPermeate { get; set; }
        public float OptionsIXUFProductivity { get; set; }
        public bool OptionsIXIX1On { get; set; }
        public float OptionsIXIX1Permeate { get; set; }
        public float OptionsIXIX1Productivity { get; set; }
        public bool OptionsIXIX2On { get; set; }
        public float OptionsIXIX2Permeate { get; set; }
        public float OptionsIXIX2Productivity { get; set; }
        public bool OptionsIXEditOn { get; set; }
        #endregion

        #region Вартості і питомі витрати реагентів
        // Вартості і питомі витрати реагентів
        public List<ProjectPricesItem> OptionsPricesData;
        #endregion
    }
}
