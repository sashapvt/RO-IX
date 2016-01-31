using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RO_IX
{
    // Клас зберігання рядка ресурсів та витрат реагентів
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

        public ProjectPricesItem(int _Id, string _Name, decimal _Price, float _UF, float _RO, float _IX1, float _IX2)
        {
            Id = _Id;
            Name = _Name;
            Price = _Price;
            UF = _UF;
            RO = _RO;
            IX1 = _IX1;
            IX2 = _IX2;
        }
    }
}
