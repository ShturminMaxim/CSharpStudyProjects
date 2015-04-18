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
    
    class newItem {
        public string Content {set;get;}
        public int MovieId {set;get;}
    }
    public partial class MainWindow : Window
    {
        CinemaDB db = new CinemaDB();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Create dummy data for DB
            //db.addHallType(10, 10);
            //db.addHallType(20, 20);

            //db.addHall("Green", 1);
            //db.addHall("Red", 2);

            //db.addMovie("Invisible Slava");
            //db.addMovie("Super Dimon");
            //db.addMovie("Roman Atacs");
            //db.addMovie("Clever Nazar");

            //db.createSession(1, 1, 10);
            //db.createSession(2, 1, 15);
            //db.createSession(3, 2, 12);
            //db.createSession(4, 2, 11);


            //var hallView = db.HallTypes.Count();
            movieSelectorInit();
            sessionsInit(1);
        }

        private void MoviesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //showPlaces(new int[10, 10]);

            //MoviesList.
        }

        /// <summary>
        /// fill Movie ComboBox
        /// </summary>
        private void movieSelectorInit(){
            movieSelect.Items.Clear();

            foreach (var movie in db.Movies)
			{
                ComboBoxItem item = new ComboBoxItem();
                item.Content = movie.Name;
                item.Tag = movie.Id;
                movieSelect.Items.Add(item);
			}
            
        }

        private void showPlaces(object sender, RoutedEventArgs e)
        {
            var places = new int[10,10];
            for (int i = 0; i < places.GetLength(0); i++)
            {
                for (int j = 0; j < places.GetLength(1); j++)
                {
                    var btn = new Button();
                    btn.Width = 30;
                    btn.Height = 30;
                    btn.Content = i.ToString() + "" + j.ToString();
                    btn.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    btn.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    btn.Margin = new Thickness(btn.Height * j, btn.Width*i, 0, 0);

                    
                    placesGrid.Children.Add(btn);
                }
            }

            //placesGrid
            
        }

        private void sessionsInit(int movieId) {
            sessionList.Children.Clear();
            int position = 0;
            foreach (var item in db.Sessions.Where(t => t.MovieId == movieId))
            {
                Movie currMovie = db.Movies.Where(f => f.Id == movieId).Single();
                Hall currHall = db.Halls.Where(f => f.Id == item.HallId).Single();

                TextBlock textBlock = new TextBlock() {
                    Text = "" + currMovie.Name + ", Hall: " + currHall.Name + ", Price: " + item.TicketPrice,
                      Margin = new Thickness(0, position, 0, 0)
                };

                Button delBtn = new Button() { 
                    Tag = item.Id,
                    Height = 22,
                    Width = 80,
                    Content = "Show Hall",
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                    VerticalAlignment = System.Windows.VerticalAlignment.Top,
                    Margin = new Thickness(0, position, 0, 0)           
                };
                
                delBtn.Click += showPlaces;

                sessionList.Children.Add(textBlock);
                sessionList.Children.Add(delBtn);

                position += 24;

            }

            //Label session = new Label() { 
            //    Tag = "1", 
            //    Content = "Movie: " + "Hall: " + "Price: ",
            //    Height = 22,
            //    Margin = new Thickness(0, position, 0, 0),
            //};
            

            //sessionList.Children.Add(session);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)movieSelect.SelectedItem;
            int movieId = Convert.ToInt32(item.Tag);
            sessionsInit(movieId);
            //MessageBox.Show(movieSelect.SelectedIndex.ToString());
        }
    }
}
