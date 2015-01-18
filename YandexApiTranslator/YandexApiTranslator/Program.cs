using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace YandexApiTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string sURL;
            string key = "trnsl.1.1.20130826T073558Z.bbd30c33595c55bc.b62fddd99a00d1db80f7db359ca1f65c818d1887";
            string textForTranslate = Console.ReadLine();
            sURL = "https://translate.yandex.net/api/v1.5/tr/translate?key=" + key + "&text=" + textForTranslate + "&lang=ru-en";

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
                if (docLine != null) {
                    documentData += docLine;
                }
                  
                    
            }

            XmlReader reader = XmlReader.Create(new StringReader(documentData));
            while (reader.Read()) {
                //Console.WriteLine(reader.NodeType);
                if (reader.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine(reader.Value);
                }
            }

            Console.ReadLine();

        }
    }
}
