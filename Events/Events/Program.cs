using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    //delegate void scream();

    //class Max {
    //    public event scream maxScream;
    //    public string Name;

    //    public Max(string name) {
    //        this.Name = name;
    //    }
    //    public void startScream() {
    //        this.maxScream();
    //    }
    //    public void showMessage(Object sender, EventArgs arr)
    //    {
    //        Console.WriteLine(this.Name+ " heared a scream. It is a "+(Max)sender.Name);
    //        Console.ReadLine();
    //    }
    //}
    public class Student {
        string Name;

        public Student(string name) {
            this.Name = name;
        }
        public void SayHi(Object s, EventArgs arr){
            Student s1 = (Student)s;

            Console.WriteLine(this.Name+" say Hello to " + s1.Name);
        }

    }

    public class Group {
        List<Student> group = new List<Student>();

        public event EventHandler studentAdded;

        public void AddStudent(Student student) {
            group.Add(student);
            if(studentAdded != null) {
                studentAdded(student, EventArgs.Empty);
            }
            this.studentAdded += student.SayHi;
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Max iam = new Max("max");
            //Max you = new Max("man");

            //iam.maxScream += you.showMessage;

            //Console.ReadLine();
            //iam.startScream();

            //Console.ReadLine();

            //Group group = new Group();

            //Student stud1 = new Student("Bob");
            //Student stud2 = new Student("Max");
            //Student stud3 = new Student("Robert");
            
            //group.AddStudent(stud1);
            //Console.ReadLine();
            //group.AddStudent(stud2);
            //Console.ReadLine();
            //group.AddStudent(stud3);
            //Console.ReadLine();


            Button FristButton = new Button("Button 1");
            Button SecondButton = new Button("Button 2");
            Button ThirdButton = new Button("Button 3");

            Console.ReadLine();
            FristButton.ClickEvent();
            Console.ReadLine();
            SecondButton.ClickEvent();
            Console.ReadLine();
            ThirdButton.ClickEvent();
        }
    }
}
