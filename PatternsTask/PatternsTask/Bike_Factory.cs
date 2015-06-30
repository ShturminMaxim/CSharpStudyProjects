using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsTask
{
    class Bike_Factory : Creator
    {
        public override factoryBike createBike(string type)
        {
            switch (type)
            {
                case "super":
                    return new superBike();
                    break;
                case "great":
                    return new greatBike();
                    break;
                default :
                    return new defaultBike();
                    break;
            }
            
        }
    }

    abstract class factoryBike
    {
        public abstract void getModel();
        public abstract void getYear();
    }

    abstract class Creator
    {
        public abstract factoryBike createBike();
    }

    class superBike : factoryBike
    {

        public override void getModel()
        {
            Console.WriteLine("I`m a Supa Bike");
        }

        public override void getYear()
        {
            Console.WriteLine("year in 2016");
        }
    }

    class greatBike : factoryBike
    {

        public override void getModel()
        {
            Console.WriteLine("i`m great bike");
        }

        public override void getYear()
        {
            Console.WriteLine("year in 2010");
        }
    }

    class defaultBike : factoryBike
    {

        public override void getModel()
        {
            Console.WriteLine("i`m default Bike");
        }

        public override void getYear()
        {
            Console.WriteLine("year in 1980");
        }
    }
}
