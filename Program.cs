using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Test
    {
        static dynamic f;
        dynamic Propert { get; set; }
        public dynamic MyMethod(dynamic d)
        {
            dynamic l = "Локальная переменная";
            int q = 2;
            if (d is int)
            {
                return l;
            }
            else
            {
                return q;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<dynamic> list = new List<dynamic>();

            Test t = new Test();
            Console.WriteLine(t.MyMethod(12));
           // dynamic d1 = 1;
           // object o1 = 1;
           // Console.WriteLine(d1.GetType());
           // d1 += "dsfdf" ;
           //// o1 += 3;
           // Console.WriteLine(d1.GetType());
           // Console.WriteLine(o1);
        }
    }
}
