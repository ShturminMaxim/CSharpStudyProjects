using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckedUnchecked
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Boxing-Unboxing Start
            //int a = 10;
            //string i = "d";

            //// BOXING string to object
            //object o = i;

            //// before UNBOXING we can Check BOXED type by using IS operator
            //Console.WriteLine(o is string);
            //Console.ReadLine();

            //// Boxing-Unboxing End

            Random r = new Random();


            Console.WriteLine("Акция, посылка до 200 грамм за  4000 юаней .Сколько весит ваша покупкав граммах?");
            bool accepted = true;
            int limit = 4000;
            int max = 2147483447;
            int curr = Convert.ToInt32(Console.ReadLine());
            int res = 0;

            // weight Checker
            try
            {
                checked {
                    res = max + curr;
                }
            }
            catch
            {
                 Console.WriteLine("Ваша посылка слишком тяжелая. Вам необходимо будет заплатить 10000 юаней.");
                 accepted = false;
            }

            // money Checker
            try
            {
                if (accepted != false)
                {
                    Console.WriteLine("Вам необходимо " + limit + "юаней");
                }
                else {
                    limit = 10000;
                }

                Console.WriteLine("Сколько у вас есть денег?");
                int money = Convert.ToInt32(Console.ReadLine());

                if (money < limit) {
                    throw new Exception();
                }
            }
            catch 
            {
                Console.WriteLine("Простите, денег не достаточно. До свидания.");
                accepted = false;
            }


            if (accepted == true) {
                Console.WriteLine("Спасибо, отправили. До свидания.");
            }


            Console.ReadLine();
        }
    }
}
