using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[10, 10];

            fillAndShowArrays(int[,] arr);
        }

        static void fillAndShowArrays(int[,] arr) 
        {
            Random r = new Random();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = r.Next(10, 100);
                    Console.Write(" " + arr[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadLine();

            return;
        }
    }
}
