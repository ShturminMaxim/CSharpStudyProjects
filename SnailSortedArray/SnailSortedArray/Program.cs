using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailSortedArray
{
    class Program
    {
        static int[,] arr = new int[10, 10];
        static int startRow = 0;
        static int endRow = arr.GetLength(0);
        static int startElem = 0;
        static int endElem = arr.GetLength(1);

        static void Main(string[] args)
        {
            fillAndShowArrays(arr);
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

        static void goThrue(int[,] arr)
        {
            int startRow = 0;
            int endRow = arr.GetLength(0);
            int startElem = 0;
            int endElem = arr.GetLength(1);

            //for (int i = startRow; i < arr.GetLength(0); i++)
            //{
            //    for (int j = startElem; j < arr.GetLength(1); j++)
            //    {
                    
            //    }
            //}
        }
        static void compareAndReplace(int num) { 
            
        }
        static void right(int row, int from, int to) {
            for (int i = from; i <= to; i++)
            {
                compareAndReplace(arr[row, i]);
            }
        }
        static void down(int col, int from, int to)
        {
            for (int i = from; i <= to; i++)
            {

            }
        }
        static void left(int row, int from, int to)
        {
            for (int i = from; i <= to; i++)
            {

            }
        }
        static void up(int col, int from, int to)
        {
            for (int i = from; i <= to; i++)
            {

            }
        }
    }
}
