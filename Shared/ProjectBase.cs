using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

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
            // ProjectName = "Project1";
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
        [DisplayName("Назва проекту")]
        public string ProjectName { get; set; }
        [DisplayName("Курс, грн/$")]
        public decimal ProjectCurRate { get; set; }
        [DisplayName("Коментар")]
        public string ProjectComment { get; set; }
        [DisplayName("Дата")]
        public DateTime ProjectDate { get; set; }
        #endregion

        #region Котел
        // Котел
        [DisplayName("Марка котла")]
        public string BoilerName { get; set; }
        [DisplayName("Теплова потужність, кВт")]
        public float BolerPower { get; set; }
        [DisplayName("Паропродуктивність, т/год")]
        public float BoilerProductivity { get; set; }
        [DisplayName("Робочий тиск, атм")]
        public float BoilerPressure { get; set; }
        [DisplayName("ККД, %")]
        public float BoilerEfficiency { get; set; }
        [DisplayName("Річне завантаження, %")]
        public float BoilerAnnnualLoad { get; set; }
        #endregion

        #region Водно-хімічний режим
        // Водно-хімічний режим
        [DisplayName("Електропровідність, мкСм/см")]
        public float WaterInConductivity { get; set; }
        [DisplayName("Жорсткість, мг-екв/л")]
        public float WaterInHardness { get; set; }
        [DisplayName("Температура, С")]
        public float WaterInTemperature { get; set; }
        [DisplayName("Відсоток повернення")]
        public float WaterCondensateReturn { get; set; }
        [DisplayName("Електропровідність, мкСм/см")]
        public float WaterCondensateConductivity { get; set; }
        [DisplayName("Температура, С")]
        public float WaterCondensateTemperature { get; set; }
        [DisplayName("Електропровідність, мкСм/см")]
        public float WaterROConductivity { get; set; }
        [DisplayName("Макс. електропровідність котлової води, мкСм/см")]
        public float WaterROConductivityMax { get; set; }
        [DisplayName("Електропровідність, мкСм/см")]
        public float WaterIXConductivity { get; set; }
        [DisplayName("Макс. електропровідність котлової води, мкСм/см")]
        public float WaterIXConductivityMax { get; set; }
        #endregion

        #region Налаштування (зворотній осмос)
        // Налаштування (зворотній осмос)
        [DisplayName("Продуктивність, м3/год")]
        public float OptionsRORawProductivity { get; set; }
        [DisplayName("Ультрафільтрація")]
        public bool OptionsROUFOn { get; set; }
        [DisplayName("Вихід по перміату")]
        public float OptionsROUFPermeate { get; set; }
        [DisplayName("Продуктивність, м3/год")]
        public float OptionsROUFProductivity { get; set; }
        [DisplayName("Зворотній осмос")]
        public bool OptionsROROOn { get; set; }
        [DisplayName("Вихід по перміату")]
        public float OptionsROROPermeate { get; set; }
        [DisplayName("Продуктивність, м3/год")]
        public float OptionsROROProductivity { get; set; }
        [DisplayName("Іонний обмін (ІІ ст)")]
        public bool OptionsROIXOn { get; set; }
        [DisplayName("Вихід по перміату")]
        public float OptionsROIXPermeate { get; set; }
        [DisplayName("Продуктивність, м3/год")]
        public float OptionsROIXProductivity { get; set; }
        [DisplayName("Автоматичний розрахунок")]
        public bool OptionsROEditOn { get; set; }
        #endregion

        #region Налаштування (пом'якшення)
        // Налаштування (пом'якшення)
        [DisplayName("Продуктивність, м3/год")]
        public float OptionsIXRawProductivity { get; set; }
        [DisplayName("Ультрафільтрація")]
        public bool OptionsIXUFOn { get; set; }
        [DisplayName("Вихід по перміату")]
        public float OptionsIXUFPermeate { get; set; }
        [DisplayName("Продуктивність, м3/год")]
        public float OptionsIXUFProductivity { get; set; }
        [DisplayName("Іонний обмін (І ст)")]
        public bool OptionsIXIX1On { get; set; }
        [DisplayName("Вихід по перміату")]
        public float OptionsIXIX1Permeate { get; set; }
        [DisplayName("Продуктивність, м3/год")]
        public float OptionsIXIX1Productivity { get; set; }
        [DisplayName("Іонний обмін (ІІ ст)")]
        public bool OptionsIXIX2On { get; set; }
        [DisplayName("Вихід по перміату")]
        public float OptionsIXIX2Permeate { get; set; }
        [DisplayName("Продуктивність, м3/год")]
        public float OptionsIXIX2Productivity { get; set; }
        [DisplayName("Автоматичний розрахунок")]
        public bool OptionsIXEditOn { get; set; }
        #endregion

        #region Вартості і питомі витрати реагентів
        // Вартості і питомі витрати реагентів
        public List<ProjectPricesItem> OptionsPricesData;
        #endregion
    }
}
