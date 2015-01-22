using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflexion
{
    class Test {
        public void Mymethod(string name) {
            Console.WriteLine("Hello "+ name );
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Test tst = new Test();
            //tst.Mymethod();

            //-2-----------------------
            //create Type
            //Type t = Type.GetType("Reflexion.Test");
            
            ////Create Object Instance with our savet Type
            //var test = Activator.CreateInstance(t);
            
            //// get method from Class
            //var method = test.GetType().GetMethod("Mymethod");

            //Console.WriteLine(method);
            //// Call mthod
            //method.Invoke(test, new object[]{ "max" });


            //-3-----------------------
            //Assembly asm = Assembly.LoadFile(@"D:\Shturmin\CSharpStudyProjects\Reflexion\Reflexion\bin\Debug\CarLib.dll");
            //Assembly asm = Assembly.LoadFile(@"D:\Shturmin\CSharpStudyProjects\TestSecretLib\TestSecretLib\bin\Debug\TestSecretLib.dll");
            //Assembly asm = Assembly.LoadFile(@"D:\Shturmin\Trombik.dll");
            Assembly asm = Assembly.LoadFile(@"D:\Shturmin\Classdll.dll");

            //Console.WriteLine(asm.FullName);

            Type[] t = asm.GetTypes();

            foreach (Type item in t)
            {
                Console.WriteLine("\n Start new Item");
                ConstructorInfo[] constructors = item.GetConstructors();
                foreach (var constructor in constructors)
                {
                    Console.WriteLine("\n start Constructor");
                    ParameterInfo[] constructorArguments = constructor.GetParameters();
                    Console.WriteLine("\n argslength - " + constructorArguments.Length);
                    foreach (var constructorArgument in constructorArguments)
                    {
                        Console.WriteLine("!-" + constructorArgument.ParameterType);
                    }
                }

                //Console.WriteLine(item.Name);
                //var obj = Activator.CreateInstance(item);
                //foreach (MethodInfo classmethod in item.GetMethods())
                //{
                //    //if (classmethod.Name == "ToString")
                //    //{
                //    //    Console.WriteLine(classmethod.Invoke(obj, null));
                //    //}
                //    Console.WriteLine(classmethod.Name);
                //}

                //Console.WriteLine("\n");
                ////var method = obj.GetType().GetMethod("Start");
                //var method = obj.GetType().GetMethod("ToString");
                ////int parametersLength = obj.GetType().GetMethod("Stop").GetParameters().Length;
                
                //method.Invoke(obj, null);
            }
        }
    }
}
