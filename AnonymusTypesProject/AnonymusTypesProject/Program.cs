using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymusTypesProject
{
    class Product
    {
        public int quantity;
        public string name;
        public int price;

        public Product(string name, int quantity, int price)
        {
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }
        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }
    }


    static class ExtClass
    {
        public static int GetAllSumm(this List<Product> list)
        {
            var summ = (from l in list select l.Price * l.Quantity).Sum();
            return summ;
        }

        public static double GetPriceInUSD(this List<Product> list) {
            var summ = (from l in list select (l.Price * 0.04) * l.Quantity).Sum();
            return summ;
        }
    }

    class Program
    {

        //class Max {

        //    public int A = 10;
        //    public int test() {
        //        return A;
        //    }

        //}
        
        static void Main(string[] args)
        {
            //ANONYMUS OBJECTS
            ////object to isert
            //var test = new Max();
            //var man = new
            //{
            //    Name = "Petrov",
            //    LastName = "Den",
            //    Age = 23,
            //    Group = 1,
            //    T1 = test.A, //insert obkect property
            //    T2 = test.test() //insert result of object Function
            //};

            //Console.WriteLine(man.T2);

            ////Array with anonymus Objects
            //var mas = new[]{
            //    new{
            //        A=19,
            //        B=32
            //    },
            //    new{
            //        A = 23,
            //        B=43
            //    },
            //    new{
            //        A=89,
            //        B=24
            //    },
            //    new{
            //        A=90,
            //        B=654
            //    }
            //};


//            libraryDataContext db = new libraryDataContext();
////  linq request      | 1  |              |  2    |CREATE ANONYM OBJECT WITH RESULTS
//            var list = from b in db.Books select new { b.Name, b.YearPress };

//            foreach (var item in list)
//            {
//                Console.WriteLine("Name: {0} , Year: {1}", item.Name, item.YearPress);
//            }


            
            //EXTESIBLE METHODS
            List<Product> list = new List<Product>();
            list.Add(new Product("brot", 1, 10));
            list.Add(new Product("butter", 2, 100)); 

            Console.WriteLine(list.GetAllSumm());
            Console.WriteLine(list.GetPriceInUSD()); 
            
            //Console.WriteLine(ExtClass.GetAllSumm(list));
        }
    }
}
