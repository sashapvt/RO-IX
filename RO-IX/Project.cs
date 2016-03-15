using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Xml.Serialization;

namespace RO_IX
{
    public class Project : ProjectBase, INotifyPropertyChanged
    {
        // Public consructor
        public Project() : base()
        {
        }

        #region Інформація про проект
        // Інформація про проект
        private string projectName;
        private decimal projectCurRate;
        private string projectComment;
        private DateTime projectDate;
        public override string ProjectName { get { return projectName; } set { SetProperty(ref projectName, value); } }
        public override decimal ProjectCurRate { get { return projectCurRate; } set { SetProperty(ref projectCurRate, value); } }
        public override string ProjectComment { get { return projectComment; } set { SetProperty(ref projectComment, value); } }
        public override DateTime ProjectDate { get { return projectDate; } set { SetProperty(ref projectDate, value); } }
        #endregion

        #region Котел
        // Котел
        private string boilerName;
        private float bolerPower;
        private float boilerProductivity;
        private float boilerPressure;
        private float boilerEfficiency;
        private float boilerAnnnualLoad;
        public override string BoilerName { get { return boilerName; } set { SetProperty(ref boilerName, value); } }
        public override float BolerPower { get { return bolerPower; } set { SetProperty(ref bolerPower, value); } }
        public override float BoilerProductivity { get { return boilerProductivity; } set { SetProperty(ref boilerProductivity, value); } }
        public override float BoilerPressure { get { return boilerPressure; } set { SetProperty(ref boilerPressure, value); } }
        public override float BoilerEfficiency { get { return boilerEfficiency; } set { SetProperty(ref boilerEfficiency, value); } }
        public override float BoilerAnnnualLoad { get { return boilerAnnnualLoad; } set { SetProperty(ref boilerAnnnualLoad, value); } }
        #endregion

        #region Водно-хімічний режим
        // Водно-хімічний режим
        private float waterInConductivity;
        private float waterInHardness;
        private float waterInTemperature;
        private float waterCondensateReturn;
        private float waterCondensateConductivity;
        private float waterCondensateTemperature;
        private float waterROConductivity;
        private float waterROConductivityMax;
        private float waterIXConductivity;
        private float waterIXConductivityMax;
        public override float WaterInConductivity { get { return waterInConductivity; } set { SetProperty(ref waterInConductivity, value); } }
        public override float WaterInHardness { get { return waterInHardness; } set { SetProperty(ref waterInHardness, value); } }
        public override float WaterInTemperature { get { return waterInTemperature; } set { SetProperty(ref waterInTemperature, value); } }
        public override float WaterCondensateReturn { get { return waterCondensateReturn; } set { SetProperty(ref waterCondensateReturn, value); } }
        public override float WaterCondensateConductivity { get { return waterCondensateConductivity; } set { SetProperty(ref waterCondensateConductivity, value); } }
        public override float WaterCondensateTemperature { get { return waterCondensateTemperature; } set { SetProperty(ref waterCondensateTemperature, value); } }
        public override float WaterROConductivity { get { return waterROConductivity; } set { SetProperty(ref waterROConductivity, value); } }
        public override float WaterROConductivityMax { get { return waterROConductivityMax; } set { SetProperty(ref waterROConductivityMax, value); } }
        public override float WaterIXConductivity { get { return waterIXConductivity; } set { SetProperty(ref waterIXConductivity, value); } }
        public override float WaterIXConductivityMax { get { return waterIXConductivityMax; } set { SetProperty(ref waterIXConductivityMax, value); } }
        #endregion

        #region Налаштування (зворотній осмос)
        // Налаштування (зворотній осмос)
        private float optionsRORawProductivity;
        private bool optionsROUFOn;
        private float optionsROUFPermeate;
        private float optionsROUFProductivity;
        private bool optionsROROOn;
        private float optionsROROPermeate;
        private float optionsROROProductivity;
        private bool optionsROIXOn;
        private float optionsROIXPermeate;
        private float optionsROIXProductivity;
        private bool optionsROEditOn;
        public override float OptionsRORawProductivity { get { return optionsRORawProductivity; } set { SetProperty(ref optionsRORawProductivity, value); } }
        public override bool OptionsROUFOn { get { return optionsROUFOn; } set { SetProperty(ref optionsROUFOn, value); } }
        public override float OptionsROUFPermeate { get { return optionsROUFPermeate; } set { SetProperty(ref optionsROUFPermeate, value); } }
        public override float OptionsROUFProductivity { get { return optionsROUFProductivity; } set { SetProperty(ref optionsROUFProductivity, value); } }
        public override bool OptionsROROOn { get { return optionsROROOn; } set { SetProperty(ref optionsROROOn, value); } }
        public override float OptionsROROPermeate { get { return optionsROROPermeate; } set { SetProperty(ref optionsROROPermeate, value); } }
        public override float OptionsROROProductivity { get { return optionsROROProductivity; } set { SetProperty(ref optionsROROProductivity, value); } }
        public override bool OptionsROIXOn { get { return optionsROIXOn; } set { SetProperty(ref optionsROIXOn, value); } }
        public override float OptionsROIXPermeate { get { return optionsROIXPermeate; } set { SetProperty(ref optionsROIXPermeate, value); } }
        public override float OptionsROIXProductivity { get { return optionsROIXProductivity; } set { SetProperty(ref optionsROIXProductivity, value); } }
        public override bool OptionsROEditOn { get { return optionsROEditOn; } set { SetProperty(ref optionsROEditOn, value); } }
        #endregion

