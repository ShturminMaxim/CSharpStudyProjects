using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DBFirst
{
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    
    public partial class MainWindow : Window
    {
        libraryEntities db = new libraryEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show((dataGrid.SelectedItem as Categories).Name.ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            lBox.ItemsSource = new ObservableCollection<Categories>() { db.Categories.ToList() };
            //dataGrid.ItemsSource = db.Categories.ToList();
        }

        private void lBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show((lBox.SelectedItem as Categories).Id.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.Categories.Add(new Categories() { Name = catName.Text});
            db.SaveChanges();
            catName.Text = "";

            //lBox.ItemsSource = db.Categories.ToList();
        }

        private void catName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
