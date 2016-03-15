using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Data;

namespace RO_IX
{
    public class ProjectHelper
    {
        // Main project class instance
        public Project Proj;

        // Calculation of current project
        Calculate Calc;

        // Project file name & path
        public string ProjFile = "";

        // Новий проект
        public void ProjectNew()
        {
            Proj = new Project();
            //
            Proj.New();
            Proj.SetProjectPrices(ProjectPricesItem.ProjectPricesNew());

            // Проект для якого буде проводитися розрахунок (поточний проект)
            Calc = new Calculate(Proj);

            OnProjectChanged(EventArgs.Empty);
        }

        // Відкрити проект
        public void ProjectOpen()
        {
            // Вибір файлу для відкриття
            Microsoft.Win32.OpenFileDialog OpenDial = new Microsoft.Win32.OpenFileDialog();
            OpenDial.FileName = "Project1"; // Default file name 
            OpenDial.DefaultExt = ".xml"; // Default file extension 
            OpenDial.Filter = "Project documents (.xml)|*.xml"; // Filter files by extension 
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = OpenDial.ShowDialog();

            // Get the selected file name 
            if (result == true)
            {
                // Save file name & path to variable 
                ProjFile = OpenDial.FileName;

                // Construct an instance of the XmlSerializer with the type
                // of object that is being deserialized.
                XmlSerializer ProjectSerializer = new XmlSerializer(typeof(Project));
                // To read the file, create a FileStream.
                using (FileStream ProjectFileStream = new FileStream(ProjFile, FileMode.Open))
                {
                    // Call the Deserialize method and cast to the object type.
                    Proj = new Project();
                    Proj = (Project)ProjectSerializer.Deserialize(ProjectFileStream);
                }
            }

            // Проект для якого буде проводитися розрахунок (поточний проект)
            Calc = new Calculate(Proj);

            OnProjectChanged(EventArgs.Empty);
        }

        // Зберегти проект
        public void ProjectSave(bool IsSaveAs = false)
        {
            // Вибір файлу для збереження, якщо виконуються необхідні умови
            if (ProjFile == "" || IsSaveAs)
            {
                Microsoft.Win32.SaveFileDialog SaveDial = new Microsoft.Win32.SaveFileDialog();
                SaveDial.FileName = "Project1"; // Default file name 
                SaveDial.DefaultExt = ".xml"; // Default file extension 
                SaveDial.Filter = "Project documents (.xml)|*.xml"; // Filter files by extension 
                // Display OpenFileDialog by calling ShowDialog method 
                Nullable<bool> result = SaveDial.ShowDialog();

                // Get the selected file name 
                if (result == true)
                {
                    // Save file name & path to variable 
                    ProjFile = SaveDial.FileName;
                }
            }

            // Insert code to set properties and fields of the object.
            XmlSerializer ProjectSerializer = new XmlSerializer(typeof(Project));
            // To write to a file, create a StreamWriter object.
            using (TextWriter ProjectWriter = new StreamWriter(ProjFile))
            {
                ProjectSerializer.Serialize(ProjectWriter, Proj);
                ProjectWriter.Close();
            }
        }

