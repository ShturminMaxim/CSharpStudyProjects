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
            Human Petya = new Human(10, "Petya");
            Human Vasya = new Human(102, "Vasya");

            //bf.Serialize(fs, max2);
            
            //Human Ven = (Human)bf.Deserialize(fs);
            //Human Sam = (Human)bf.Deserialize(fs);

            //List<Human> humans = new List<Human>(){Petya, Vasya};
            List<Human> humans = (List<Human>)bf.Deserialize(fs);

            //bf.Serialize(fs, humans);

            fs.Close();

            foreach (var item in humans)
            {
                Console.WriteLine(item.name);
            }
            //Console.WriteLine(Ven);
            //Console.WriteLine(Sam);
        }
    }
}
