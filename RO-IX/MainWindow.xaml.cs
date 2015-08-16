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
        public MainWindow()
        {
            InitializeComponent();
            Proj = new Project();
            DataContext = Proj;
        }
        public Project Proj;

        private void DataGridProjectPrices_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();

            //update column details when generating
            if (headername == "Name")
            {
                e.Column.Header = "Назва";
                e.Column.Width = 135;
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

        // Новий проект
        private void MenuNew_Click(object sender, RoutedEventArgs e)
        {
            Proj = new Project();
            DataContext = Proj;
        }

        // Відкрити проект...
        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer ProjectSerializer = new XmlSerializer(typeof(Project));
            // To read the file, create a FileStream.
            FileStream ProjectFileStream = new FileStream("testsave.xml", FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            Proj = new Project();
            Proj = (Project)ProjectSerializer.Deserialize(ProjectFileStream);
            DataContext = Proj;
        }

        // Зберегти проект
        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            // Insert code to set properties and fields of the object.
            XmlSerializer ProjectSerializer = new XmlSerializer(typeof(Project));
            // To write to a file, create a StreamWriter object.
            TextWriter ProjectWriter = new StreamWriter("testsave.xml");
            ProjectSerializer.Serialize(ProjectWriter, Proj);
            ProjectWriter.Close();

            // Bug

            /*
            //Test
            ProjectPrices TestPP = new ProjectPrices();
            XmlSerializer TestSerializer = new XmlSerializer(typeof(ProjectPrices));
            // To write to a file, create a StreamWriter object.
            TextWriter TestWriter = new StreamWriter("testPPsave.xml");
            TestSerializer.Serialize(TestWriter, TestPP);
            TestWriter.Close();
             * */
        
        }

        // Зберегти проект як...
        private void MenuSaveAs_Click(object sender, RoutedEventArgs e)
        {

        }

        // Вихід з програми
        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
