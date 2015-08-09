using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using System.Xml.Serialization;

namespace RO_IX
{
    public class Project
    {
        // Public consructor
        public Project()
        {
            // Initialisation of new project
            ProjectName = "Project1";
            ProjectComment = "no comments";
            ProjectDate = DateTime.Now;

            // Initialisation of OptionsPrices
            OptionsPrices = new ProjectPrices();
            OptionsPricesData = CollectionViewSource.GetDefaultView(OptionsPrices.Data);

        }

        #region Інформація про проект
        // Інформація про проект
        string _ProjectName;
        string _ProjectComment;
        DateTime _ProjectDate;

        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
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
        int _BolerPower;
        float _BoilerProductivity;
        float _BoilerPressure;
        float _BoilerEfficiency;

        public string BoilerName
        {
            get { return _BoilerName; }
            set { _BoilerName = value; }
        }
        public int BolerPower
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
        bool _OptionsROUFOn;
        float _OptionsROUFPermeate;
        float _OptionsROUFProductivity;
        bool _OptionsROROOn;
        float _OptionsROROPermeate;
        float _OptionsROROProductivity;
        bool _OptionsROIXOn;
        float _OptionsROIXPermeate;
        float _OptionsROIXProductivity;

        public bool OptionsROUFOn
        {
            get { return _OptionsROUFOn; }
            set { _OptionsROUFOn = value; }
        }
        public float OptionsROUFPermeate
        {
            get { return _OptionsROUFPermeate; }
            set { _OptionsROUFPermeate = value; }
        }
        public float OptionsROUFProductivity
        {
            get { return _OptionsROUFProductivity; }
            set { _OptionsROUFProductivity = value; }
        }
        public bool OptionsROROOn
        {
            get { return _OptionsROROOn; }
            set { _OptionsROROOn = value; }
        }
        public float OptionsROROPermeate
        {
            get { return _OptionsROROPermeate; }
            set { _OptionsROROPermeate = value; }
        }
        public float OptionsROROProductivity
        {
            get { return _OptionsROROProductivity; }
            set { _OptionsROROProductivity = value; }
        }
        public bool OptionsROIXOn
        {
            get { return _OptionsROIXOn; }
            set { _OptionsROIXOn = value; }
        }
        public float OptionsROIXPermeate
        {
            get { return _OptionsROIXPermeate; }
            set { _OptionsROIXPermeate = value; }
        }
        public float OptionsROIXProductivity
        {
            get { return _OptionsROIXProductivity; }
            set { _OptionsROIXProductivity = value; }
        }
        #endregion

        #region Налаштування (пом'якшення)
        // Налаштування (пом'якшення)
        bool _OptionsIXUFOn;
        float _OptionsIXUFPermeate;
        float _OptionsIXUFProductivity;
        bool _OptionsIXIX1On;
        float _OptionsIXIX1Permeate;
        float _OptionsIXIX1Productivity;
        bool _OptionsIXIX2On;
        float _OptionsIXIX2Permeate;
        float _OptionsIXIX2Productivity;

        public bool OptionsIXUFOn
        {
            get { return _OptionsIXUFOn; }
            set { _OptionsIXUFOn = value; }
        }
        public float OptionsIXUFPermeate
        {
            get { return _OptionsIXUFPermeate; }
            set { _OptionsIXUFPermeate = value; }
        }
        public float OptionsIXUFProductivity
        {
            get { return _OptionsIXUFProductivity; }
            set { _OptionsIXUFProductivity = value; }
        }
        public bool OptionsIXIX1On
        {
            get { return _OptionsIXIX1On; }
            set { _OptionsIXIX1On = value; }
        }
        public float OptionsIXIX1Permeate
        {
            get { return _OptionsIXIX1Permeate; }
            set { _OptionsIXIX1Permeate = value; }
        }
        public float OptionsIXIX1Productivity
        {
            get { return _OptionsIXIX1Productivity; }
            set { _OptionsIXIX1Productivity = value; }
        }
        public bool OptionsIXIX2On
        {
            get { return _OptionsIXIX2On; }
            set { _OptionsIXIX2On = value; }
        }
        public float OptionsIXIX2Permeate
        {
            get { return _OptionsIXIX2Permeate; }
            set { _OptionsIXIX2Permeate = value; }
        }
        public float OptionsIXIX2Productivity
        {
            get { return _OptionsIXIX2Productivity; }
            set { _OptionsIXIX2Productivity = value; }
        }
        #endregion

        #region Вартості і питомі витрати реагентів
        // Вартості і питомі витрати реагентів
        ProjectPrices OptionsPrices;
        [XmlIgnoreAttribute]
        public ICollectionView OptionsPricesData { get; private set; }

        //public ProjectPrices OptionsPrices
        //{
        //    get { return _OptionsPrices.Data; }
        //    set { _OptionsPrices = value; }
        //}
        #endregion

    }
}