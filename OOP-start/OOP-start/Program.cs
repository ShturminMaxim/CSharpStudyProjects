using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_start
{
    class People
    {
        string firstName;
        string lastName;
        int age;

        public int Age {
            get {
                return this.age;
            }
            set {
                if (value >= 18 && value <= 60)
                {
                    this.age = value;    
                }
            }
        }

        public People()
        {
            firstName = "Жорик";
            lastName = "Вартанов";
            age = 18;
        }
        public People(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }


        public void Show()
        {
            Console.WriteLine(this.firstName + "--" + this.lastName + "--" + this.age);
        }
        public override string ToString()
        {
            return string.Format(this.firstName + "--" + this.lastName + "--" + this.age);
            //return base.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            People p1 = new People();
            People p2 = new People("Max", "Brok", 12);

            p1.Show();
            p2.Show();

            Console.WriteLine(p1.ToString());

            Console.ReadLine();
        }
    }
}
