using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartIndexators
{
    class People : IComparable {
        static Random r = new Random();
        public string fullName;
        int age;

        public People() {
            this.age = People.r.Next(16, 50);
            this.fullName = "People -" + People.r.Next(1, 100);
        }

        public int CompareTo(object obj) {
            People p = (People)obj;

            if (this.age < p.age) return -1;
            if (this.age > p.age) return 1;
            return 0;
        }

        public override string ToString()
        {
            return "name - "+ this.fullName +". age - " + this.age + "\n";
        }

        public class SortByname : IComparer<People> {
            int IComparer<People>.Compare(People obj1, People obj2) {
                if(obj1.fullName.CompareTo(obj2.fullName) < 0) {
                    return -1;
                }  
                if(obj1.fullName.CompareTo(obj2.fullName) > 0) {
                    return 1;
                }  
                return 0;
            }
        }
        public class SortByAge : IComparer<People> {
            int IComparer<People>.Compare(People obj1, People obj2) {
                if(obj1.age.CompareTo(obj2.age) < 0) {
                    return -1;
                }  
                if(obj1.age.CompareTo(obj2.age) > 0) {
                    return 1;
                }  
                return 0;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            People[] p = new People[5];

            for (int i = 0; i < p.Length; i++)
            {
                p[i] = new People();
            }

            foreach (var item in p)
            {
                Console.WriteLine(item);
            }

            Array.Sort(p, new People.SortByname());
            Console.WriteLine("\n\n");
            foreach (var item in p)
            {
                Console.WriteLine(item);
            }
        }
    }
}
