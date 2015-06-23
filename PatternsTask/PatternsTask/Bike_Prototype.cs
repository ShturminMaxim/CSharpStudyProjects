using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsTask
{
    abstract class Bike
    {
        string model;
        int year;

        public Bike(string bikeModel, int bikeYear)
        {
            model = bikeModel;
            year = bikeYear;
        }

        public string Model { get {return model;}; set; }
        public int Year { get {return year;}; set; }


        public override string ToString()
        {
            return string.Format("Model-" + Model + ", year" + Year);
        }

        public abstract Bike Clone();
    }
    
    class Bike_Prototype : Bike
    {
          public Bike_Prototype(string model = "BMW", int year = 1980)
                : base(model, year)
            {

            }

            public override Bike Clone()
            {
                return this.Clone() as Bike;
            }
    }
}
