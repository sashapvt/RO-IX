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

            // Ініціалізація допоміжного класу для роботи з проектом
            PH = new ProjectHelper();
            // Старт нового проекту
            PH.ProjectNew();
            PH.ProjectChanged += Event_ProjectChanged;
            
            // Для відладки
            // TabControlProject.SelectedIndex = 2;
        }

        // Допоміжний клас для роботи з проектом
        public ProjectHelper PH;

        // Active project changed
        private void Event_ProjectChanged(object sender, EventArgs e)
        {
            DataContext = PH.Proj;
            TabControlProject.SelectedIndex = 0;
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
            PH.ProjectNew();
        }

        // Відкрити проект... (виклик з меню)
        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            // Виклик нового проекту
            PH.ProjectOpen();
        }

        // Зберегти проект (виклик з меню)
        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            // Збереження проекту
            PH.ProjectSave();
        }

        // Зберегти проект як... (виклик з меню)
        private void MenuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            // Збереження проекту з вибором файлу
            PH.ProjectSave(true);
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
            if (TabControlProject.SelectedIndex == 1) PH.CalculateProductivity();

            // Якщо вибрана вкладка "Розрахунок" запустити підпрограму розрахунку
            if (TabControlProject.SelectedIndex == 2)
            {
                // Відображення результатів розрахунку
                WebBrowserCalc.Navigate("file:///" + PH.ProjectCalculate());
                PrintEnabled(true);
            }
            else PrintEnabled(false);

            // Перевірка можливості друку результатів розрахунку
        }

        private void eventCalculateProductivityIsNeeded(object sender, RoutedEventArgs e)
        {
            // Проводимо розрахунок продуктивності систем очистки
            PH.CalculateProductivity();
        }

        // Дозвіл на друк
        private void PrintEnabled(bool isPrint)
        {
            if (isPrint)
            {
                // Друк дозволено
                this.MenuPrint.IsEnabled = true;
                this.ButtonPrint.IsEnabled = true;
                this.ButtonPrintImage.Opacity = 1.0;
            }
            else
            {
                // Друк заборонено
                this.MenuPrint.IsEnabled = false;
                this.ButtonPrint.IsEnabled = false;
                this.ButtonPrintImage.Opacity = 0.5;
            }
        }
    }
}
