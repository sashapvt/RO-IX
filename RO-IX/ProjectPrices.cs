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
            Data.Add(new ProjectPricesItem("Газ", 8.78m, 0F, 0F, 0F, 0F));
        }

        // Клас зберігання рядка данних
        public class ProjectPricesItem
        {
            string _Name;
            decimal _Price;
            float _UF, _RO, _IX1, _IX2;
            public string Name
            {
                get { return _Name; }
            }
            public decimal Price
            {
                get { return _Price; }
                set { _Price = value; }
            }
            public float UF
            {
                get { return _UF; }
                set { _UF = value; }
            }
            public float RO
            {
                get { return _RO; }
                set { _RO = value; }
            }
            public float IX1
            {
                get { return _IX1; }
                set { _IX1 = value; }
            }
            public float IX2
            {
                get { return _IX2; }
                set { _IX2 = value; }
            }

            public ProjectPricesItem(string __Name, decimal __Price, float __UF, float __RO, float __IX1, float __IX2)
            {
                _Name = __Name;
                _Price = __Price;
                _UF = __UF;
                _RO = __RO;
                _IX1 = __IX1;
                _IX2 = __IX2;
            }
        }
    }
}
