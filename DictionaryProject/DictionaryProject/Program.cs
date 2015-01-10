using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DictionaryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string initText = Console.ReadLine();
            Regex regx = new Regex(@"[^\s]+");
            MatchCollection words = regx.Matches(initText);

            AddToDictionary("hi", "привет");
            AddToDictionary("max", "максим");

            using (FileStream fs = new FileStream("rus/rus.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)) {
                fs.Seek(0, SeekOrigin.Begin);
                

                BinaryReader br = new BinaryReader(fs, Encoding.UTF8);
                

                string engWord = br.ReadString();
                Console.WriteLine(engWord);
            }

            //for (int i = 0; i < words.Count; i++)
            //{
            //    Console.WriteLine(words[i]);            
            //}
        }

        static void AddToDictionary (string eng, string ru) {
            using (FileStream fs = new FileStream("rus/rus.txt", FileMode.Append, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);
                bw.Write(eng);
                bw.Write(ru);
            }
        }

        static Dictionary<string, string> GetDictionary ()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            
            using (FileStream fs = new FileStream("rus/rus.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                BinaryReader br = new BinaryReader(fs, Encoding.UTF8);
                while(!br.)
                {
                
                }
                string engWord = br.ReadString();
                string ruWord = br.ReadString();
            }


            return dictionary;
        }
    }
}
