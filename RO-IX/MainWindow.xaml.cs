using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Ribbon;
using System.Xml.Serialization;
using System.IO;
using TemplateEngine;

namespace RO_IX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Init main form
        public MainWindow()
        {
            InitializeComponent();

            // Старт нового проекту
            ProjectNew();

            // Проект для якого буде проводитися розрахунок (поточний проект)
            Calc = new Calculate(Proj);
            
            // Для відладки
            // TabControlProject.SelectedIndex = 2;
        }

        // Main project class instance
        public Project Proj;

        // Calculation of current project
        Calculate Calc;

        // Project file name & path
        public string ProjFile = "";

        // Новий проект
        private void ProjectNew()
        {
            Proj = new Project();
            Proj.New();
            DataContext = Proj;

            // Робимо активною вкладку "Вихідні дані"
            TabControlProject.SelectedIndex = 0;
        }

        // Відкрити проект
        private void ProjectOpen()
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
                    DataContext = Proj;

                    // Робимо активною вкладку "Вихідні дані"
                    TabControlProject.SelectedIndex = 0;
                }
            }
        }

        // Зберегти проект
        private void ProjectSave(bool IsSaveAs = false)
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

        // Розрахунок проекту з відображенням результату у відповідній вкладці
        private void ProjectCalculate()
        {
            // Налаштування файлів
            string TemplateFileName = Directory.GetCurrentDirectory() + "\\ReportTemplate.html";
            string ReportFileName = Directory.GetCurrentDirectory() + "\\Report.html";

            // Проводимо розрахунок продуктивності систем очистки
            Calc.CalculateProductivity();

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

            WebBrowserCalc.Navigate("file:///" + ReportFileName);
        }

        // Change fields headers name & width, disable column "Name" edit, hide Id column in DataGridProjectPrices
        private void DataGridProjectPrices_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();

            //update column details when generating
            if (headername == "Id")
            {
                e.Column.Visibility = System.Windows.Visibility.Hidden;
            }
            if (headername == "Name")
            {
                e.Column.Header = "Назва";
                e.Column.Width = 130;
                e.Column.IsReadOnly = true;
            }
            else if (headername == "Price")
            {
                e.Column.Header = "Ціна, $";
                e.Column.Width = 75;
            }
            else if (headername == "UF")
            {
                e.Column.Header = "УФ";
                e.Column.Width = 75;
            }
            else if (headername == "RO")
            {
                e.Column.Header = "Осмос";
                e.Column.Width = 75;
            }
            else if (headername == "IX1")
            {
                e.Column.Header = "Іонний І-ст";
                e.Column.Width = 75;
            }
            else if (headername == "IX2")
            {
                e.Column.Header = "Іонний ІІ-ст";
                e.Column.Width = 75;
            }
        }

        // Новий проект (виклик з меню)
        private void MenuNew_Click(object sender, RoutedEventArgs e)
        {
            // Старт нового проекту
            ProjectNew();
        }

        // Відкрити проект... (виклик з меню)
        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            // Виклик нового проекту
            ProjectOpen();
        }

        // Зберегти проект (виклик з меню)
        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            // Збереження проекту
            ProjectSave();
        }

        // Зберегти проект як... (виклик з меню)
        private void MenuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            // Збереження проекту з вибором файлу
            ProjectSave(true);
        }

        // Вихід з програми (виклик з меню)
        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Друк результатів розрахунку для друку (виклик з меню)
        private void MenuPrint_Click(object sender, RoutedEventArgs e)
        {
            mshtml.IHTMLDocument2 doc = this.WebBrowserCalc.Document as mshtml.IHTMLDocument2;
            doc.execCommand("Print", true, null);
        }

        // Зміна активної вкладки
        private void TabControlProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Якщо вибрана вкладка "Налаштування" провести при необхідності розрахунок продуктивності систем очистки
            if (TabControlProject.SelectedIndex == 1) Calc.CalculateProductivity();

            // Якщо вибрана вкладка "Розрахунок" запустити підпрограму розрахунку
            if (TabControlProject.SelectedIndex == 2) ProjectCalculate();

            // Перевірка можливості друку результатів розрахунку
            if (TabControlProject.SelectedIndex == 2)
            {
                this.MenuPrint.IsEnabled = true;
                this.ButtonPrint.IsEnabled = true;
                this.ButtonPrintImage.Opacity = 1.0;
            }
            else
            {
                this.MenuPrint.IsEnabled = false;
                this.ButtonPrint.IsEnabled = false;
                this.ButtonPrintImage.Opacity = 0.5;
            }
        }

        private void eventCalculateProductivityIsNeeded(object sender, RoutedEventArgs e)
        {
            // Проводимо розрахунок продуктивності систем очистки
            Calc.CalculateProductivity();
        }
    }
}