        // Розрахунок проекту з записом результату у файл
        public string ProjectCalculate()
        {
            // Налаштування файлів
            string TemplateFileName = Directory.GetCurrentDirectory() + "\\ReportTemplate.chhtml";
            string ReportFileName = Directory.GetCurrentDirectory() + "\\Report.html";
            LiteRazorReport LRR;

            // Проводимо розрахунок продуктивності систем очистки
            CalculateProductivity();

            // Заповнення полів шаблону
            LRR = new LiteRazorReport(File.ReadAllText(TemplateFileName));
            LRR.Vars.Add("w", "World");
            // Вихідні дані
            LRR.Vars.Add("ProjectName", Proj.ProjectName);
            LRR.Vars.Add("ProjectDate", Proj.ProjectDate.ToShortDateString());
            LRR.Vars.Add("ProjectComment", Proj.ProjectComment);
            LRR.Vars.Add("BoilerName", Proj.BoilerName);
            LRR.Vars.Add("BolerPower", Proj.BolerPower.ToString());
            LRR.Vars.Add("BoilerProductivity", Proj.BoilerProductivity.ToString());
            LRR.Vars.Add("BoilerPressure", Proj.BoilerPressure.ToString());
            LRR.Vars.Add("BoilerEfficiency", Proj.BoilerEfficiency.ToString());
            LRR.Vars.Add("WaterInConductivity", Proj.WaterInConductivity.ToString());
            LRR.Vars.Add("WaterInHardness", Proj.WaterInHardness.ToString());
            LRR.Vars.Add("WaterInTemperature", Proj.WaterInTemperature.ToString());
            LRR.Vars.Add("WaterCondensateReturn", Proj.WaterCondensateReturn.ToString());
            LRR.Vars.Add("WaterCondensateConductivity", Proj.WaterCondensateConductivity.ToString());
            LRR.Vars.Add("WaterCondensateTemperature", Proj.WaterCondensateTemperature.ToString());
            LRR.Vars.Add("WaterROConductivity", Proj.WaterROConductivity.ToString());
            LRR.Vars.Add("WaterROConductivityMax", Proj.WaterROConductivityMax.ToString());
            LRR.Vars.Add("WaterIXConductivity", Proj.WaterIXConductivity.ToString());
            LRR.Vars.Add("WaterIXConductivityMax", Proj.WaterIXConductivityMax.ToString());
            // Результати розрахунку: водно-хімічний режим
            LRR.Vars.Add("BoilerBlowdownRO", Calc.BoilerBlowdownRO.ToString("P"));
            LRR.Vars.Add("BoilerBlowdownIX", Calc.BoilerBlowdownIX.ToString("P"));
            LRR.Vars.Add("BoilerBlowdownFlowRO", Calc.BoilerBlowdownFlowRO.ToString("F"));
            LRR.Vars.Add("BoilerBlowdownFlowIX", Calc.BoilerBlowdownFlowIX.ToString("F"));
            LRR.Vars.Add("BoilerBlowdownSteamRO", Calc.BoilerBlowdownSteamRO.ToString("F"));
            LRR.Vars.Add("BoilerBlowdownSteamIX", Calc.BoilerBlowdownSteamIX.ToString("F"));
            LRR.Vars.Add("BoilerBlowdownPowerRO", Calc.BoilerBlowdownPowerRO.ToString("F"));
            LRR.Vars.Add("BoilerBlowdownPowerIX", Calc.BoilerBlowdownPowerIX.ToString("F"));
            LRR.Vars.Add("BoilerBlowdownGasRO", Calc.BoilerBlowdownGasRO.ToString("F"));
            LRR.Vars.Add("BoilerBlowdownGasIX", Calc.BoilerBlowdownGasIX.ToString("F"));
            LRR.Vars.Add("BoilerBlowdownMoneyRO", Calc.BoilerBlowdownMoneyRO.ToString("F"));
            LRR.Vars.Add("BoilerBlowdownMoneyIX", Calc.BoilerBlowdownMoneyIX.ToString("F"));
            LRR.Vars.Add("BoilerBlowdownMoneyAnnualRO", Calc.BoilerBlowdownMoneyAnnualRO.ToString("N0"));
            LRR.Vars.Add("BoilerBlowdownMoneyAnnualIX", Calc.BoilerBlowdownMoneyAnnualIX.ToString("N0"));
            // Результати розрахунку: водопідготовка
            LRR.Vars.Add("OptionsRORawProductivity", Proj.OptionsRORawProductivity.ToString("F"));
            LRR.Vars.Add("OptionsIXRawProductivity", Proj.OptionsIXRawProductivity.ToString("F"));
            LRR.Vars.Add("OptionsROIXProductivity", Proj.OptionsROIXProductivity.ToString("F"));
            LRR.Vars.Add("OptionsIXIX2Productivity", Proj.OptionsIXIX2Productivity.ToString("F"));
            LRR.Vars.Add("ReportElectricityMoneyAnnualRO", Calc.ReportElectricityMoneyAnnualRO.ToString("N0"));
            LRR.Vars.Add("ReportElectricityMoneyAnnualIX", Calc.ReportElectricityMoneyAnnualIX.ToString("N0"));
            LRR.Vars.Add("ReportAntiscalantMoneyAnnualRO", Calc.ReportAntiscalantMoneyAnnualRO.ToString("N0"));
            LRR.Vars.Add("ReportCIPMoneyAnnualRO", Calc.ReportCIPMoneyAnnualRO.ToString("N0"));
            LRR.Vars.Add("ReportSaltMoneyAnnualRO", Calc.ReportSaltMoneyAnnualRO.ToString("N0"));
            LRR.Vars.Add("ReportSaltMoneyAnnualIX", Calc.ReportSaltMoneyAnnualIX.ToString("N0"));
            LRR.Vars.Add("ReportNaOClMoneyAnnualRO", Calc.ReportNaOClMoneyAnnualRO.ToString("N0"));
            LRR.Vars.Add("ReportNaOClMoneyAnnualIX", Calc.ReportNaOClMoneyAnnualIX.ToString("N0"));
            LRR.Vars.Add("ReportHClMoneyAnnualRO", Calc.ReportHClMoneyAnnualRO.ToString("N0"));
            LRR.Vars.Add("ReportHClMoneyAnnualIX", Calc.ReportHClMoneyAnnualIX.ToString("N0"));
            LRR.Vars.Add("ReportNaOHMoneyAnnualRO", Calc.ReportNaOHMoneyAnnualRO.ToString("N0"));
            LRR.Vars.Add("ReportNaOHMoneyAnnualIX", Calc.ReportNaOHMoneyAnnualIX.ToString("N0"));
            LRR.Vars.Add("ReportMembranesROMoneyAnnualRO", Calc.ReportMembranesROMoneyAnnualRO.ToString("N0"));
            LRR.Vars.Add("ReportMembranesUFMoneyAnnualRO", Calc.ReportMembranesUFMoneyAnnualRO.ToString("N0"));
            LRR.Vars.Add("ReportMembranesUFMoneyAnnualIX", Calc.ReportMembranesUFMoneyAnnualIX.ToString("N0"));
            LRR.Vars.Add("ReportResineUFMoneyAnnualRO", Calc.ReportResineUFMoneyAnnualRO.ToString("N0"));
            LRR.Vars.Add("ReportResineUFMoneyAnnualIX", Calc.ReportResineUFMoneyAnnualIX.ToString("N0"));
            LRR.Vars.Add("ReportWaterTotalMoneyAnnualRO", Calc.ReportWaterTotalMoneyAnnualRO.ToString("N0"));
            LRR.Vars.Add("ReportWaterTotalMoneyAnnualIX", Calc.ReportWaterTotalMoneyAnnualIX.ToString("N0"));
            LRR.Vars.Add("ReportTotalMoneyAnnualDifference", Math.Abs(Calc.ReportTotalMoneyAnnualDifference).ToString("N0"));
            LRR.Vars.Add("ReportOptimalCase", Calc.ReportOptimalCase);

            // Запис у результатів розрахунку проекту у файл звіту в форматі HTML
            using (TextWriter ReportWriter = new StreamWriter(ReportFileName))
            {
                ReportWriter.Write(LRR.Report());
                ReportWriter.Close();
            }

            // Відображення результатів розрахунку
            return ReportFileName;
        }

        // Проводимо розрахунок продуктивності систем очистки
        public void CalculateProductivity()
        {
            Calc.CalculateProductivity();
        }
        
        // Зміна активного проекту
        protected virtual void OnProjectChanged(EventArgs e)
        {
            EventHandler handler = ProjectChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler ProjectChanged;

    }
}
