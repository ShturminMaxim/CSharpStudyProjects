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
        static int rowOfTheCheckedElem = 0;
        static int colOfTheCheckedElem = 0;

        static void Main(string[] args)
        {
            fillAndShowArrays(arr);
            goThrue(arr);
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
            int count = 0;
            int startDownRow = 0;
            int endDownRow = arr.GetLength(0) - 1;

            int startUpRow = arr.GetLength(0) - 1;
            int endUpRow = 0;

            int startRightElem = 0;
            int endRightElem = arr.GetLength(1)-1;

            int startLeftElem = arr.GetLength(1) - 1;
            int endLeftElem = 0;

            do
            {
                //RIGHT MOVE
                for (int i = startRightElem; i <= endRightElem; i++)
                {
                    compareAndReplace(ref arr[startDownRow, i]);
                }
                startDownRow++;
                endUpRow++;

                //DOWN MOVE
                for (int i = startDownRow; i <= endDownRow; i++)
                {
                    compareAndReplace(ref arr[i, endRightElem]);
                }
                endRightElem--;

                //LEfT MOVE
                for (int i = startLeftElem; i >= endLeftElem; i--)
                {
                    compareAndReplace(ref arr[endDownRow, i]);
                }
                endDownRow--;

                //UP MOVE
                for (int i = startUpRow; i >= endUpRow; i--)
                {
                    compareAndReplace(ref arr[i, startRightElem]);
                }
                startRightElem++;
            } while (startUpRow > endUpRow && startLeftElem > endLeftElem && startDownRow < endDownRow && startRightElem < endRightElem);

            if (count < arr.GetLength(1) * arr.GetLength(0)) {
                count++;
                goThrue(arr);
            }

            Console.ReadLine();
        }
        static void compareAndReplace(ref int num)
        {
            if (num > arr[rowOfTheCheckedElem, colOfTheCheckedElem])
            {
                int backup = arr[rowOfTheCheckedElem, colOfTheCheckedElem];
                arr[rowOfTheCheckedElem, colOfTheCheckedElem] = num;
                num = arr[rowOfTheCheckedElem, colOfTheCheckedElem];
            }
            //Console.Write(num+" ");
        }
        //static void right(ref int row, ref int from, ref int to) {
          
        //}
        //static void down(int col, int from, int to)
        //{
        //    for (int i = from; i <= to; i++)
        //    {
        //        compareAndReplace(arr[i, col]);
        //    }
        //}
        //static void left(int row, int from, int to)
        //{
        //    for (int i = from; i >= to; i--)
        //    {
        //        compareAndReplace(arr[row, i]);
        //    }
        //}
        //static void up(int col, int from, int to)
        //{
        //    for (int i = from; i >= to; i--)
        //    {
        //        compareAndReplace(arr[i, col]);
        //    }

        //}
    }
}
