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

namespace WPF_and_SQL
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        libDataContext db = new libDataContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var category = db.Categories.ToList();
            foreach (var item in category)
            {
                lbCategory.Items.Add(item.Name);
            }

            lbCategory.SelectedIndex = 0;

        }

        private void lbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbBooks.Items.Clear();
            var name  = (sender as ListBox).SelectedItem.ToString();
            //MessageBox.Show(name);
            var cat = db.Categories.Where(c=>c.Name == name).Single();
            foreach (var item in cat.Books)
            {
                lbBooks.Items.Add(""+item.Name + ", :"+item.Authors.LastName+ " " + item.Authors.FirstName);                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window addBookWin = new Window();
            addBookWin.ShowDialog();
        }


    }
}
