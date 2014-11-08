using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionClassIndexator
{
    class Program
    {
        class MyCollection
        {
            int[] mas;
            public MyCollection(int[] mas) {
                int i = 0;
                this.mas = new int[mas.Length];

                foreach (int item in mas)
                {
                    this.mas[i++] = item;    
                }
            }

            /// <summary>
            /// Indexator
            /// </summary>
            /// <param name="index"> elem index in array</param>
            /// <returns></returns>
            public int this[int index]
            {
                get {
                    return this.mas[index];
                }
                set {
                    try 
	                {	        
		                this.mas[index] = value;
	                }
                        catch(DivideByZeroException e) {
                        
                        }
                        catch(IndexOutOfRangeException e) {
                        
                        }
	                catch (Exception e)
	                {
		                Console.WriteLine(e.Message);
	                } finally {
                        
                    }


                }
            }

            public override string ToString()
            {
                foreach (int item in mas)
                {
                    Console.Write(" "+item);
                }

                return " \n";
            }
        }

        class Test {
            int a;
            double b;
            string str;

            public Test() {
                        a = 10
                            b = 20;
                str = "dsf";
            }
            public object this[] {
                get {
                    switch(index) {
                        case 0:
                            return a;
                        case 1:
                            return b;
                        case 2:
                            return str;
                        default:
                            return null;
                    }
                }
                set {
                    object temp = value;

                    if(temp is Int32 && indexer == 0) {
                        a = (int)temp;
                    } else if(temp is double  index == 1) {
                        d = (double)temp;
                    } else if(temp is string  index == 2) {
                        str = (string)temp;
                    } else {
                        Console.WriteLine("error in writing, missing type on this index");
                    }


                }
            }
        }
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] mas = new int[r.Next(5,15)];

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = r.Next(1, 20);
                Console.Write(mas[i]);
            }

            Console.WriteLine("\n");

            MyCollection myColl = new MyCollection(mas);

            myColl[3] = 1;
            Console.WriteLine(myColl[2]+" \n");




            Console.ReadLine();
        }
    }
}
