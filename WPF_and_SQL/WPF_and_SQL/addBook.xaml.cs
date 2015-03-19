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
using System.Windows.Shapes;

namespace WPF_and_SQL
{
    /// <summary>
    /// Логика взаимодействия для addBook.xaml
    /// </summary>
    public partial class addBook : Window
    {
        libDataContext db = new libDataContext();

        public addBook()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Books b = new Books() { Name = tbName.Text, Comment = tbComment.Text, Pages = Convert.ToInt32(tbPages.Text), Quantity = Convert.ToInt32(tbQuantity.Text) };
            b.Id_Category = from 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var category = db.Categories.ToList();
            foreach (var item in category)
            {
                cbCategory.Items.Add(item.Name);
            }
            cbCategory.SelectedIndex = 0;

            var press = db.Press.ToList();
            foreach (var item in press)
            {
                cbPress.Items.Add(item.Name);
            }
            cbPress.SelectedIndex = 0;

            var themes = db.Themes.ToList();
            foreach (var item in themes)
            {
                cbTheme.Items.Add(item.Name);
            }
            cbTheme.SelectedIndex = 0;

            var authors = db.Authors.ToList();
            foreach (var item in authors)
            {
                cbAuthor.Items.Add(item.LastName + " " + item.FirstName);
            }
            cbAuthor.SelectedIndex = 0;


        }
    }
}
