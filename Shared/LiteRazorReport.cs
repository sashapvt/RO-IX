using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class LiteRazorReport
    {
        public LiteRazorReport(String _template)
        {
            Template = _template;
            Vars = new Dictionary<String, String>();
        }

        public String Template;
        public Dictionary<String, String> Vars;

        public string Report()
        {
            report = new StringBuilder(Template.Length);
            Boolean varDetected = false;
            Boolean lastAt = false;
            String varName = "";

            foreach (Char ch in Template)
            {
                if (!Char.IsLetterOrDigit(ch))
                {
                    varDetected = false;
                    if (varName != "")
                    {
                        if (Vars.ContainsKey(varName)) report.Append(Vars[varName]);
                        varName = "";
                    }
                }
                if (ch.CompareTo('@') == 0)
                {
                    if (lastAt)
                    {
                        report.Append(ch);
                        lastAt = false;
                    }
                    else
                    {
                        varDetected = true;
                        lastAt = true;
                    }
                }
                else
                {
                    lastAt = false;
                    if (!varDetected) report.Append(ch); else varName += ch;
                }
            }
            if (varName != "")
            {
                if (Vars.ContainsKey(varName)) report.Append(Vars[varName]);
                varName = "";
            }
            return report.ToString();
        }

        private StringBuilder report;
    }
}
