using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //PATTERN BUIDER START
            Director director = new Director();
            HappyMilBuilder hm = new HappyMilBuilder();
            //LittleHappyMilBuilder lhm = new LittleHappyMilBuilder();

            director.Complete(hm);
           // director.Complete(lhm);

            HappyMil mil = hm.returnOrder();
           // HappyMil lmil = lhm.returnOrder();

            Console.WriteLine("Big - \n");
            Console.WriteLine(mil);
           // Console.WriteLine("Little -\n");
           // Console.WriteLine(lmil);

            //PATTERN BUIDER END
        }
    }

    /**
     * Singletone
     */
    class Earth { 
        static private Earth instance;
        
        public static Earth getInstance() {
            if (instance == null)
            {
                instance = new Earth();
            }

            return instance;
        }
    }


    /**
     * Builder 
     */

    abstract class Builder {
        public abstract void AddPotato();
        public abstract void AddCola();
        public abstract void AddBurger();
        public abstract void AddToy();

        public abstract HappyMil returnOrder();
    }

    class HappyMilBuilder : Builder {
        HappyMil result = new HappyMil();

        public override void AddPotato()
        {
            result.AddComponent("Big Potato");
        }

        public override void AddCola()
        {
            result.AddComponent("Cola");
        }

        public override void AddBurger()
        {
            result.AddComponent("Big Burger");
        }

        public override void AddToy()
        {
            result.AddComponent("a Toy");
        }

        public override HappyMil returnOrder()
        {
            return result;
        }
    }

    class LittleHappyMilBuilder : Builder
    {
        HappyMil result = new HappyMil();

        public override void AddPotato()
        {
            result.AddComponent("Little Potato");
        }

        public override void AddCola()
        {
            result.AddComponent("Little Cola");
        }

        public override void AddBurger()
        {
            result.AddComponent("Little Burger");
        }

        public override void AddToy()
        {
            result.AddComponent("a Little Toy");
        }

        public override HappyMil returnOrder()
        {
            return result;
        }
    }

    class HappyMil {
        ArrayList set = new ArrayList();

        public void AddComponent(string component) {
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

    class Director {
        
        public void Complete(Builder obj)
        {
            obj.AddBurger();
            obj.AddCola();
            obj.AddPotato();
            obj.AddToy();
        }

    }
}