        #region Налаштування (пом'якшення)
        // Налаштування (пом'якшення)
        private float optionsIXRawProductivity;
        private bool optionsIXUFOn;
        private float optionsIXUFPermeate;
        private float optionsIXUFProductivity;
        private bool optionsIXIX1On;
        private float optionsIXIX1Permeate;
        private float optionsIXIX1Productivity;
        private bool optionsIXIX2On;
        private float optionsIXIX2Permeate;
        private float optionsIXIX2Productivity;
        private bool optionsIXEditOn;
        public override float OptionsIXRawProductivity { get { return optionsIXRawProductivity; } set { SetProperty(ref optionsIXRawProductivity, value); } }
        public override bool OptionsIXUFOn { get { return optionsIXUFOn; } set { SetProperty(ref optionsIXUFOn, value); } }
        public override float OptionsIXUFPermeate { get { return optionsIXUFPermeate; } set { SetProperty(ref optionsIXUFPermeate, value); } }
        public override float OptionsIXUFProductivity { get { return optionsIXUFProductivity; } set { SetProperty(ref optionsIXUFProductivity, value); } }
        public override bool OptionsIXIX1On { get { return optionsIXIX1On; } set { SetProperty(ref optionsIXIX1On, value); } }
        public override float OptionsIXIX1Permeate { get { return optionsIXIX1Permeate; } set { SetProperty(ref optionsIXIX1Permeate, value); } }
        public override float OptionsIXIX1Productivity { get { return optionsIXIX1Productivity; } set { SetProperty(ref optionsIXIX1Productivity, value); } }
        public override bool OptionsIXIX2On { get { return optionsIXIX2On; } set { SetProperty(ref optionsIXIX2On, value); } }
        public override float OptionsIXIX2Permeate { get { return optionsIXIX2Permeate; } set { SetProperty(ref optionsIXIX2Permeate, value); } }
        public override float OptionsIXIX2Productivity { get { return optionsIXIX2Productivity; } set { SetProperty(ref optionsIXIX2Productivity, value); } }
        public override bool OptionsIXEditOn { get { return optionsIXEditOn; } set { SetProperty(ref optionsIXEditOn, value); } }
        #endregion

        #region Вартості і питомі витрати реагентів
        // Вартості і питомі витрати реагентів
        private List<ProjectPricesItem> projectPrices;
        public List<ProjectPricesItem> ProjectPrices { get { return projectPrices; } set { SetProperty(ref projectPrices, value); OptionsPricesDataView = CollectionViewSource.GetDefaultView(ProjectPrices); } }

        public override List<ProjectPricesItem> GetProjectPrices()
        {
            return ProjectPrices;
        }

        public void SetProjectPrices(List<ProjectPricesItem> _projectPrices)
        {
            ProjectPrices = _projectPrices;
        }

        [XmlIgnoreAttribute]
        public ICollectionView OptionsPricesDataView { get; private set; }
        #endregion

        #region Implementation of "INotifyPropertyChanged"
        /// <summary>
        ///     Multicast event for property change notifications.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Checks if a property already matches a desired value.  Sets the property and
        ///     notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">
        ///     Name of the property used to notify listeners.  This
        ///     value is optional and can be provided automatically when invoked from compilers that
        ///     support CallerMemberName.
        /// </param>
        /// <returns>
        ///     True if the value was changed, false if the existing value matched the
        ///     desired value.
        /// </returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        ///     Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">
        ///     Name of the property used to notify listeners.  This
        ///     value is optional and can be provided automatically when invoked from compilers
        ///     that support <see cref="CallerMemberNameAttribute" />.
        /// </param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}