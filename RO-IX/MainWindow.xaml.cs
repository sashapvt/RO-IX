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
        }

        // Main project class instance
        public Project Proj;

        // Новий проект
        private void ProjectNew()
        {
            Proj = new Project();
            // Initialisation of new project
            Proj.ProjectName = "Project1";
            Proj.ProjectComment = "no comments";
            Proj.ProjectDate = DateTime.Now;
            Proj.OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem("Газ, м3", 0.40m, 0F, 0F, 0F, 0F, true));
            Proj.OptionsPricesData.Add(new ProjectPrices.ProjectPricesItem("Електроенергія, кВт", 0.10m, 0F, 0F, 0F, 0F, false));
            DataContext = Proj;
        }

        // Відкрити проект
        private void ProjectOpen()
        {
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer ProjectSerializer = new XmlSerializer(typeof(Project));
            // To read the file, create a FileStream.
            using (FileStream ProjectFileStream = new FileStream("testsave.xml", FileMode.Open))
            {
                // Call the Deserialize method and cast to the object type.
                Proj = new Project();
                Proj = (Project)ProjectSerializer.Deserialize(ProjectFileStream);
                DataContext = Proj;
            }
        }

        // Зберегти проект
        private void ProjectSave()
        {
            // Insert code to set properties and fields of the object.
            XmlSerializer ProjectSerializer = new XmlSerializer(typeof(Project));
            // To write to a file, create a StreamWriter object.
            using (TextWriter ProjectWriter = new StreamWriter("testsave.xml"))
            {
                ProjectSerializer.Serialize(ProjectWriter, Proj);
                ProjectWriter.Close();
            }        
        }

        // Change fields headers name & width, disable column "Name" edit in DataGridProjectPrices
        private void DataGridProjectPrices_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();

            //update column details when generating
            if (headername == "Name")
            {
                e.Column.Header = "Назва";
                e.Column.Width = 135;
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

        }

        // Вихід з програми (виклик з меню)
        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
