using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade.initWebsite("Kiska WebSite");
            Console.WriteLine("\n");

            Console.ReadLine();

            Facade.initWebsite("HabraHabr WebSite");
            Console.WriteLine("\n");

            Console.ReadLine();

            Facade.removeSite("Kiska WebSite");
            Console.WriteLine("\n");
            Console.ReadLine();

            Facade.removeSite("HabraHabr WebSite");
            Console.WriteLine("\n");

            Console.ReadLine();
        }
    }
}
