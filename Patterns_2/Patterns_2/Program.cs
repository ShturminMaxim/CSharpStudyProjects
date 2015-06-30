using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_2
{
    class Program
    {
        static void Main(string[] args)
        {

            //factory method
            // product предназначен для определения интерфейса обьектов,создаваеміх фабричнім методом
            // concrete product - конкретній продукт, которій учавствует в схеме и отвечает за реализацию интерфейса product
            // creator - создатель обьект предназначен для обьявления фабричного метода и возвращения обьекта типа product
            // Concrete Creator - конкретный создатель возвращает конкретный продукт.

            Creator[] creators = { new ManagerCreator(), new DevCreator() };

            foreach (var item in creators)
            {
                Employee obj = item.FactoryMethod();
                obj.Salary();
                obj.Status();
            }

        }

        abstract class Employee {
            public abstract void Status();
            public abstract void Salary();
        }

        class Manager : Employee {

            public override void Status()
            {
                Console.WriteLine("on vacation");
            }

            public override void Salary()
            {
                Console.WriteLine("1500$");
            }
        }

        class Developer : Employee {

            public override void Status()
            {
                Console.WriteLine("on work");
            }

            public override void Salary()
            {
                Console.WriteLine("2500$");
            }
        }

        abstract class Creator {
            public abstract Employee FactoryMethod();
        }

        class ManagerCreator : Creator {

            public override Employee FactoryMethod()
            {
                return new Manager();
            }
        }

        class DevCreator : Creator
        {

            public override Employee FactoryMethod()
            {
                return new Developer();
            }
        }


    }
}
