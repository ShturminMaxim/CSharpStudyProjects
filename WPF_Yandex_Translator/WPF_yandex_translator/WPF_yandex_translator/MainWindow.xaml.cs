using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Xml;

namespace WPF_yandex_translator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string translatorlangs = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TranslateButton_Click(object sender, RoutedEventArgs e)
        {
            if (russianWordInput.Text.Length > 0 & translatorlangs.Length>0)
                doTranslate();
        }

        private void russianWordInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter & russianWordInput.Text.Length > 0 & translatorlangs.Length > 0)
            {
                doTranslate();
            }
        }

        private void doTranslate() {
            string rusWord = russianWordInput.Text;

            string sURL;
            string key = "trnsl.1.1.20130826T073558Z.bbd30c33595c55bc.b62fddd99a00d1db80f7db359ca1f65c818d1887";
            sURL = "https://translate.yandex.net/api/v1.5/tr/translate?key=" + key + "&text=" + rusWord + "&lang=" + translatorlangs;

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);

            string documentData = "";
            string docLine = "";

            while (docLine != null)
            {
                docLine = objReader.ReadLine();
                if (docLine != null)
                {
                    documentData += docLine;
                }


            }

            XmlReader reader = XmlReader.Create(new StringReader(documentData));
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    translatedEnglishWord.Text = reader.Value;
                }
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedItem as string;
            translatorlangs = text;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            string[] langs = new string[2] { "ru-en", "en-ru" };

            for (int i = 0; i < langs.Length; i++)
            {
                LangSelect.Items.Add(langs[i]);
            }
        }

    }
}
