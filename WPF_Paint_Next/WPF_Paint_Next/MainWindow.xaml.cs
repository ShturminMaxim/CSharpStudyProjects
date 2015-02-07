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

namespace WPF_Paint_Next
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Line line;
        bool overTheEdge = false;
        int linesCounter = 0;
        Point startPoint;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void canvasBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (linesCounter == 0)
            {
                Point p = Mouse.GetPosition(canvasBlock);
                startPoint = new Point();

                startPoint.X = p.X;
                startPoint.Y = p.Y;

                linesCounter++;
                StartDraw();
            }
            else if (linesCounter< 2)
            {
                line = new Line();
                line.StrokeThickness = 2;
                line.Stroke = Brushes.Blue;
                Point p = Mouse.GetPosition(canvasBlock);

                line.X1 = p.X;
                line.Y1 = p.Y;
                line.X2 = startPoint.X;
                line.Y2 = startPoint.Y;

                canvasBlock.Children.Add(line);
                line = null;
                linesCounter ++;
            }

        }
        private void StartDraw() {
            line = new Line();
            line.StrokeThickness = 2;
            line.Stroke = Brushes.Blue;
            Point p = Mouse.GetPosition(canvasBlock);

            line.X1 = p.X;
            line.Y1 = p.Y;

            canvasBlock.Children.Add(line);
        }
        private void canvasBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (line != null & linesCounter == 1)
            {
                line = null;
                StartDraw();
            }
        }

        private void canvasBlock_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = Mouse.GetPosition(canvasBlock);
            if (p.X >= canvasBlock.Width)
            {
                //MessageBox.Show("over");
            }
            if (line != null)
            {
                line.X2 = p.X;
                line.Y2 = p.Y;
                
            }
        }

        /**
         * 
         *
        */
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {         
                Point p = Mouse.GetPosition(canvasBlock);

                if (p.X > (int)canvasBlock.Width | p.X < 0 | p.Y > (int)canvasBlock.Height | p.Y < 0)
                {
                    overTheEdge = true;
                    if (line != null)
                        line.Stroke = Brushes.Red;
                }
                else {
                    overTheEdge = false;
                    if (line != null)
                        line.Stroke = Brushes.Blue;
                }
            
        }

        private void MainWindow1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (line != null & overTheEdge == true)
            {
                canvasBlock.Children.Remove(line);
                line = null;
            }
        }
    }
}
