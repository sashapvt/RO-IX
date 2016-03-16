using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RO_IX;
using System.ComponentModel;

namespace Web_app.Models
{
    public class ProjectPrice : ProjectPricesItem
    {
        public int Id { get; set; }

        public override string Name { get; set; }
        public override decimal Price { get; set; }
        public override float UF { get; set; }
        public override float RO { get; set; }
        public override float IX1 { get; set; }
        public override float IX2 { get; set; }

        public virtual Project Project { get; set; }
    }
}