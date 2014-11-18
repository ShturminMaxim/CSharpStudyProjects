using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    //тип enum
    enum Surnames { verifax, baddog, max };
    
    //тип Struct
    struct A {
        public int B { 
            get
            {
                return 3;
            }
            set { }
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            Console.WriteLine(a.B);

            Console.ReadLine();
        }
    }
}
