using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fractionProject
{
    class Program
    {
        class Fraction
        {
            //fields
            private int numerator;
            private int denominator;
            private int wholeNumber;

            //properties
            public int Num
            {
                get { return this.numerator; }
            }
            public int Denum
            {
                get { return this.denominator; }
            }

            //constructors
            public Fraction()
            {
                
            }
            public Fraction(int numerator, int denominator)
            {
                this.numerator = numerator;
                this.denominator = denominator;
                this.wholeNumber = 0;
            }

            //methods
            public Fraction PlusFraction(Fraction fraction)
            {
                Fraction result = new Fraction();

                result.numerator = (this.numerator*fraction.denominator) + (fraction.numerator*this.denominator);
                result.denominator = this.denominator*fraction.denominator;

                return result;
            }
            public Fraction MinusFraction(Fraction fraction)
            {
                Fraction result = new Fraction();

                result.numerator = (this.numerator * fraction.denominator) - (fraction.numerator * this.denominator);
                result.denominator = this.denominator * fraction.denominator;

                return result;
            }
            public Fraction MultiplyFraction(Fraction fraction)
            {
                Fraction result = new Fraction();

                result.numerator = this.numerator * fraction.numerator;
                result.denominator = this.denominator * fraction.denominator;

                return result;
            }
            public Fraction DivideFraction(Fraction fraction)
            {
                Fraction result = new Fraction();

                result.numerator = this.numerator * fraction.denominator;
                result.denominator = this.denominator * fraction.numerator;

                return result;
            }
            
            //privat method
            private Fraction reduce(Fraction notReducedFraction)
            {
                Fraction reducedFraction = notReducedFraction;

                for (int i = 2; i < notReducedFraction.numerator; i++)
                {
                    if (notReducedFraction.numerator%i == 0 && notReducedFraction.denominator%i == 0)
                    {
                        reducedFraction.numerator /= i;
                        reducedFraction.denominator /= i;
                        reducedFraction = reduce(reducedFraction);
                    }
                }
                if (reducedFraction.numerator > reducedFraction.denominator)
                {
                    reducedFraction.wholeNumber = reducedFraction.numerator/reducedFraction.denominator;
                    reducedFraction.numerator -= (reducedFraction.wholeNumber*reducedFraction.denominator);
                }

                return reducedFraction;
            }
           
            //override
            public override string ToString()
            {
                
                int reducedDenumerator = this.denominator;
                int reducedNumerator = this.numerator;
                string result = "";

                if (this.denominator%this.numerator == 0)
                {
                    reducedDenumerator = this.denominator / this.numerator;
                    reducedNumerator = 1;
                    result = string.Format(reducedNumerator + "\\" + reducedDenumerator);
                }
                else
                {
                    Fraction res = reduce(this);

                    if (res.wholeNumber == 0)
                    {
                        result = string.Format(res.numerator + "\\" + res.denominator);
                    } else
                    {
                        result = string.Format(res.wholeNumber + " " + res.numerator + "\\" + res.denominator);
                    }

                }

                return result;

            }
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();

            //init fractions
            Fraction firstFraction = new Fraction(rnd.Next(1, 20), rnd.Next(10,20));
            Thread.Sleep(300);
            Fraction secondFraction = new Fraction(rnd.Next(1, 20), rnd.Next(10, 20));

            // do mathematic methods
            Fraction minusResult = firstFraction.MinusFraction(secondFraction);
            Fraction plusResult = firstFraction.PlusFraction(secondFraction);
            Fraction multiplyResult = firstFraction.MultiplyFraction(secondFraction);
            Fraction divideResult = firstFraction.DivideFraction(secondFraction);


            //show results
            Console.WriteLine("Fraction {0}\\{1} plus fraction {2}\\{3}. Result = {4}", firstFraction.Num, firstFraction.Denum, secondFraction.Num, secondFraction.Denum , plusResult.ToString());
            Console.WriteLine("\nFraction {0}\\{1} minus fraction {2}\\{3}. Result = {4}", firstFraction.Num, firstFraction.Denum, secondFraction.Num, secondFraction.Denum, minusResult.ToString());
            Console.WriteLine("\nFraction {0}\\{1} multiplied by a fraction {2}\\{3}. Result = {4}", firstFraction.Num, firstFraction.Denum, secondFraction.Num, secondFraction.Denum, multiplyResult.ToString());
            Console.WriteLine("\nFraction {0}\\{1} divided by a fraction {2}\\{3}. Result = {4}", firstFraction.Num, firstFraction.Denum, secondFraction.Num, secondFraction.Denum, divideResult.ToString());
            

            Console.ReadLine();
        }
    }
}
