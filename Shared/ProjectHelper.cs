using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using TemplateEngine;

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
            Proj.New();

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
            string TemplateFileName = Directory.GetCurrentDirectory() + "\\ReportTemplate.html";
            string ReportFileName = Directory.GetCurrentDirectory() + "\\Report.html";

            // Проводимо розрахунок продуктивності систем очистки
            CalculateProductivity();

            // Заповнення полів шаблону
            Template ReportTemplate = new Template(TemplateFileName, false);
            // Вихідні дані
            ReportTemplate.Set("ProjectName", Proj.ProjectName);
            ReportTemplate.Set("ProjectDate", Proj.ProjectDate.ToShortDateString());
            ReportTemplate.Set("ProjectComment", Proj.ProjectComment);
            ReportTemplate.Set("BoilerName", Proj.BoilerName);
            ReportTemplate.Set("BolerPower", Proj.BolerPower.ToString());
            ReportTemplate.Set("BoilerProductivity", Proj.BoilerProductivity.ToString());
            ReportTemplate.Set("BoilerPressure", Proj.BoilerPressure.ToString());
            ReportTemplate.Set("BoilerEfficiency", Proj.BoilerEfficiency.ToString());
            ReportTemplate.Set("WaterInConductivity", Proj.WaterInConductivity.ToString());
            ReportTemplate.Set("WaterInHardness", Proj.WaterInHardness.ToString());
            ReportTemplate.Set("WaterInTemperature", Proj.WaterInTemperature.ToString());
            ReportTemplate.Set("WaterCondensateReturn", Proj.WaterCondensateReturn.ToString());
            ReportTemplate.Set("WaterCondensateConductivity", Proj.WaterCondensateConductivity.ToString());
            ReportTemplate.Set("WaterCondensateTemperature", Proj.WaterCondensateTemperature.ToString());
            ReportTemplate.Set("WaterROConductivity", Proj.WaterROConductivity.ToString());
            ReportTemplate.Set("WaterROConductivityMax", Proj.WaterROConductivityMax.ToString());
            ReportTemplate.Set("WaterIXConductivity", Proj.WaterIXConductivity.ToString());
            ReportTemplate.Set("WaterIXConductivityMax", Proj.WaterIXConductivityMax.ToString());
            // Результати розрахунку: водно-хімічний режим
            ReportTemplate.Set("BoilerBlowdownRO", Calc.BoilerBlowdownRO.ToString("P"));
            ReportTemplate.Set("BoilerBlowdownIX", Calc.BoilerBlowdownIX.ToString("P"));
            ReportTemplate.Set("BoilerBlowdownFlowRO", Calc.BoilerBlowdownFlowRO.ToString("F"));
            ReportTemplate.Set("BoilerBlowdownFlowIX", Calc.BoilerBlowdownFlowIX.ToString("F"));
            ReportTemplate.Set("BoilerBlowdownSteamRO", Calc.BoilerBlowdownSteamRO.ToString("F"));
            ReportTemplate.Set("BoilerBlowdownSteamIX", Calc.BoilerBlowdownSteamIX.ToString("F"));
            ReportTemplate.Set("BoilerBlowdownPowerRO", Calc.BoilerBlowdownPowerRO.ToString("F"));
            ReportTemplate.Set("BoilerBlowdownPowerIX", Calc.BoilerBlowdownPowerIX.ToString("F"));
            ReportTemplate.Set("BoilerBlowdownGasRO", Calc.BoilerBlowdownGasRO.ToString("F"));
            ReportTemplate.Set("BoilerBlowdownGasIX", Calc.BoilerBlowdownGasIX.ToString("F"));
            ReportTemplate.Set("BoilerBlowdownMoneyRO", Calc.BoilerBlowdownMoneyRO.ToString("F"));
            ReportTemplate.Set("BoilerBlowdownMoneyIX", Calc.BoilerBlowdownMoneyIX.ToString("F"));
            ReportTemplate.Set("BoilerBlowdownMoneyAnnualRO", Calc.BoilerBlowdownMoneyAnnualRO.ToString("N0"));
            ReportTemplate.Set("BoilerBlowdownMoneyAnnualIX", Calc.BoilerBlowdownMoneyAnnualIX.ToString("N0"));
            // Результати розрахунку: водопідготовка
            ReportTemplate.Set("OptionsRORawProductivity", Proj.OptionsRORawProductivity.ToString("F"));
            ReportTemplate.Set("OptionsIXRawProductivity", Proj.OptionsIXRawProductivity.ToString("F"));
            ReportTemplate.Set("OptionsROIXProductivity", Proj.OptionsROIXProductivity.ToString("F"));
            ReportTemplate.Set("OptionsIXIX2Productivity", Proj.OptionsIXIX2Productivity.ToString("F"));
            ReportTemplate.Set("ReportElectricityMoneyAnnualRO", Calc.ReportElectricityMoneyAnnualRO.ToString("N0"));
            ReportTemplate.Set("ReportElectricityMoneyAnnualIX", Calc.ReportElectricityMoneyAnnualIX.ToString("N0"));
            ReportTemplate.Set("ReportAntiscalantMoneyAnnualRO", Calc.ReportAntiscalantMoneyAnnualRO.ToString("N0"));
            ReportTemplate.Set("ReportCIPMoneyAnnualRO", Calc.ReportCIPMoneyAnnualRO.ToString("N0"));
            ReportTemplate.Set("ReportSaltMoneyAnnualRO", Calc.ReportSaltMoneyAnnualRO.ToString("N0"));
            ReportTemplate.Set("ReportSaltMoneyAnnualIX", Calc.ReportSaltMoneyAnnualIX.ToString("N0"));
            ReportTemplate.Set("ReportNaOClMoneyAnnualRO", Calc.ReportNaOClMoneyAnnualRO.ToString("N0"));
            ReportTemplate.Set("ReportNaOClMoneyAnnualIX", Calc.ReportNaOClMoneyAnnualIX.ToString("N0"));
            ReportTemplate.Set("ReportHClMoneyAnnualRO", Calc.ReportHClMoneyAnnualRO.ToString("N0"));
            ReportTemplate.Set("ReportHClMoneyAnnualIX", Calc.ReportHClMoneyAnnualIX.ToString("N0"));
            ReportTemplate.Set("ReportNaOHMoneyAnnualRO", Calc.ReportNaOHMoneyAnnualRO.ToString("N0"));
            ReportTemplate.Set("ReportNaOHMoneyAnnualIX", Calc.ReportNaOHMoneyAnnualIX.ToString("N0"));
            ReportTemplate.Set("ReportMembranesROMoneyAnnualRO", Calc.ReportMembranesROMoneyAnnualRO.ToString("N0"));
            ReportTemplate.Set("ReportMembranesUFMoneyAnnualRO", Calc.ReportMembranesUFMoneyAnnualRO.ToString("N0"));
            ReportTemplate.Set("ReportMembranesUFMoneyAnnualIX", Calc.ReportMembranesUFMoneyAnnualIX.ToString("N0"));
            ReportTemplate.Set("ReportResineUFMoneyAnnualRO", Calc.ReportResineUFMoneyAnnualRO.ToString("N0"));
            ReportTemplate.Set("ReportResineUFMoneyAnnualIX", Calc.ReportResineUFMoneyAnnualIX.ToString("N0"));
            ReportTemplate.Set("ReportWaterTotalMoneyAnnualRO", Calc.ReportWaterTotalMoneyAnnualRO.ToString("N0"));
            ReportTemplate.Set("ReportWaterTotalMoneyAnnualIX", Calc.ReportWaterTotalMoneyAnnualIX.ToString("N0"));
            ReportTemplate.Set("ReportTotalMoneyAnnualDifference", Math.Abs(Calc.ReportTotalMoneyAnnualDifference).ToString("N0"));
            ReportTemplate.Set("ReportOptimalCase", Calc.ReportOptimalCase);

            // Запис у результатів розрахунку проекту у файл звіту в форматі HTML
            using (TextWriter ReportWriter = new StreamWriter(ReportFileName))
            {
                ReportWriter.Write(ReportTemplate.ToString());
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
