using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceII
{
    class Student : Person, Iprintable, IComparable
    {
        string GroupName { get; set; }

        public Student(string name, string surname, string group, int age)
            : base(name, surname)
        {   
            Random r = new Random();
            this.Age = age;
            this.GroupName = group;
        }

        //Iprintable implementation
        public void Print()
        {
            Console.WriteLine("Hi, i`m " + this.Name + " " + this.Surname + ". Group " + this.GroupName + ". Age - " + this.Age);
        }

        //standart IComparable interface implementation
        public int CompareTo(object anotherStudent) {
            Student student = (Student)anotherStudent;

            if (this.Name.CompareTo(student.Name) > 0) return 1;
            if (this.Name.CompareTo(student.Name) < 0) return -1;

            return 0;
        }

        //IComparer implementation
        public class StudentComparer : IComparer<Student>
        {
            string sortBy;
            int sortHow = 1;

            public StudentComparer(string sortBy, int sortHow) {
                this.sortBy = sortBy;
                this.sortHow = sortHow;
            }

            int IComparer<Student>.Compare(Student studOne, Student studTwo) {
                switch (sortBy)
                {
                    case "name":
                        if (studOne.Name.CompareTo(studTwo.Name) < 0)
                        {
                            if (sortHow == 1) return -1;
                            if (sortHow == -1) return 1; 
                        }
                        if (studOne.Name.CompareTo(studTwo.Name) > 0)
                        {
                            if (sortHow == 1) return 1;
                            if (sortHow == -1) return -1; 
                        }  
                        break;
                    case "age":
                        if (studOne.Age < studTwo.Age)
                        {
                            if (sortHow == 1) return -1;
                            if (sortHow == -1) return 1; 
                        }
                        if (studOne.Age > studTwo.Age)
                        {
                            if (sortHow == 1) return 1;
                            if (sortHow == -1) return -1; 
                        }
                        break;
                    default:
                        return 0;
                }
                return 0;
            }
        }
    }
}
