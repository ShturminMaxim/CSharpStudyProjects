using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regexp
{
    class Program
    {
        static void Main(string[] args)
        {
            StringParser parser = new StringParser();

            parser.Parse("11.1+12324.3212.1:32sadasd22.2d  sa22.5u22.6d    33.33   44.44   534.234.423лдвыам55.55+6.6+7.7");

            Console.ReadLine();
        }
    }
}
