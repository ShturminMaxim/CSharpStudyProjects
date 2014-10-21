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
            Console.WriteLine("Please enter explression (example 15*2)");
            string mainString= Console.ReadLine();
            int leftBrackets = 0;
            int rightBrackets = 0;
            mainString.Replace(" ", "");

            //count brackets
            for (int i = 0; i < mainString.Length; i++)
            {
                if (mainString[i].ToString() == "(")
                {
                    leftBrackets++;
                }
                if (mainString[i].ToString() == ")")
                {
                    rightBrackets++;
                }
            }

            if (leftBrackets != rightBrackets) { 
                Console.WriteLine("Wrong expression");
            }

            //parse brackets
            // TODO add logic for additional brackets inside brackets
            CountInBrackets(ref mainString);
            
            // parse other expressions with symbols * / + -
            CountString(ref mainString);

            Console.WriteLine("\n Result - " + mainString);
            Console.ReadLine();
        }

        static string CountInBrackets(ref string str)
        {
            do
            {
                int openBracketIndex = str.IndexOf("(");
                int endBracketIndex = 0;
                if (openBracketIndex >= 0)
                {
                    string expressionInBracket = "";
                    for (int i = openBracketIndex + 1; i < str.Length; i++)
                    {
                        if (str[i].ToString() == ")")
                        {
                            endBracketIndex = i;
                            break;
                        }
                        else
                        {
                            expressionInBracket += str[i];
                        }
                    }
                    string result = CountString(ref expressionInBracket);
                    str = str.Substring(0, openBracketIndex) + result + str.Substring(endBracketIndex + 1, str.Length - 1 - (endBracketIndex));
                }
            } while (str.IndexOf("(") >= 0);
            return str;
        }
        static string CountString(ref string mainString)
        {
            string[] syms = new string[] { "*", "\\", "+", "-" };

            for (int i = 0; i < syms.Length; i++)
            {
                string sym = syms[i];
                if (mainString.IndexOf(sym) >= 0)
                {
                   // Console.WriteLine("\n string before {0} - {1}", sym, mainString);
                    do
                    {
                        int symIndex = mainString.IndexOf(sym);
                        string leftNum = GetLeftnum(ref mainString, symIndex);
                        int firstNumLengtht = leftNum.Length;

                        string rightNum = GetRightnum(ref mainString, symIndex);
                        int secondNumLengtht = rightNum.Length;

                        int res = CountSingleExpression(leftNum, mainString[symIndex], rightNum);

                        mainString = mainString.Substring(0, symIndex - firstNumLengtht) + res + mainString.Substring(symIndex + secondNumLengtht + 1, mainString.Length - 1 - (symIndex + secondNumLengtht));

                    } while (mainString.IndexOf(sym) >= 0);

                    //Console.WriteLine("\n string After {0} - {1}", sym, mainString);
                }
            }
            return mainString;
        }
        static string GetLeftnum(ref string mainString, int index)
        {
            int number;
            string num = "";

            for (int i = index-1; i >= 0; i--)
            {
                if (int.TryParse(mainString[i].ToString(), out number))
                {
                    num = mainString[i].ToString() + num;
                }
                else {
                    break;
                }
            }
            return num;
        }
        static string GetRightnum(ref string mainString, int index)
        {
            int number;
            string num = "";

            for (int i = index + 1; i < mainString.Length; i++)
            {
                if (int.TryParse(mainString[i].ToString(), out number))
                {
                    num = num + mainString[i].ToString();
                }
                else
                {
                    break;
                }
            }
            return num;
        }
        static int CountSingleExpression(string firstNum, char ExpressionOperantor, string SecondNum)
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

    }
}
