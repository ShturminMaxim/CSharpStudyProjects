using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace YandexApiTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string sURL;
            string key = "trnsl.1.1.20130826T073558Z.bbd30c33595c55bc.b62fddd99a00d1db80f7db359ca1f65c818d1887"
            sURL = "https://translate.yandex.net/api/v1.5/tr/translate ? 
key=<API-ключ>
 & text=<переводимый текст>
 & lang=<направление перевода>";

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);

            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                    Console.WriteLine("{0}:{1}", i, sLine);
            }
            Console.ReadLine();

        }
    }
}
