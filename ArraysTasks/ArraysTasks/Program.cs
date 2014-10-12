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
            //Array tasks
            StartFirstTask();
            StartSecondTask();
            StartThirdTask();
            StartFourthTask();
            StartFifthTask();
            
            // Method tasks
            StartSixthTask();
            StartSeventhTask();
            StartEighthTask();
        }

        private static void StartFirstTask()
        {
            // First Task
            //1.
            Console.WriteLine("1. Revert and modify array");

            int[] firstTaskArray = new int[10];
            int zeroCount = 0;
            int[] resultArray = new int[10];

            Random n = new Random();

            for (int i = 0; i < firstTaskArray.Length; i++)
            {
                firstTaskArray[i] = n.Next(0, 4);
                Console.Write(firstTaskArray[i]);
            }

            for (int i = 0; i < firstTaskArray.Length; i++)
            {
                if (firstTaskArray[i] != 0)
                {
                    resultArray[i - zeroCount] = firstTaskArray[i];
                }
                else
                {
                    zeroCount++;
                }
            }

            for (int i = 1; i <= zeroCount; i++)
            {
                resultArray[resultArray.Length - i] = -1;
            }

            Console.WriteLine('\n');
            for (int i = 0; i < resultArray.Length; i++)
            {
                Console.Write(resultArray[i]);
            }
            Console.ReadLine();
        }
        private static void StartSecondTask()
        {
            //Second task
            //2. 
            // TODO add second variant with Bubling Sort algorythm
            // i think too much variables and arrays 
            Console.WriteLine("2. Modify an array of numbers");
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

            // sort positive and negative numbers
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

            // gather data in result array
            for (int i = 0; i < (negativeNumbers + positiveNumbers); i++)
            {
                if (i <= negativeNumbers)
                {
                    resultArray[i] = negativeResultArray[i];   
                }
                else
                {
                    resultArray[i] = positiveResultArray[i - negativeNumbers];
                }

            }

            Console.WriteLine('\n');
            for (int i = 0; i < resultArray.Length; i++)
            {
                Console.Write(" " + resultArray[i]);
            }
            Console.ReadLine();
        }
        private static void StartThirdTask()
        {
            //Third task
            //3.
            Console.WriteLine("3. Get string from user. Show statistic");
            Console.WriteLine("Please enter text for making statitstic");
            string givenData = Console.ReadLine();
            int totalSymbols = givenData.Length;
            int totalLetters = 0;
            int totalUppercaseLetters = 0;
            int totalLowercaseLetters = 0;
            int totalNumbers = 0;
            int totalSpaces = 0;
            int totalOthersElems = 0;
            int num = 0;

            for (int i = 0; i < givenData.Length; i++)
            {
                char currSign = givenData[i];
                if (currSign.ToString() == " ")
                {
                    totalSpaces++;
                    continue;
                }
                if (int.TryParse(currSign.ToString(), out num))
                {
                    totalNumbers++;
                    continue;
                }
                if ((int)currSign >= 65 && (int)currSign <= 90)
                {
                    totalUppercaseLetters++;
                    continue;
                }
                else if ((int)currSign >= 97 && (int)currSign <= 122)
                {
                    totalLowercaseLetters++;
                    continue;
                }
                totalOthersElems++;
            }
            totalLetters = totalSymbols - totalSpaces - totalNumbers - totalOthersElems;

            Console.WriteLine("- total Symbols: {0} \n" +
                              "- total Letters: {1} \n" +
                              "- total UpperCase: {2} \n" +
                              "- total LowerCase: {3} \n" +
                              "- total numbers: {4} \n" +
                              "- total spaces: {5} \n" +
                              "- total other elements: {6} \n",
                              totalSymbols,
                              totalLetters,
                              totalUppercaseLetters,
                              totalLowercaseLetters,
                              totalNumbers,
                              totalSpaces,
                              totalOthersElems);

            Console.ReadLine();
        }
        private static void StartFourthTask()
        {
            //Fourth task
            //4.
            Console.WriteLine("4. Get string from client. Reverse given string and replace Uppercase letters with Lowercase letters and Lower to Upper");
            Console.WriteLine("Please enter text for modify");
            string initialString = Console.ReadLine();
            char[] charsArray = new char[initialString.Length - 1];

            //transform our string to array nad reverse array
            charsArray = initialString.ToCharArray();
            Array.Reverse(charsArray);

            // Clear string before redefine
            initialString = "";

            // modify Letters and recreate final string
            for (int i = 0; i < charsArray.Length; i++)
            {
                if (Char.IsUpper(charsArray[i]))
                {
                    initialString += charsArray[i].ToString().ToLower();
                };
                if (Char.IsLower(charsArray[i]))
                {
                    initialString += charsArray[i].ToString().ToUpper();
                };
            }

            Console.WriteLine("\n" + initialString);
            Console.ReadLine();
        }
        private static void StartFifthTask()
        {
            //Fifth task
            //5.
            Console.WriteLine("5. create jagged(int[][]) array for 5 school disciplines");
            Console.WriteLine("Average ratings for school disciplines: \n");
            Random r = new Random();
            int[][] ratings = new int[5][];
            string[] disciplines = new string[]
            {
                "mathematics",
                "physics",
                "astronomy",
                "music",
                "programming"
            };

            for (int i = 0; i < ratings.Length; i++)
            {
                int ratingsSumm = 0;
                ratings[i] = new int[r.Next(3, 10)];

                Console.Write(disciplines[i] + " : ");
                for (int j = 0; j < ratings[i].Length; j++)
                {
                    ratings[i][j] = r.Next(2, 12);
                    ratingsSumm += ratings[i][j];
                    Console.Write(" " + ratings[i][j]);
                }
                Console.WriteLine(" average: " + ratingsSumm / ratings[i].Length + "");
            }

            Console.ReadLine();
        }

        private static void StartSixthTask()
        {
            Console.WriteLine("6. Create function which checks whether a number is a palindrome");
            Console.WriteLine("Please, enter the number");
            int num = Convert.ToInt32(Console.ReadLine());

            if (isPolindrom(num))
            {
                Console.WriteLine("Число Полиндром!");
            }
            else
            {
                Console.WriteLine("Число не Полиндром!");
            }

            Console.ReadLine();
        }
        private static bool isPolindrom(int num)
        {
            int divider = 10;
            int currNum = num;
            int reverted = 0;

            do
            {
                reverted = reverted * divider + currNum % divider;
                currNum = currNum / divider;
            } while (currNum % divider != 0);

            return reverted == num;
        }

        private static void StartSeventhTask()
        {
            Console.WriteLine("7. Create function which delete all numbers “1” from given number");
            Console.WriteLine("Please, enter the number");

            int num = Convert.ToInt32(Console.ReadLine());
            int revertedAnCleaned = revertAndClean(num);

            Console.WriteLine(revertAndClean(revertedAnCleaned));
            Console.ReadLine();	
        }
        private static int revertAndClean(int num)
        {
            int divider = 10;
            int currNum = num;
            int reverted = 0;

            do
            {
                if (currNum % divider != 1)
                {
                    reverted = reverted * divider + currNum % divider;
                }
                currNum = currNum / divider;
            } while (currNum % divider != 0);

            return reverted;
        }

        private static void StartEighthTask()
        {
            Console.WriteLine("8. Create recursive function, which checks whether a string  is symmetric.");
            Console.WriteLine("Please, enter the text");
            string str = Console.ReadLine();

            Console.WriteLine(isSymmetric(str));
            Console.ReadLine();
        }
        public static bool isSymmetric(string str)
        {
            bool isSymetric = true;
            int length = str.Length;

            if (str.Length == 0 || str.Length == 1) return isSymetric;

            if (str[0] != str[length - 1])
            {
                isSymetric = false;
            }
            else
            {
                str = str.Remove(str.Length - 1, 1);
                str = str.Remove(0, 1);
                isSymmetric(str);
            }


            return isSymetric;
        }
    }
}
