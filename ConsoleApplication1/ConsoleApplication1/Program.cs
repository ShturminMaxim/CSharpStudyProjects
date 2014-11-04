using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        class WordsFinder {
            //public string[,] Field {set;get;}
            //public string[] KeyWords { set; get; }

            //public WordsFinder(string[,] field, string[] keyWords) {
            //    Field = field;
            //    KeyWords = keyWords;
            //}
        }
        static void Main(string[] args)
        {
            string field = "POLITERWYMSOAIPTBDANRLEMES";
            List<string>[] arrField = new List<string>[5];
            var xCount = 0;
            var yCount = 0;

            for (var i = 0; i < field.Length; i++)
            {
                if (i > 0 && i % 5 == 0)
                {
                    yCount++;
                    xCount = 0;
                }
                if (arrField[yCount] == null)
                {
                    arrField[yCount] = new List<string>();
                }

                Console.WriteLine(arrField[yCount] == null);
                arrField[yCount].Add(field[i].ToString());
                xCount++;
            }

            Console.WriteLine();
        }
    }
}
