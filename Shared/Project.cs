﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using System.Xml.Serialization;

namespace RO_IX
{
    public class Project : INotifyPropertyChanged
    {
        // Public consructor
        public Project()
        {
            // Initialisation of OptionsPrices
            OptionsPrices = new ProjectPrices();
            OptionsPricesData = OptionsPrices.Data;
            OptionsPricesDataView = CollectionViewSource.GetDefaultView(OptionsPricesData);
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
            // ProjectPrices.ProjectPricesItem(0, "Назва", ціна, витрата для МУ, витрата для МО, витрата для ФУ1, витрата для УФ2, тільки ціна (так/ні));
            OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(0, "Газ, м3", 0.40m, 0F, 0F, 0F, 0F, true));
            OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(1, "Електроенергія, кВт", 0.10m, 0.07F, 0.7F, 0.01F, 0.01F, false));
            OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(2, "Сіль таблетована, кг", 0.27m, 0F, 0F, 0.7F, 0.01F, false));
            OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(3, "Антискалант, кг", 5.33m, 0F, 0.008F, 0F, 0F, false));
            OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(4, "Реаг. хімпром, кг ", 8.40m, 0F, 0.0016F, 0F, 0F, false));
            OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(5, "NaOCl, 19%, кг", 0.35m, 0.018F, 0F, 0F, 0F, false));
            OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(6, "HCl, 35%, кг", 0.14m, 0.0035F, 0F, 0F, 0F, false));
            OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(7, "NaOH, 45%, кг", 0.35m, 0.013F, 0F, 0F, 0F, false));
            OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(8, "Мембрана МО, шт", 1142.00m, 0F, 5F, 0F, 0F, false)); // Ціна за одну мембрану XLE-440, період заміни, роки
            OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(9, "Мембрана УФ, шт", 2600.00m, 5F, 0F, 0F, 0F, false)); // Ціна за одну мембрану SFP2880, період заміни, роки
            OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(10, "Катіоніт, л", 3.96m, 0F, 0F, 5F, 7F, false)); // Ціна за один л HCRS/S, період заміни, роки
        }

        #region Інформація про проект
        // Інформація про проект
        string _ProjectName;
        decimal _ProjectCurRate;
        string _ProjectComment;
        DateTime _ProjectDate;

        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }
        public decimal ProjectCurRate
        {
            get { return _ProjectCurRate; }
            set { _ProjectCurRate = value; }
        }
        public string ProjectComment
        {
            get { return _ProjectComment; }
            set { _ProjectComment = value; }
        }
        public DateTime ProjectDate
        {
            get { return _ProjectDate; }
            set { _ProjectDate = value; }
        }
        #endregion

        #region Котел
        // Котел
        string _BoilerName;
        float _BolerPower;
        float _BoilerProductivity;
        float _BoilerPressure;
        float _BoilerEfficiency;
        float _BoilerAnnnualLoad;

        public string BoilerName
        {
            get { return _BoilerName; }
            set { _BoilerName = value; }
        }
        public float BolerPower
        {
            get { return _BolerPower; }
            set { _BolerPower = value; }
        }
        public float BoilerProductivity
        {
            get { return _BoilerProductivity; }
            set { _BoilerProductivity = value; }
        }
        public float BoilerPressure
        {
            get { return _BoilerPressure; }
            set { _BoilerPressure = value; }
        }
        public float BoilerEfficiency
        {
            get { return _BoilerEfficiency; }
            set { _BoilerEfficiency = value; }
        }
        public float BoilerAnnnualLoad
        {
            get { return _BoilerAnnnualLoad; }
            set { _BoilerAnnnualLoad = value; }
        }
        #endregion

        #region Водно-хімічний режим
        // Водно-хімічний режим
        float _WaterInConductivity;
        float _WaterInHardness;
        float _WaterInTemperature;
        float _WaterCondensateReturn;
        float _WaterCondensateConductivity;
        float _WaterCondensateTemperature;
        float _WaterROConductivity;
        float _WaterROConductivityMax;
        float _WaterIXConductivity;
        float _WaterIXConductivityMax;

        public float WaterInConductivity
        {
            get { return _WaterInConductivity; }
            set { _WaterInConductivity = value; }
        }
        public float WaterInHardness
        {
            get { return _WaterInHardness; }
            set { _WaterInHardness = value; }
        }
        public float WaterInTemperature
        {
            get { return _WaterInTemperature; }
            set { _WaterInTemperature = value; }
        }
        public float WaterCondensateReturn
        {
            get { return _WaterCondensateReturn; }
            set { _WaterCondensateReturn = value; }
        }
        public float WaterCondensateConductivity
        {
            get { return _WaterCondensateConductivity; }
            set { _WaterCondensateConductivity = value; }
        }
        public float WaterCondensateTemperature
        {
            get { return _WaterCondensateTemperature; }
            set { _WaterCondensateTemperature = value; }
        }
        public float WaterROConductivity
        {
            get { return _WaterROConductivity; }
            set { _WaterROConductivity = value; }
        }
        public float WaterROConductivityMax
        {
            get { return _WaterROConductivityMax; }
            set { _WaterROConductivityMax = value; }
        }
        public float WaterIXConductivity
        {
            get { return _WaterIXConductivity; }
            set { _WaterIXConductivity = value; }
        }
        public float WaterIXConductivityMax
        {
            get { return _WaterIXConductivityMax; }
            set { _WaterIXConductivityMax = value; }
        }
        #endregion

        #region Налаштування (зворотній осмос)
        // Налаштування (зворотній осмос)
        float _OptionsRORawProductivity;
        bool _OptionsROUFOn;
        float _OptionsROUFPermeate;
        float _OptionsROUFProductivity;
        bool _OptionsROROOn;
        float _OptionsROROPermeate;
        float _OptionsROROProductivity;
        bool _OptionsROIXOn;
        float _OptionsROIXPermeate;
        float _OptionsROIXProductivity;
        bool _OptionsROEditOn;

        public float OptionsRORawProductivity
        {
            get { return _OptionsRORawProductivity; }
            set { _OptionsRORawProductivity = value; OnPropertyChanged("OptionsRORawProductivity"); }
        }
        public bool OptionsROUFOn
        {
            get { return _OptionsROUFOn; }
            set { _OptionsROUFOn = value; OnPropertyChanged("OptionsROUFOn"); }
        }
        public float OptionsROUFPermeate
        {
            get { return _OptionsROUFPermeate; }
            set { _OptionsROUFPermeate = value; OnPropertyChanged("OptionsROUFPermeate"); }
        }
        public float OptionsROUFProductivity
        {
            get { return _OptionsROUFProductivity; }
            set { _OptionsROUFProductivity = value; OnPropertyChanged("OptionsROUFProductivity"); }
        }
        public bool OptionsROROOn
        {
            get { return _OptionsROROOn; }
            set { _OptionsROROOn = value; OnPropertyChanged("OptionsROROOn"); }
        }
        public float OptionsROROPermeate
        {
            get { return _OptionsROROPermeate; }
            set { _OptionsROROPermeate = value; OnPropertyChanged("OptionsROROPermeate"); }
        }
        public float OptionsROROProductivity
        {
            get { return _OptionsROROProductivity; }
            set { _OptionsROROProductivity = value; OnPropertyChanged("OptionsROROProductivity"); }
        }
        public bool OptionsROIXOn
        {
            get { return _OptionsROIXOn; }
            set { _OptionsROIXOn = value; OnPropertyChanged("OptionsROIXOn"); }
        }
        public float OptionsROIXPermeate
        {
            get { return _OptionsROIXPermeate; }
            set { _OptionsROIXPermeate = value; OnPropertyChanged("OptionsROIXPermeate"); }
        }
        public float OptionsROIXProductivity
        {
            get { return _OptionsROIXProductivity; }
            set { _OptionsROIXProductivity = value; OnPropertyChanged("OptionsROIXProductivity"); }
        }
        public bool OptionsROEditOn
        {
            get { return _OptionsROEditOn; }
            set { _OptionsROEditOn = value; }
        }
        #endregion

        #region Налаштування (пом'якшення)
        // Налаштування (пом'якшення)
        float _OptionsIXRawProductivity;
        bool _OptionsIXUFOn;
        float _OptionsIXUFPermeate;
        float _OptionsIXUFProductivity;
        bool _OptionsIXIX1On;
        float _OptionsIXIX1Permeate;
        float _OptionsIXIX1Productivity;
        bool _OptionsIXIX2On;
        float _OptionsIXIX2Permeate;
        float _OptionsIXIX2Productivity;
        bool _OptionsIXEditOn;

        public float OptionsIXRawProductivity
        {
            get { return _OptionsIXRawProductivity; }
            set { _OptionsIXRawProductivity = value; OnPropertyChanged("OptionsIXRawProductivity"); }
        }
        public bool OptionsIXUFOn
        {
            get { return _OptionsIXUFOn; }
            set { _OptionsIXUFOn = value; OnPropertyChanged("OptionsIXUFOn"); }
        }
        public float OptionsIXUFPermeate
        {
            get { return _OptionsIXUFPermeate; }
            set { _OptionsIXUFPermeate = value; OnPropertyChanged("OptionsIXUFPermeate"); }
        }
        public float OptionsIXUFProductivity
        {
            get { return _OptionsIXUFProductivity; }
            set { _OptionsIXUFProductivity = value; OnPropertyChanged("OptionsIXUFProductivity"); }
        }
        public bool OptionsIXIX1On
        {
            get { return _OptionsIXIX1On; }
            set { _OptionsIXIX1On = value; OnPropertyChanged("OptionsIXIX1On"); }
        }
        public float OptionsIXIX1Permeate
        {
            get { return _OptionsIXIX1Permeate; }
            set { _OptionsIXIX1Permeate = value; OnPropertyChanged("OptionsIXIX1Permeate"); }
        }
        public float OptionsIXIX1Productivity
        {
            get { return _OptionsIXIX1Productivity; }
            set { _OptionsIXIX1Productivity = value; OnPropertyChanged("OptionsIXIX1Productivity"); }
        }
        public bool OptionsIXIX2On
        {
            get { return _OptionsIXIX2On; }
            set { _OptionsIXIX2On = value; OnPropertyChanged("OptionsIXIX2On"); }
        }
        public float OptionsIXIX2Permeate
        {
            get { return _OptionsIXIX2Permeate; }
            set { _OptionsIXIX2Permeate = value; OnPropertyChanged("OptionsIXIX2Permeate"); }
        }
        public float OptionsIXIX2Productivity
        {
            get { return _OptionsIXIX2Productivity; }
            set { _OptionsIXIX2Productivity = value; OnPropertyChanged("OptionsIXIX2Productivity"); }
        }
        public bool OptionsIXEditOn
        {
            get { return _OptionsIXEditOn; }
            set { _OptionsIXEditOn = value; }
        }
        #endregion

        #region Вартості і питомі витрати реагентів
        // Вартості і питомі витрати реагентів
        ProjectPrices OptionsPrices;
        public List<ProjectPrices.ProjectPricesItem> OptionsPricesData;
        [XmlIgnoreAttribute]
        public ICollectionView OptionsPricesDataView { get; private set; }
        #endregion

        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


    }
}