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

            parser.Parse("10.1+23.2.1:32;12.3+32.2");

            Console.ReadLine();
        }
    }
}
