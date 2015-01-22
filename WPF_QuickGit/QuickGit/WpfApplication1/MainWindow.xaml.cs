using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApplication1
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

        static void ResetAndPull(string folder)
        {
            //// создаем процесс cmd.exe
            ProcessStartInfo psiOpt = new ProcessStartInfo(@"cmd.exe", @"/C git reset --hard origin/master&git clean -f -d&git pull origin master");
            psiOpt.WorkingDirectory = folder;
            // скрываем окно запущенного процесса
            psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            psiOpt.RedirectStandardOutput = true;
            psiOpt.UseShellExecute = false;
            psiOpt.CreateNoWindow = true;
            // запускаем процесс
            Process procCommand = Process.Start(psiOpt);
            // получаем ответ запущенного процесса
            StreamReader srIncoming = procCommand.StandardOutput;
            // выводим результат
            Console.WriteLine(srIncoming.ReadToEnd());
            // закрываем процесс
            Console.WriteLine("Done.");
            procCommand.WaitForExit();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            #region
            /* 
             * Parse data in Config File, get Client Names and repositories locations
             * Fill Deictionary
             * 
            */
            Dictionary<string, string> reposLocations = new Dictionary<string, string>();
            FileStream fs = new FileStream("config.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            while (line != null)
            {
                //get Clientname from string
                string namePattern = @"^[^\:]+";
                Regex nameRx = new Regex(namePattern);
                string clientName = nameRx.Match(line).ToString().Trim();

                //get RepoLocation from string
                string locationPattern = @"[^\:]+$";
                Regex locRx = new Regex(locationPattern);
                string repositoriyLocation = locRx.Match(line).ToString().Trim();

                //add Data to dictionary
                reposLocations.Add(clientName, repositoriyLocation);

                //Create textBoxes for each client
                System.Windows.Controls.TextBlock txt = new TextBlock();
                txt.Text = clientName;

                //Append new TextBox to StackPanel
                ClientsList.Children.Add(txt);

                //create Github ResetPull button
                Button resPullBtn = new Button();
                resPullBtn.Content = "Res and Pull";
                resPullBtn.Tag = repositoriyLocation;

                //Append new TextBox to StackPanel
                GitButtonsContainer.Children.Add(resPullBtn);

                line = sr.ReadLine();
            }
            #endregion


        }

        private void GitButtonsContainer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("mousedown");
            //e.ClickCount
            try
            {
                Button btn = (Button)sender;
                MessageBox.Show("button");
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message);
            }  
        }
    }
}
