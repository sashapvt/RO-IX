using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using System.Xml.Serialization;

namespace RO_IX
{
    public class Project : ProjectBase, INotifyPropertyChanged
    {
        // Public consructor
        public Project() : base()
        {
            OptionsPricesDataView = CollectionViewSource.GetDefaultView(OptionsPricesData);
        }


        #region Вартості і питомі витрати реагентів
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