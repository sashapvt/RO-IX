using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO_IX
{
    // TODO: Розробити клас вартості ресурсів та витрат реагентів
    public class ProjectPrices
    {
        public List<ProjectPricesItem> Data; // Колекція стовпців таблиці

        // Конструктор
        public ProjectPrices()
        {
            Data = new List<ProjectPricesItem>();
         }

        // Клас зберігання рядка данних
        public class ProjectPricesItem
        {
            string _Name;
            decimal _Price;
            float _UF, _RO, _IX1, _IX2;
            bool _IsPriceOnly;
            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }
            public decimal Price
            {
                get { return _Price; }
                set { _Price = value; }
            }
            public float UF
            {
                get { return _UF; }
                set { if (!_IsPriceOnly) _UF = value; }
            }
            public float RO
            {
                get { return _RO; }
                set { if (!_IsPriceOnly) _RO = value; }
            }
            public float IX1
            {
                get { return _IX1; }
                set { if (!_IsPriceOnly) _IX1 = value; }
            }
            public float IX2
            {
                get { return _IX2; }
                set { if (!_IsPriceOnly) _IX2 = value; }
            }

            // Конструктор без параметрів для можливості серіалізації цього класу
            public ProjectPricesItem() { }

            public ProjectPricesItem(string __Name, decimal __Price, float __UF, float __RO, float __IX1, float __IX2, bool __IsPriceOnly)
            {
                _Name = __Name;
                _Price = __Price;
                _UF = __UF;
                _RO = __RO;
                _IX1 = __IX1;
                _IX2 = __IX2;
                _IsPriceOnly = __IsPriceOnly;
            }
        }
    }
}
