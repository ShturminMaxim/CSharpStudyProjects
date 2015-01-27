using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPF_Lesson
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Button btn = (Button)sender;
            //MessageBox.Show(btn.ActualHeight.ToString());
            //btn.Margin = new Thickness(60);

            List<string> list = new List<string>();

            foreach (var item in myGrid.Children)
            {
                if (item is Button) {
                    list.Add(((Button)item).Content.ToString());
                }
            }

            MyListBox.ItemsSource = list;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //myProgressBar
            for (long i = 0; i < 1000; i++)
            {
                Thread.Sleep(10);
                //System.Threading.Timeout(1000);
                myProgressBar.Value += 1;
            }
        }


    }
}
