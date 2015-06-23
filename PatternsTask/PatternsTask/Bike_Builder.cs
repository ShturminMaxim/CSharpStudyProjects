using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsTask
{
    class Bike_Builder
    {
        Director director;

        public Bike_Builder() {
            director = new Director();
        }

        public Created_Bike buildComanche()
        {
            ComancheBuilder build = new ComancheBuilder();
            director.Complete(build);

            return build.create();
        }
    }

    class ComancheBuilder : Builder {
        Builder_Bike completeBike = new Builder_Bike();

        public override void addName()
        {
            completeBike.AddComponent("Comanche");
        }
        public override void addYear()
        {
            completeBike.AddComponent("1983");
        }

        public override Builder_Bike create()
        {
            return completeBike;
        }
    }

    abstract class Builder
    {
        public abstract void addName();
        public abstract void addYear();

        public abstract Builder_Bike create();
    }

    class Created_Bike
    {
        ArrayList set = new ArrayList();

        public void AddComponent(string component)
        {
            set.Add(component);
        }

        public override string ToString()
        {
            string res = "";
            foreach (var item in set)
            {
                res += item + "\n";
            }
            return res;
        }

    }

    class Director
    {

        public void Complete(Builder obj)
        {
            obj.addName();
            obj.addYear();
        }

    }
}
