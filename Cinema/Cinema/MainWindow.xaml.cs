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

namespace Cinema
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CinemaDB db = new CinemaDB();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("dsd");
            //Create dummy data for DB
            db.addHallType(10, 10);
            //db.addHallType(20, 20);

            //db.addHall("Green" , 1);
            //db.addHall("Red", 2);

            //db.addMovie("Invisible Slava");
            //db.addMovie("Super Dimon");
            //db.addMovie("Roman Atacs");
            //db.addMovie("Clever Nazar");

            //db.createSession(1, 1);
            //db.createSession(2, 1);
            //db.createSession(3, 2);
            //db.createSession(4, 2);
            try
            {
                var hallView = db.HallTypes.Count();
                MessageBox.Show(hallView.ToString());
            }
            catch (Exception ex)
            {
                
                //throw;
            }




            showPlaces(new int[10, 10]);
            
            //MoviesList.
        }

        private void MoviesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void showPlaces(int[,] View)
        {
            var places = new int[10,10];
            for (int i = 0; i < places.GetLength(0); i++)
            {
                for (int j = 0; j < places.GetLength(1); j++)
                {
                    var btn = new Button();
                    btn.Width = 20;
                    btn.Height = 20;
                    btn.Content = i.ToString() + "" + j.ToString();
                    btn.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    btn.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    btn.Margin = new Thickness(btn.Height * j, btn.Width*i, 0, 0);

                    
                    placesGrid.Children.Add(btn);
                }
            }

            //placesGrid
            
        }
    }
}
