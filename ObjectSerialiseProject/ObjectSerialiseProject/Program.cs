using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ObjectSerialiseProject
{
    [Serializable]
    class Human
    {
        [NonSerialized]
        public int age = 100;
        public string name = "man";

        public Human(int age, string name) { 
            this.age = age;
            this.name = name;
        }

        public void run()
        {
            Console.WriteLine("huraa");
        }

        public override string ToString()
        {
            return "Hi, i am "+this.name + " , i`m "+ this.age;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("my.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Human max = new Human(10, "Vasya");
            
            //bf.Serialize(fs, max);
            
            Human Den = (Human)bf.Deserialize(fs);
            fs.Close();

            Console.WriteLine(Den);
            Console.WriteLine(max);
        }
    }
}
