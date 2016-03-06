using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RO_IX;

namespace Web_app.Models
{
    public class Project : ProjectBase
    {
        public int Id { get; set; }
        public virtual ICollection<ProjectPrice> ProjectPrices { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

    public class ProjectPrice : ProjectPricesItem
    {
        public virtual Project Project { get; set; }
    }
}