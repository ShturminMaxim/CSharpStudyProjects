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

namespace WpfTestApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> imgList = new List<int>();
        int currImage = 1;

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                imgList.Add(i);   
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(@"images/1.jpg", UriKind.Relative));

            myGrid.Background = img;

            imgPrev.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"images/" + (imgList[currImage - 1]) + ".jpg");
            imgCurrent.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"images/" + imgList[currImage] + ".jpg");
            imgNext.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"images/" + (imgList[currImage + 1]) + ".jpg");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Content.ToString() == "Next")
            {
                currImage++;
                if (currImage > 4)
                    currImage = 1;
            }
            else
            {
                currImage--;
                if (currImage < 0)
                    currImage = 4;   
            }


            //ImageBrush prevImg = new ImageBrush();
            if ((currImage - 1) >= 0) 
                imgPrev.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"images/" + (imgList[currImage - 1]) + ".jpg");
            else
                imgPrev.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"images/" + (imgList[4]) + ".jpg");
            //imgPrev.Background = img;

            //imgCurrent currImg = new ImageBrush();
            imgCurrent.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"images/" + imgList[currImage] + ".jpg");

            //imgCurrent.Background = img;

            //ImageBrush nextImg = new ImageBrush();
            if((currImage + 1)<5) 
                imgNext.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"images/" + (imgList[currImage + 1]) + ".jpg");
            else
                imgNext.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(@"images/" + (imgList[0]) + ".jpg");
            //imgNext.Background = img;
        }
    }
}
