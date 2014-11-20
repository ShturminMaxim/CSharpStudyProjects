using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceII
{
    class Person :Iprintable
    {
        protected string Name { get; set; }
        protected string Surname { get; set; }

        public Person(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public void Print()
        {
            Console.WriteLine("Hi, i`m " + this.Name + " " + this.Surname);
        }
    }
}
