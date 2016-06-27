using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RO_IX;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web_app.Models
{
    public class Project : ProjectBase
    {
        public int Id { get; set; }

        #region Інформація про проект
        // Інформація про проект
        [DisplayName("Назва проекту")]
        [StringLength(100)]
        public override string ProjectName { get; set; }
        [DisplayName("Курс, грн/$")]
        public override decimal ProjectCurRate { get; set; }
        [DisplayName("Коментар")]
        [StringLength(255)]
        public override string ProjectComment { get; set; }
        [DisplayName("Дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public override DateTime ProjectDate { get; set; }
        #endregion

        #region Котел
        // Котел
        [DisplayName("Марка котла")]
        [StringLength(100)]
        public override string BoilerName { get; set; }
        [DisplayName("Теплова потужність, кВт")]
        public override float BolerPower { get; set; }
        [DisplayName("Паропродуктивність, т/год")]
        public override float BoilerProductivity { get; set; }
        [DisplayName("Робочий тиск, атм")]
        public override float BoilerPressure { get; set; }
        [DisplayName("ККД, %")]
        public override float BoilerEfficiency { get; set; }
        [DisplayName("Річне завантаження, %")]
        [Range(0, 100)]
        public override float BoilerAnnnualLoad { get; set; }
        #endregion

        #region Водно-хімічний режим
        // Водно-хімічний режим
        [DisplayName("Електропровідність, мкСм/см")]
        public override float WaterInConductivity { get; set; }
        [DisplayName("Жорсткість, мг-екв/л")]
        public override float WaterInHardness { get; set; }
        [DisplayName("Температура, С")]
        [Range(0, 100)]
        public override float WaterInTemperature { get; set; }
        [DisplayName("Відсоток повернення")]
        [Range(0, 100)]
        public override float WaterCondensateReturn { get; set; }
        [DisplayName("Електропровідність, мкСм/см")]
        public override float WaterCondensateConductivity { get; set; }
        [DisplayName("Температура, С")]
        [Range(0, 100)]
        public override float WaterCondensateTemperature { get; set; }
        [DisplayName("Електропровідність, мкСм/см")]
        public override float WaterROConductivity { get; set; }
        [DisplayName("Макс. електропровідність котлової води, мкСм/см")]
        public override float WaterROConductivityMax { get; set; }
        [DisplayName("Електропровідність, мкСм/см")]
        public override float WaterIXConductivity { get; set; }
        [DisplayName("Макс. електропровідність котлової води, мкСм/см")]
        public override float WaterIXConductivityMax { get; set; }
        #endregion

        #region Капітальні затрати
        // Капітальні затрати
        [DisplayName("Вартість системи водопідготовки на базі зворотного осмосу, $")]
        public override decimal WaterROSystemPrice { get; set; }
        [DisplayName("Вартість системи водопідготовки на базі іонного обміну, $")]
        public override decimal WaterIXSystemPrice { get; set; }
        #endregion

        #region Налаштування (зворотній осмос)
        // Налаштування (зворотній осмос)
        [DisplayName("Продуктивність, м3/год")]
        public override float OptionsRORawProductivity { get; set; }
        [DisplayName("Ультрафільтрація")]
        public override bool OptionsROUFOn { get; set; }
        [DisplayName("Вихід по перміату")]
        public override float OptionsROUFPermeate { get; set; }
        [DisplayName("Продуктивність, м3/год")]
        public override float OptionsROUFProductivity { get; set; }
        [DisplayName("Зворотній осмос")]
        public override bool OptionsROROOn { get; set; }
        [DisplayName("Вихід по перміату")]
        public override float OptionsROROPermeate { get; set; }
        [DisplayName("Продуктивність, м3/год")]
        public override float OptionsROROProductivity { get; set; }
        [DisplayName("Іонний обмін (ІІ ст)")]
        public override bool OptionsROIXOn { get; set; }
        [DisplayName("Вихід по перміату")]
        public override float OptionsROIXPermeate { get; set; }
        [DisplayName("Продуктивність, м3/год")]
        public override float OptionsROIXProductivity { get; set; }
        [DisplayName("Автоматичний розрахунок")]
        public override bool OptionsROEditOn { get; set; }
        #endregion

        #region Налаштування (пом'якшення)
        // Налаштування (пом'якшення)
        [DisplayName("Продуктивність, м3/год")]
        public override float OptionsIXRawProductivity { get; set; }
        [DisplayName("Ультрафільтрація")]
        public override bool OptionsIXUFOn { get; set; }
        [DisplayName("Вихід по перміату")]
        public override float OptionsIXUFPermeate { get; set; }
        [DisplayName("Продуктивність, м3/год")]
        public override float OptionsIXUFProductivity { get; set; }
        [DisplayName("Іонний обмін (І ст)")]
        public override bool OptionsIXIX1On { get; set; }
        [DisplayName("Вихід по перміату")]
        public override float OptionsIXIX1Permeate { get; set; }
        [DisplayName("Продуктивність, м3/год")]
        public override float OptionsIXIX1Productivity { get; set; }
        [DisplayName("Іонний обмін (ІІ ст)")]
        public override bool OptionsIXIX2On { get; set; }
        [DisplayName("Вихід по перміату")]
        public override float OptionsIXIX2Permeate { get; set; }
        [DisplayName("Продуктивність, м3/год")]
        public override float OptionsIXIX2Productivity { get; set; }
        [DisplayName("Автоматичний розрахунок")]
        public override bool OptionsIXEditOn { get; set; }
        #endregion

        #region Вартості і питомі витрати реагентів
        // Вартості і питомі витрати реагентів
        public List<ProjectPrice> ProjectPrices { get; set; }
        public override List<ProjectPricesItem> GetProjectPrices()
        {
            return ProjectPrices?.ToList<ProjectPricesItem>();
        }
        public override void SetProjectPrices(List<ProjectPricesItem> _projectPrices)
        {
            ProjectPrices = new List<ProjectPrice>();
            ProjectPrice pp;
            foreach (ProjectPricesItem item in _projectPrices)
            {
                pp = new ProjectPrice();
                pp.IX1 = item.IX1;
                pp.IX2 = item.IX2;
                pp.Name = item.Name;
                pp.Price = item.Price;
                pp.RO = item.RO;
                pp.UF = item.UF;
                ProjectPrices.Add(pp);
            }
        }
        #endregion

        public virtual ApplicationUser User { get; set; }
    }
}