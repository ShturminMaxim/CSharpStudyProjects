using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Audi audi = new Audi();
            Audi audiCopy = audi.Clone() as Audi;

            Console.WriteLine(audi);
            Console.WriteLine(audiCopy);

            Bmw bmw = new Bmw();
            Bmw bmwZ = bmw.Clone() as Bmw;

            if (audi.Date != audiCopy.Date)
            {
                Console.WriteLine("Not the same");
            }

            if (Object.ReferenceEquals(audi.Date, audiCopy.Date))
            {
                Console.WriteLine("the same");

            }
        }
        
        // Concrete Prototype конкретная реализация вібранного прототипа где описсівается содержимое интерфейса
        // Client создает новій обьект, которій будет копировать себя

        /// <summary>
        /// Car prototype
        /// </summary>
        abstract class Car {
            string model;
            string name;
            string color;
            int topSpeed;
            int year;

            object date;

            public Car(string m, string n, string c, int t, int y) {
                model = m;
                name = n;
                color = c;
                topSpeed = t;
                year = y;
                date = new object();
                date = "test1";
            }

            public object Date
            {
                get { return date; }
            }
            public string Model {
                get { return model;  }
            }
            public string Name
            {
                get { return name; }
            }
            public string Color
            {
                get { return color; }
            }
            public int TopSpeed
            {
                get { return topSpeed; }
            }
            public int Year
            {
                get { return year; }
            }


            public override string ToString()
            {
                return string.Format(Name + " " + Model + " " + TopSpeed + " " + Year + " " + Color + " te -" + date);
            }

            public abstract Car Clone();
        }


        class Bmw : Car {

            public Bmw(string m = "BMW", string n = "Moyo", string c = "red", int t = 120, int y = 1980)
                : base(m, n, c, t, y)
            { 
                
            }

            public override Car Clone() {
                return this.MemberwiseClone() as Car;
            }
        }

        class Audi : Car
        {

            public Audi(string m = "Audi", string n = "Tvoyo", string c = "red", int t = 120, int y = 1980)
                : base(m, n, c, t, y)
            {

            }

            public override Car Clone()
            {
                return this.MemberwiseClone() as Car;
            }
        }


    }
}
