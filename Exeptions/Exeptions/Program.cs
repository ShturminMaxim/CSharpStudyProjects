using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions
{
    class MyExeption : ApplicationException {
        public MyExeption():base() { 
        
        }

        public MyExeption(string message) : base(message) { 
        
        }

        public MyExeption(string message, Exception baseExeption)
            : base(message, baseExeption)
        { 
        
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = 0;

            try
            {
                if (a == 0)
                {
                    throw new MyExeption("error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
