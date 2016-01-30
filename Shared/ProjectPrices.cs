using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO_IX
{
    // Клас вартості ресурсів та витрат реагентів
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
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public float UF { get; set; }
            public float RO { get; set; }
            public float IX1 { get; set; }
            public float IX2 { get; set; }

            // Конструктор без параметрів для можливості серіалізації цього класу
            public ProjectPricesItem() { }

            public ProjectPricesItem(int __Id, string __Name, decimal __Price, float __UF, float __RO, float __IX1, float __IX2)
            {
                Id = __Id;
                Name = __Name;
                Price = __Price;
                UF = __UF;
                RO = __RO;
                IX1 = __IX1;
                IX2 = __IX2;
            }
        }
    }
}
