using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPropertiesProject
{
    class Program
    {
        class Animal {
            public string Name { get; set; }

            public Animal(string str) {
                this.Name = str;
            }

            public string EditName {
                set {
                    if(value == "qwerty")
                        this.Name = value;
                    else
                        Console.WriteLine("Sorry");
                }
            }

            public override string ToString()
            {
 	             return this.Name;
            }
        }


        class Plants {
            public string Type { get; set; }
            public string Name { get; set; }

            static Plants() {
                Console.WriteLine("Static");
            }

            public override string ToString()
            {
                return string.Format(this.Type+"--"+this.Name);
            }
        }

        class Bank {

            static int balance = 10000;

            public string nameFillial {get; set;}
            public int CountClientFillial {get; set;}



            public Bank(string str) { 
                this.nameFillial = str;
                this.CountClientFillial = 0;
            }

            public int Give(int money) {
                this.CountClientFillial++;
                if (money <= Bank.balance)
                {
                    Bank.balance -= money;
                }
                else {
                    Console.WriteLine("Not enough money in Bank");
                }
                return money;
            }

            public int BankBalance {
                get {
                    return Bank.balance;
                }
            }

            public static int Clients(Bank[] fillials) {
                int count = 0;

                foreach(Bank b in fillials) {
                    count += b.CountClientFillial;    
                }    
                return count;
            }

        }
        
        static void Main(string[] args)
        {
            //11111111111
            //Animal a = new Animal("asd");
            //a.EditName = "qwerty";
            //Console.WriteLine(a);

            //22222222
            //Plants p = new Plants() { Type="d",Name="sad"};
            //Console.WriteLine(p);
            //Console.ReadLine();

            //33333333333333
            Bank[] fillials = new Bank[4];
            int choose = 0;
            int fillialIndex = 0;
            Random r = new Random();


            for (int i = 0; i < fillials.Length; i++)
            {
                fillials[i] = new Bank("Bank numer"+(i+1));
            }

            do
            {
                fillialIndex = r.Next(0,4);
                Console.WriteLine("1-Give money \n2-Get balance \n0-Exit");
                choose = Convert.ToInt32(Console.ReadLine());

                switch (choose)
                {
                    case 1 :
                        Console.WriteLine("Credit summ - "+fillials[fillialIndex].Give(r.Next(100, 10000)));
                        break;
                    case 2 :
                        Console.WriteLine("bank numer " + fillialIndex+1 +" -"+ fillials[fillialIndex].BankBalance);
                        break;
                    case 0 :
                        Console.WriteLine("Buy man!");
                        break;
                    default:
                        break;
                }
            } while (choose != 0);

            foreach(Bank b in fillials) {
                Console.WriteLine(b.nameFillial + " " + b.CountClientFillial);
            }
            Console.WriteLine("clients - " + Bank.Clients(fillials));
        }
    }
}
