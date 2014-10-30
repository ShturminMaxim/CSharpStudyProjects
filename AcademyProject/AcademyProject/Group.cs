using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyProject
{
    class Group
    {
        public List<Student> Students { private set; get; }
        public string Name { get; private set; }

        public Group(string name)
        {
            this.Name = name;
            Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }

        public override string ToString()
        {
            string groupString = "\n Group - " + this.Name;

            foreach (var student in Students)
            {
                groupString += "\n\t" + Students.IndexOf(student) + ". " + student.ToString();
            }

            return groupString;
        }
    }
}
