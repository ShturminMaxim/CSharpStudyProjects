using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{

    class Program
    {
        static void Main(string[] args)
        {
            Square sq = new Square("square", 2, 5);

            Console.WriteLine(sq);
        }
    }
}
