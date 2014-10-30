using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyProject
{
    class Student
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Age { get; private set; }
        public int Id { get; private set; }

        public Student(string name, string surname, string age, int id)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Id = id;
        }

        public void setField(string fieldName, string value)
        {
            switch (fieldName)
            {
                case "name":
                    this.Name = value;
                    break;
                case "surname":
                    this.Surname = value;
                    break;
                case "age":
                    this.Age = value;
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {

            return string.Format("{0} {1} , {2}лет", this.Name, this.Surname, this.Age);
        }
    }
}
