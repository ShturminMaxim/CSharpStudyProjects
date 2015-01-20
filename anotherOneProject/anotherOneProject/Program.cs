using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turkey;
using Bulgary;
using Iraq;
using town;

namespace anotherOneProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Ankara capital1 = new Ankara(1);
            Bagdad capital2 = new Bagdad(5);
            Sofia capital3 = new Sofia(3);

            Console.WriteLine(capital1.People);
            Console.WriteLine(capital2.People);
            Console.WriteLine(capital3.People);

            Console.WriteLine("\n");
        }
    }
}
