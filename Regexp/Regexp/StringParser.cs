using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regexp
{
    class StringParser
    {
        public List<int> result;

        public StringParser() { 
            result = new List<int>();
        }

        public List<int> Parse(string str) {
            result = new List<int>();
            string pattern = @"[^.]|\b(\d+\.\d+)[^.]|\b";
            Regex rgx = new Regex(pattern);

            Match res = rgx.Match(str);

            while (res.Success)
            {

                Console.Write(" " + res.Groups[1].Value);
                res = res.NextMatch();
            }
            //for (int i = 0; i < res.Count; i++)
            //{
            //    Console.Write(" "+res[i]);
            //}

            //Console.WriteLine(res);
            
            return result;
        }
    }
}
