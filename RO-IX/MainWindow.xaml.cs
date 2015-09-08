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

            // Для відладки
            TabControlProject.SelectedIndex = 2;
        }

        // Main project class instance
        public Project Proj;

        //Project file name & path
        public string ProjFile = "";

        // Новий проект
        private void ProjectNew()
        {
            Proj = new Project();
            // Ініціалізація нового проекту
            Proj.ProjectName = "Project1";
            Proj.ProjectComment = "no comments";
            Proj.ProjectDate = DateTime.Now;

            // Параметри котла
            Proj.BolerPower = 6888;
            Proj.BoilerProductivity = 10;
            Proj.BoilerPressure = 10.3f;
            Proj.BoilerEfficiency = 94.6f;

            // Водно-хімічний режим
            Proj.WaterInConductivity = 700;
            Proj.WaterInHardness = 5;
            Proj.WaterInTemperature = 12;
            Proj.WaterCondensateReturn = 0;
            Proj.WaterCondensateConductivity = 20;
            Proj.WaterCondensateTemperature = 70;
            Proj.WaterROConductivity = 20;
            Proj.WaterROConductivityMax = 2000;
            Proj.WaterIXConductivity = 700;
            Proj.WaterIXConductivityMax = 4500;

            // Налаштування (зворотній осмос)
            Proj.OptionsROUFPermeate = 93;
            Proj.OptionsROROPermeate = 75;
            Proj.OptionsROIXPermeate = 98;
            
            // Налаштування (пом'якшення)
            Proj.OptionsIXUFPermeate = 93;
            Proj.OptionsIXIX1Permeate = 95;
            Proj.OptionsIXIX2Permeate = 98;

            // Вартості ресурсів та витрат реагентів
            Proj.OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(0, "Газ, м3", 0.40m, 0F, 0F, 0F, 0F, true));
            Proj.OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(1, "Електроенергія, кВт", 0.10m, 0F, 0F, 0F, 0F, false));
            Proj.OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(2, "Сіль таблетована, кг", 0.00m, 0F, 0F, 0F, 0F, false));
            Proj.OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(3, "Антискалант, г", 0.00m, 0F, 0F, 0F, 0F, false));
            Proj.OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(4, "Реаг. хімпром, г ", 0.00m, 0F, 0F, 0F, 0F, false));
            Proj.OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(5, "NaOCl, 19%, г", 0.00m, 0F, 0F, 0F, 0F, false));
            Proj.OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(6, "HCl, 35%, г", 0.00m, 0F, 0F, 0F, 0F, false));
            Proj.OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(7, "NaOH, 45%, г", 0.00m, 0F, 0F, 0F, 0F, false));
            Proj.OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(8, "Мембрана МО, шт", 0.00m, 0F, 0F, 0F, 0F, false));
            Proj.OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(9, "Мембрана УФ, шт", 0.00m, 0F, 0F, 0F, 0F, false));
            Proj.OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem(10, "Катіоніт, л", 0.00m, 0F, 0F, 0F, 0F, false));
            DataContext = Proj;
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
            
            // Розрахунок

            // Заповнення полів шаблону
            Template ReportTemplate = new Template(TemplateFileName, false);
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

        // Зміна активної вкладки
        private void TabControlProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Якщо вибрана вкладка "Розрахунок" запустити підпрограму розрахунку
            if (TabControlProject.SelectedIndex == 2) ProjectCalculate();
        }
    }
}
