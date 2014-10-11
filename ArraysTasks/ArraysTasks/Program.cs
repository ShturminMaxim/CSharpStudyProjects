using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.
            //int[] firstTaskArray = new int[10];
            //int zeroCount = 0;
            //int[] resultArray = new int[10];

            //Random n = new Random();

            //for (int i = 0; i < firstTaskArray.Length; i++)
            //{
            //    firstTaskArray[i] = n.Next(0, 4);
            //    Console.Write(firstTaskArray[i]);
            //}

            //for (int i = 0; i < firstTaskArray.Length; i++)
            //{
            //    if (firstTaskArray[i] != 0)
            //    {
            //        resultArray[i - zeroCount] = firstTaskArray[i];
            //    }
            //    else
            //    {
            //        zeroCount++;
            //    }
            //}

            //for (int i = 1; i <= zeroCount; i++)
            //{
            //    resultArray[resultArray.Length - i] = -1;
            //}

            //Console.WriteLine('\n');
            //for (int i = 0; i < resultArray.Length; i++)
            //{
            //    Console.Write(resultArray[i]);
            //}
            //Console.ReadLine();


            //2.
            int[] firstTaskArray = new int[10];
            int negativeNumbers = 0;
            int positiveNumbers = 0;
            int[] negativeResultArray = new int[10];
            int[] positiveResultArray = new int[10];
            int[] resultArray = new int[10];

            Random n = new Random();


            for (int i = 0; i < firstTaskArray.Length; i++)
            {
                firstTaskArray[i] = n.Next(-5, 5);
                Console.Write(" " + firstTaskArray[i]);
            }


            for (int i = 0; i < firstTaskArray.Length; i++)
            {
                if (firstTaskArray[i] < 0)
                {
                    negativeResultArray[negativeNumbers] = firstTaskArray[i];
                    negativeNumbers++;
                }
                else
                {
                    positiveResultArray[positiveNumbers] = firstTaskArray[i];
                    positiveNumbers++;
                }
            }

            
            for (int i = 0; i < negativeNumbers; i++)
            {
                resultArray[i] = negativeResultArray[i];
            }
            for (int i = negativeNumbers; i < (negativeNumbers+positiveNumbers); i++)
            {
                resultArray[i] = positiveResultArray[i];
            }

            Console.WriteLine('\n');
            for (int i = 0; i < resultArray.Length; i++)
            {
                Console.Write(" " + resultArray[i]);
            }
            Console.ReadLine();

            //3.

            //4.

            //5.
        }
    }
}
