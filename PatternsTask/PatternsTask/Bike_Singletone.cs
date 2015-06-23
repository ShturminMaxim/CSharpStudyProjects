using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsTask
{
    class Bike_Singletone
    {
        static private Bike_Singletone instance;
        public string Model { get; set;}
        public int Year{ get; set;}

        public static Bike_Singletone getInstance()
        {
            if (instance == null)
            {
                instance = new Bike_Singletone();
            }

            return instance;
        }
    }
}
