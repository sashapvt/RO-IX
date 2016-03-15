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
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual float UF { get; set; }
        public virtual float RO { get; set; }
        public virtual float IX1 { get; set; }
        public virtual float IX2 { get; set; }

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

        // Вартості ресурсів та витрати реагентів
        // ProjectPricesItem(0, "Назва", ціна, витрата для МУ, витрата для МО, витрата для ФУ1, витрата для УФ2);
        public static List<ProjectPricesItem> ProjectPricesNew()
        {
            List<ProjectPricesItem> ProjectPrices = new List<ProjectPricesItem>();
            ProjectPrices.Add(new ProjectPricesItem(0, "Газ, м3", 0.40m, 0F, 0F, 0F, 0F));
            ProjectPrices.Add(new ProjectPricesItem(1, "Електроенергія, кВт", 0.10m, 0.07F, 0.7F, 0.01F, 0.01F));
            ProjectPrices.Add(new ProjectPricesItem(2, "Сіль таблетована, кг", 0.27m, 0F, 0F, 0.7F, 0.01F));
            ProjectPrices.Add(new ProjectPricesItem(3, "Антискалант, кг", 5.33m, 0F, 0.008F, 0F, 0F));
            ProjectPrices.Add(new ProjectPricesItem(4, "Реаг. хімпром, кг ", 8.40m, 0F, 0.0016F, 0F, 0F));
            ProjectPrices.Add(new ProjectPricesItem(5, "NaOCl, 19%, кг", 0.35m, 0.018F, 0F, 0F, 0F));
            ProjectPrices.Add(new ProjectPricesItem(6, "HCl, 35%, кг", 0.14m, 0.0035F, 0F, 0F, 0F));
            ProjectPrices.Add(new ProjectPricesItem(7, "NaOH, 45%, кг", 0.35m, 0.013F, 0F, 0F, 0F));
            ProjectPrices.Add(new ProjectPricesItem(8, "Мембрана МО, шт", 1142.00m, 0F, 5F, 0F, 0F)); // Ціна за одну мембрану XLE-440, період заміни, роки
            ProjectPrices.Add(new ProjectPricesItem(9, "Мембрана УФ, шт", 2600.00m, 5F, 0F, 0F, 0F)); // Ціна за одну мембрану SFP2880, період заміни, роки
            ProjectPrices.Add(new ProjectPricesItem(10, "Катіоніт, л", 3.96m, 0F, 0F, 5F, 7F)); // Ціна за один л HCRS/S, період заміни, роки
            return ProjectPrices;
        }
    }
}
