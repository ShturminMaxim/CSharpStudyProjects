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

namespace MiniCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string operation;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            this.operation = btn.Content.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string result = "";
                double first = Convert.ToInt32(FirstNumber.Text);
                double second = Convert.ToInt32(SecondNumber.Text);

                switch (operation)
                {
                    case "+":
                        result = (first + second).ToString();
                        break;
                    case "-":
                        result = (first - second).ToString();
                        break;
                    case "/":
                        result = (first / second).ToString();
                        break;
                    case "*":
                        result = (first * second).ToString();
                        break;
                }

                Result.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FirstNumber.Text = "";
            SecondNumber.Text = "";
            Result.Text = "";
        }
    }
}
