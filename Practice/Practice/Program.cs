using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        class Complex {
            public float a {set; get;}
            public float b { set; get; }

            public Complex(float first, float second)
            {
                this.a = first;
                this.b = second;
            }

            public static Complex operator *(Complex left, Complex right)
            {
                var newLeft = (left.a * right.a) - (left.b * right.b);
                var newRight = (left.b * right.a) + (left.a * right.b);

                Complex summ = new Complex(newLeft, newRight);
                return summ;
            }
            public static Complex operator *(float left, Complex right)
            {
                var newLeft = (left * right.a) - (0 * right.b);
                var newRight = (0 * right.a) + (left * right.b);

                Complex summ = new Complex(newLeft, newRight);
                return summ;
            }

            public static Complex operator -(Complex left, Complex right)
            {
                var newLeft = left.a - right.a;
                var newRight = left.b - right.b;

                Complex summ = new Complex(newLeft, newRight);
                
                return summ;
            }
            public static Complex operator -(Complex left, float right)
            {
                var newLeft = left.a - right;
                var newRight = left.b - 0;

                Complex summ = new Complex(newLeft, newRight);

                return summ;
            }


            public static Complex operator /(Complex left, Complex right)
            {
                var newLeft = ((left.a * right.a) + (left.b * right.b)) / ((right.a * right.a) + (right.b * right.b));
                var newRight = ((right.a * left.b) - (right.b * left.a)) / ((right.a * right.a) + (right.b * right.b));

                Complex summ = new Complex(newLeft, newRight);
                return summ;
            }

        }

        static void Main(string[] args)
        {
            Complex c1 = new Complex(1, 1);
            Complex c2;
            c2 = c1 - (c1 * c1 * c1 - 1) / (3 * c1 * c1);

            Console.WriteLine("Result = {0} + {1}i", c2.a, c2.b);

            Console.ReadLine();
        }
    }
}
