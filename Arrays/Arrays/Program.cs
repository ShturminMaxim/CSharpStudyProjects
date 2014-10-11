using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Random number = new Random();
            int[] arr = new int[10];
            int length = arr.Length;
            int currNumber;
            int PreviousNumber;

            for (int i = 0; i < length; i++)
            {
                arr[i] = number.Next(1,15);
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < length; i++)
            {
                if ((i+1) % 2 == 0) {
                    PreviousNumber = arr[(i - 1)];
                    arr[i - 1] = arr[i];
                    arr[i] = PreviousNumber;
                }
            }

            Console.WriteLine("\n\n");
            for (int i = 0; i < length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.ReadLine();

            // second task
            int[,] arrTwo = new int[5,10];
            int cachedNumber;

            Console.WriteLine("\n\nenter two nubers between 1 and 5");
            int firstNumber = Convert.ToInt32(Console.ReadLine());
            int secondNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Before changing\n");

            for (int i = 0; i < arrTwo.GetLength(0); i++)
            {
                for (int j = 0; j < arrTwo.GetLength(1); j++)
                {
                    arrTwo[i, j] = number.Next(2, 20); 
                    Console.Write(arrTwo[i, j] + " ");
                }
                Console.WriteLine("\n");
            }

            for (int i = 0; i < arrTwo.GetLength(0); i++)
            {
                cachedNumber = arrTwo[i, firstNumber];
                arrTwo[i, firstNumber] = arrTwo[i, secondNumber];
                arrTwo[i, secondNumber] = cachedNumber;
            }

            Console.WriteLine("After changing\n");
            for (int i = 0; i < arrTwo.GetLength(0); i++)
            {
                for (int j = 0; j < arrTwo.GetLength(1); j++)
                {
                    Console.Write(arrTwo[i, j] + " ");
                }
                Console.WriteLine("\n");
            }

            Console.ReadLine();
        }
    }
}
