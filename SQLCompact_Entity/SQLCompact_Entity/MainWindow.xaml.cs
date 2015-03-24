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

namespace SQLCompact_Entity
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestContext db = new TestContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            People p = new People() { Name = tb_name.Text, Age = Convert.ToInt32(tb_age.Text) };
            tb_age.Clear();
            tb_name.Clear();

            db.Peoples.Add(p);
            db.SaveChanges();

            list.ItemsSource = db.Peoples.ToList();
        }
    }
}
