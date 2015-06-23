using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Singletone
            Bike_Singletone myBike = Bike_Singletone.getInstance();
            Bike_Singletone yourBike = Bike_Singletone.getInstance();

            // Bilder
            Bike_Builder builder = new Bike_Builder();
            Created_Bike comanche =  builder.buildComanche();
            
            // Abstract Factory
            Bike_AbstractFactory Bike_Factory = new Bike_ConcreteFactory();
            Client client1 = new Client(factory1);
            client1.Run();

            // Factory Method
            Bike_Factory bikesCreator = new Bike_Factory();

            factoryBike superBike = bikesCreator.createBike("super");
            factoryBike greatBike = bikesCreator.createBike("great");
            factoryBike simpleBike = bikesCreator.createBike();

            superBike.getModel();
            greatBike.getModel();
            simpleBike.getModel();

            // Prototype
            Bike_Prototype firstBike = new Bike_Prototype();
            Bike_Prototype secondBike = firstBike.Clone() as Bike_Prototype;
        }
    }
}
