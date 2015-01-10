using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using(FileStream fs = new FileStream("myfile.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                // 1.....

                //string str = "Hi group .Net 14/2";
                //byte[] strfile = Encoding.UTF8.GetBytes(str);

                //fs.Write(strfile, 0, strfile.Length);
                //fs.Flush();

                //fs.Seek(0, SeekOrigin.Begin);

                //byte[] strread = new byte[(int)fs.Length];

                //fs.Read(strread, 0, (int)fs.Length);

                //string strFin = Encoding.UTF8.GetString(strread);

                //Console.WriteLine(strFin);
            
                //-------------------
                // 2............

                //string str = "Hi man";

                //StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

                //sw.Write(str);

                //StreamReader sr = new StreamReader(fs, Encoding.UTF8);

                //string text = sr.ReadLine();

                //Console.WriteLine(text);

                //sr.Dispose();

                //--------------------
                // 3............

                string str = "Hi man";
                int age = 33;

                BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);

                bw.Write(str);
                bw.Write(age);

                fs.Flush();
                fs.Seek(0, SeekOrigin.Begin);


                BinaryReader br = new BinaryReader(fs, Encoding.UTF8);
                string text = br.ReadString();
                int agee = br.ReadInt32();

                Console.WriteLine(text);
                Console.WriteLine(agee);
                br.Dispose();
            }

        }
    }
}
