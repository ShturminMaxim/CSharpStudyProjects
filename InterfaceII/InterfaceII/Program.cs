using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceII
{
    class Program
    {       
        static void Main(string[] args)
        {
            Student Max = new Student("Maxim", "Shturmin", ".Net14/2");
            Iprintable Bob = new Student("Bob", "McGee", ".Net14/2");
            Iprintable Den = new Person("Den", "Gruber");

            Max.Print();
            Bob.Print();
            Den.Print();

            Console.WriteLine("\n");

            List<Iprintable> people = new List<Iprintable>{
                new Student("Bob", "McGee", ".Net14/2"),
                new Person("Den","Gruber"),
                new Student("Maxim","Shturmin",".Net14/2")
            };

            for (int i = 0; i < people.Count; i++)
            {
                people[i].Print();
            }

            {
                int a = 10;
                a += 10;
            }

            // IEnum Interface Implementation
            ClassWithArray MyClass = new ClassWithArray();


            for (int i = 0; i < MyClass.Length; i++, MyClass.Next()) 
            {
                Console.Write(MyClass.Current + " ");
            }
        }
    }
}
