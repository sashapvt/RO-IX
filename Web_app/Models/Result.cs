using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RO_IX;

namespace Web_app.Models
{
    public class Result
    {
        public Result(Project project)
        {
            ProjectData = project;
            CalculateData = new Calculate(project);
        }
        public Project ProjectData { get; private set; }
        public RO_IX.Calculate CalculateData { get; private set; }
    }
}