using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "156+(2*2)*12*2+42-(10+20)";
            int leftBrackets = 0;
            int rightBrackets = 0;
            a.Replace(" ", "");
            int mainResult = 0; 
            
            //string[] arrExpression = new string[a.Length];

            //count brackets
            for (int i = 0; i < a.Length; i++)
            {
                if(a[i].ToString() == "(") {
                    leftBrackets++;
                }
                if (a[i].ToString() == ")")
                {
                    rightBrackets++;
                }
                //arrExpression[i] = a[i].ToString();
            }

            if (leftBrackets != rightBrackets) { 
                Console.WriteLine("Wrong expression");
            }


            //start parsing
            //parse brackets
            if(a.IndexOf("(") >= 0) {
                do
                {
                  inBrackets(ref a, ref mainResult);  
                } while (a.IndexOf("(") >= 0);
                Console.WriteLine("\n Res - " + mainResult);
            }
            Console.WriteLine("\n string after brakets - " + a);
            // parse symbols * / + -
            count(ref a);


            Console.WriteLine("\n Result - " + a);
            Console.ReadLine();
        }

        static string getLeftnum(ref string a, int index)
        {
            int number;
            string num = "";

            for (int i = index-1; i >= 0; i--)
            {
                if (int.TryParse(a[i].ToString(), out number))
                {
                    num = a[i].ToString() + num;
                }
                else {
                    break;
                }
            }
            return num;
        }
        static string getRightnum(ref string a, int index)
        {
            int number;
            string num = "";

            bool result;
            for (int i = index+1; i < a.Length; i++)
            {
                if (int.TryParse(a[i].ToString(), out number))
                {
                    num = num + a[i].ToString();
                }
                else
                {
                    break;
                }
            }
            return num;
        }
        static int countExpression(string firstNum, char ExpressionOperantor, string SecondNum)
        {
            int result = 0;

            switch (ExpressionOperantor.ToString())
            {
                case "+":
                    result = Convert.ToInt32(firstNum) + Convert.ToInt32(SecondNum);
                    break;
                case "*":
                    result = Convert.ToInt32(firstNum) * Convert.ToInt32(SecondNum);
                    break;
                case "\\":
                    result = Convert.ToInt32(firstNum) / Convert.ToInt32(SecondNum);
                    break;
                case "-":
                    result = Convert.ToInt32(firstNum) - Convert.ToInt32(SecondNum);
                    break;
            }
            return result;
        }
        static void count(ref string a) {
            string[] syms = new string[] {"*","\\","+","-"};
            
            for (int i = 0; i < syms.Length; i++)
			{
			    string sym = syms[i];
                if (a.IndexOf(sym) >= 0)
                {
                    Console.WriteLine("\n string before {0} - {1}",sym, a);
                    do
                    {
                        int symIndex = a.IndexOf(sym);
                        string leftNum = getLeftnum(ref a, symIndex);
                        int firstNumLengtht = leftNum.Length;

                        string rightNum = getRightnum(ref a, symIndex);
                        int secondNumLengtht = rightNum.Length;
 
                        int res = countExpression(leftNum, a[symIndex], rightNum);

                        a = a.Substring(0, symIndex - firstNumLengtht) + res + a.Substring(symIndex + secondNumLengtht + 1, a.Length - 1 -(symIndex + secondNumLengtht));

                    } while (a.IndexOf(sym) >= 0);

                    Console.WriteLine("\n string After {0} - {1}",sym, a);
                }
			}
        }
        static void inBrackets(ref string a, ref int mainResult) {
            int bracketStartIndex = a.IndexOf("(");
            int bracketEndIndex = a.IndexOf(")");


            int res = countExpression(a[bracketStartIndex + 1].ToString(), a[bracketStartIndex + 2], a[bracketStartIndex + 3].ToString());

            a = a.Substring(0, bracketStartIndex) + res + a.Substring(bracketEndIndex + 1, a.Length - bracketEndIndex-1);
        }
    }
}
