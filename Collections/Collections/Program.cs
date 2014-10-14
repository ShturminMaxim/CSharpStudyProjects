using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        //static int F(int a, int b) 
        //{
        //    return a + b;
        //}
        //static float F(float a, float b)
        //{
        //    return 1;
        //}
        //static int F(int[] arr) {
        //    int sum = 0;
        //    for (int i = 0; i < arr.length; i++)
        //    {
        //        sum += arr[i];
        //    }
        //    return summ;
        //}
        //static void Myfunc(ref int a, ref int b) {

        //    int t = a;
        //    b = a;
        //    a = t;

        //}
        static void Myfunc2(int[] arr) {
            arr[1] = 2;

        }
        static void Main(string[] args)
        {
            //int[] a = { 1, 2, 3, 4, 5, 6 };
            //Console.WriteLine(F(a));

            int[] a = { 0, 0, 0, };
            
            Myfunc2(a);
            
            Console.WriteLine(a[1]);
            
            Console.ReadLine();


        }
    }
}
