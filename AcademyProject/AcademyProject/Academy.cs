using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyProject
{
    class Academy
    {
        public List<Group> Groups { private set; get; }
        private string Name { get; set; }

        public Academy(string name)
        {
            this.Name = name;
            Groups = new List<Group>();
        }

        public void AddGroup(Group newGroup)
        {
            Groups.Add(newGroup);
        }

        public void AddStudentToGroup(Student student, string groupName)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                if (Groups[i].Name == groupName)
                {
                    Groups[i].AddStudent(student);
                }
            }
        }
        public void RemoveStudentFromGroup(Student student)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                if (Groups[i].Students.Contains(student))
                {
                    Groups[i].RemoveStudent(student);
                }
            }
        }
        public void RemoveStudentFromGroup(Student student, string groupName)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                if (Groups[i].Name == groupName && Groups[i].Students.Contains(student))
                {
                    Groups[i].RemoveStudent(student);
                }
            }
        }

        public string Search(string surname)
        {
            List<Student> searchResult = this.SearchStudent(surname);
            string result = "Найдено " + searchResult.Count + " студентов";

            foreach (var student in searchResult)
            {
                result += "\n" + student.ToString();
            }

            return result;
        }

        public List<Student> SearchStudent(string surname)
        {
            List<Student> searchList = new List<Student>();

            for (int i = 0; i < Groups.Count; i++)
            {
                for (int j = 0; j < Groups[i].Students.Count; j++)
                {
                    if (Groups[i].Students[j].Surname.ToLower().IndexOf(surname) >= 0)
                    {
                        searchList.Add(Groups[i].Students[j]);
                    }
                }
            }
            return searchList;
        }

        public void MoveStudentToGroup(Student student, string groupName)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                if (Groups[i].Students.Contains(student))
                {
                    Groups[i].RemoveStudent(student);
                    this.AddStudentToGroup(student, groupName);
                }
            }
        }

        public override string ToString()
        {
            string academyString = "\n\t Groups in Level Up Academy ";

            foreach (var group in Groups)
            {
                academyString += "\n\t" + group.ToString();
            }
            return academyString;
        }
    }
}
