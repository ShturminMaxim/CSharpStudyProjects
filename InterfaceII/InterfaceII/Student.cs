using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceII
{
    class Student : Person, Iprintable
    {
        string GroupName { get; set; }

        public Student(string name, string surname, string group)
            : base(name, surname)
        {
            this.GroupName = group;
        }

        public void Print()
        {
            Console.WriteLine("Hi, i`m " + this.Name + " " + this.Surname + ". Group " + this.GroupName);
        }
    }
}
