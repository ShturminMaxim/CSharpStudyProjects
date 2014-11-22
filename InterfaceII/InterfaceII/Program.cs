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
            //Student Max = new Student("Maxim", "Shturmin", ".Net14/2");
            //Iprintable Bob = new Student("Bob", "McGee", ".Net14/2");
            //Iprintable Den = new Person("Den", "Gruber");

            //Max.Print();
            //Bob.Print();
            //Den.Print();

            //Console.WriteLine("\n");

            //List<Iprintable> people = new List<Iprintable>{
            //    new Student("Bob", "McGee", ".Net14/2"),
            //    new Person("Den","Gruber"),
            //    new Student("Maxim","Shturmin",".Net14/2")
            //};

            //for (int i = 0; i < people.Count; i++)
            //{
            //    people[i].Print();
            //}

            //{
            //    int a = 10;
            //    a += 10;
            //}



            //// IEnum Interface Implementation
            //ClassWithArray MyClass = new ClassWithArray();


            //for (int i = 0; i < MyClass.Length; i++, MyClass.Next()) 
            //{
            //    Console.Write(MyClass.Current + " ");
            //}


            //Standart interfaces usage
            Student[] students = new Student[5];
            Random r = new Random();

            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student("Maxim-" + r.Next(5, 60), "Shturmin", ".Net14/2", r.Next(15, 60));
            }

            foreach (var item in students)
            {
                item.Print();
            }

            Console.WriteLine("\n");
            Console.WriteLine("Use Array.Sort() with name method");
            Array.Sort(students);
           
            foreach (var item in students)
            {
                item.Print();
            }

            Console.WriteLine("\n");
            Console.WriteLine("Use SortByage method");
            Array.Sort(students, new Student.StudentComparer("age", 1));
            
            foreach (var item in students)
            {
                item.Print();
            }

            Console.WriteLine("\n");
            Console.WriteLine("Use SortByage method reversed sort");
            Array.Sort(students, new Student.StudentComparer("age", -1));

            foreach (var item in students)
            {
                item.Print();
            }
            Console.WriteLine("\n");
            Console.WriteLine("Use SortByName method reversed sort");
            Array.Sort(students, new Student.StudentComparer("name", -1));

            foreach (var item in students)
            {
                item.Print();
            }
        }
    }
}
