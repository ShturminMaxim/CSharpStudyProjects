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

namespace WPF_Paint
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Line line;
        bool draw = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string text = btn.Content.ToString();

            switch (text)
	        {
                case "Line" :
                    Line l = new Line();
                    l.StrokeThickness = 2;
                    l.Stroke = Brushes.Blue;
                    l.X1 = myCanvas.Margin.Left + 50;
                    l.Y1 = myCanvas.Margin.Top+50;
                    l.X2 = myCanvas.Margin.Left+100;
                    l.Y2 = myCanvas.Margin.Top+100;

                    myCanvas.Children.Add(l);
                    break;
                case "Circle":
                    Ellipse el = new Ellipse();
                    el.Stroke = Brushes.Blue;
                    el.StrokeThickness = 5;
                    el.Width = 100;
                    el.Height = 100;
                    el.Fill = Brushes.Black;
                    el.Margin = new Thickness(200,200,0,0);

                    myCanvas.Children.Add(el);
                    break;
                case "Triangle":
                    Polygon pg = new Polygon();
                    pg.Points = new PointCollection(
                            new List<Point>() { 
                                new Point(){X=150,Y=150},
                                new Point(){X=200,Y=200},
                                new Point(){X=150,Y=200}
                                //new Point(){X=150,Y=150}
                            }
                        );
                    pg.Stroke = Brushes.Blue;
                    pg.StrokeThickness = 5;

                    myCanvas.Children.Add(pg);
                    break;
		        default:
                    break;
	        }

        }

        private void myCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //draw = true;
            line = new Line();
            line.StrokeThickness = 2;
            line.Stroke = Brushes.Blue;
            Point p = Mouse.GetPosition(myCanvas);
            line.X1 = p.X;
            line.Y1 = p.Y;

            myCanvas.Children.Add(line);
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            //draw points
            //if (draw == true) {
            //    Point p = Mouse.GetPosition(myCanvas);
            //    Ellipse el = new Ellipse();
            //    el.Stroke = Brushes.Blue;
            //    el.StrokeThickness = 2;
            //    el.Width = 2;
            //    el.Height = 2;
            //    el.Fill = Brushes.Black;
            //    el.Margin = new Thickness(p.X, p.Y, 0, 0);
            //    //drawPoint.StrokeThickness = 2;
            //    //drawPoint.Stroke = Brushes.Blue;

                
            //    myCanvas.Children.Add(el);
            //}
            //end draw points


            if (line != null)
            {
                Point p = Mouse.GetPosition(myCanvas);
                line.X2 = p.X;
                line.Y2 = p.Y;
            }   
        }

        private void myCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //draw = false;
            line = null;
        }
    }
}
