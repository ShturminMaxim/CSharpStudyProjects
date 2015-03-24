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

namespace MyDBProject
{
    /// <summary>
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        LibraryDataContext db;
        Books b ;
        public Books BooksEntity { get { return this.b; } }
        public AddBook(ref LibraryDataContext db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             b = new Books() { Name = tbName.Text, Comment = tbComment.Text, Pages = Convert.ToInt32(tbPages.Text.ToString()), Quantity = Convert.ToInt32(tbQuantity.Text.ToString()), YearPress = Convert.ToInt32(tbYearPress.Text.ToString()) };
            b.Id_Category = (from c in db.Categories where c.Name == cbCategory.SelectedItem.ToString() select c.Id).Single();
            b.Id_Press = (from p in db.Press where p.Name == cbPress.SelectedItem.ToString() select p.Id).Single();
            b.Id_Themes = (from t in db.Themes where t.Name == cbThemes.SelectedItem.ToString() select t.Id).Single();
            b.Id_Author =  db.Authors.Where(a => a.LastName.Contains(cbAuthor.SelectedItem.ToString())).Single().Id;
            this.Close();
           
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
                cbThemes.Items.Add(item.Name);
            }
            cbThemes.SelectedIndex = 0;

            var authors = db.Authors.ToList();
            foreach (var item in authors)
            {
                cbAuthor.Items.Add(item.LastName );
            }
            cbAuthor.SelectedIndex = 0;

        }
    }
}
