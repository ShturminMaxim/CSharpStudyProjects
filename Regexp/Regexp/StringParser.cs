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
            string pattern = @"(^|[^\.\d]|\G)(\d+\.\d+)([^\.\d]|$){1}";
            Regex rgx = new Regex(pattern);

            MatchCollection res = rgx.Matches(str);

            //while (res.Success)
            //{

            //    Console.Write(" " + res.Groups[2].Value);
            //    res = res.NextMatch();
            //}
            for (int i = 0; i < res.Count; i++)
            {
                Console.Write(" " + res[i].Groups[2].Value);
            }

            //Console.WriteLine(res);
            
            return result;
        }
    }
}
