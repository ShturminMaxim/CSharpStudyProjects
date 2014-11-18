using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_next
{
    enum Sex { Male, Female };
    enum Plants { Tree, Bush, Grass, Flower}
    class Program
    {
        //class Human {
        //    string firstName;
        //    int age;
        //    string lastName;

        //    Sex sex;

        //    public Human(string firstName = "Maxim", string lastName = "Shturmin", int age = 10, Sex sex = Sex.Male)
        //    { 
        //        this.firstName = firstName;
        //        this.age = age;
        //        this.lastName = lastName;
        //        this.sex = sex;
        //    }

        //    public override string ToString()
        //    {
        //        return "Name - " + this.firstName + "; LastName - " + this.lastName + "; Age -" + this.age + "; Sex -" + this.sex;
        //    }
        //}
        //class Student : Human {
        //    string group;
            
        //    public Student(string groupName, string firstName, string lastName, int age, Sex sex):base(firstName, lastName, age, sex) {
        //        this.group = groupName;
        //    }

        //    public Student(string groupName):base()
        //    {
        //        this.group = groupName;
        //    }  


        //    public override string ToString()
        //    {
        //         return base.ToString()+"; group - "+this.group;
        //    }
        //}




        //Plant Class and inheritance
        class Plant {
            string name;
            protected int age;
            Plants type;

            public Plant(string name = "Dummy plant", Plants type = Plants.Tree, int age = 0) {
                this.name = name;
                this.type = type;
                this.age = age;
            }

            public override string ToString()
            {
 	             return "\nI am a "+this.type+", My name is "+this.name+" and i`m "+this.age+" years old.";
            }

            protected void growUp(){
                this.age += 1;
            }

            protected void changeName(string newName) {
                this.name = newName;
            }


        }

        class Tree:Plant {
            int branches;

            public Tree(string name, int branches = 20):base(name) {
                this.branches = branches;
            }
            public Tree(string name, int branches, int age): base(name, Plants.Tree, age)
            {
                this.branches = branches;
            }

            public override string ToString()
            {
                return base.ToString()+" I have "+this.branches+" branches.";
            }
        }

        class Flower : Plant {
            int leafs;

            public Flower(string name, int leafs)
                : base(name, Plants.Flower)
            {
                this.leafs = leafs;
            }
            public Flower(string name, int leafs, int age): base(name, Plants.Flower, age)
            {
                this.leafs = leafs;
            }
            public override string ToString()
            {
                return base.ToString() + " I have " + this.leafs + " leafs.";
            }
        }

        class AppleTree : Tree {
            int apples;
            string name;

            public AppleTree(string name, int apples, int age):base(name) {
                this.age = age;
                this.name = name;
                this.apples = apples;
            }

            public AppleTree(string name, int apples, int branches, int age)
                : base(name, branches, age)
            {
                this.name = name;
                this.apples = apples;
            }

            public override string ToString()
            {
                return base.ToString() + " I grew up, and i have " + this.apples + " apples.";
            }

        }
        static void Main(string[] args)
        {
            //Human human = new Human();
            //Student vasya = new Student("M1","Vasya","Dron",16, Sex.Male);
            //Student maxim = new Student("M2");

            //Console.WriteLine(vasya);
            //Console.WriteLine(maxim);

            Tree palm = new Tree("South palm", 5);
            Tree oak = new Tree("Big Oak", 35, 350);
            Flower rose = new Flower("Desert Rose", 15);
            Flower tulip = new Flower("Boring Tulip", 10, 1);

            AppleTree summerApple = new AppleTree("Summer Apple", 15, 1);
            AppleTree winterApple = new AppleTree("Winter Apple", 35, 40);

            Console.WriteLine(palm);
            Console.WriteLine(oak);
            Console.WriteLine(rose);
            Console.WriteLine(tulip);

            Console.WriteLine(summerApple);
            Console.WriteLine(winterApple);
        }
    }
}
