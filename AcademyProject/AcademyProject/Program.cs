using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyProject
{
    class Program
    {
        class Academy {
            public static List<Group> Groups { private set; get; }
            private string Name {get; set;}
            
            public Academy(string name) {
                this.Name = name;
                Groups = new List<Group>();
            }

            public void AddGroup(Group newGroup) {
                Groups.Add(newGroup);
            }
            
            public void AddStudentToGroup(Student student, string groupName) {
                for (int i = 0; i < Groups.Count; i++)
                {
                    if (Groups[i].Name == groupName) {
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

            public List<Student> SearchStudent(string surname) {
                List<Student> searchList = new List<Student>();

                for (int i = 0; i < Groups.Count; i++)
                {
                    for (int j = 0; j < Groups[i].Students.Count; j++)
                    {
                        if (Groups[i].Students[j].Surname.ToLower().IndexOf(surname) >= 0) {
                            searchList.Add(Groups[i].Students[j]);
                        }
                    }
                }
                return searchList;
            }

            public void MoveStudentToGroup(Student student, string groupName) {
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

        class Group {
            public List<Student> Students { private set; get; }
            public string Name { get; private set; }

            public Group(string name) {
                this.Name = name;
                Students = new List<Student>();
            }
            
            public void AddStudent(Student student) {
                Students.Add(student);
            }
            public void RemoveStudent(Student student)
            {
                Students.Remove(student);
            }

            public override string ToString()
            {
                string groupString = "\n Group - "+ this.Name;

                foreach (var student in Students)
                {
                    groupString += "\n\t" + Students.IndexOf(student) + ". " +student.ToString();
                }

                return groupString;
            }
        }

        class Student {
            public string Name { get; private set; }
            public string Surname { get; private set; }
            public string Age { get; private set; }
            public int Id { get; private set; }
            public Student(string name, string surname, string age, int id) {
                this.Name = name;
                this.Surname = surname;
                this.Age = age;
                this.Id = id;
            }
            
            public void setField(string fieldName, string value){
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

        static void Main(string[] args)
        {
            int groupsAmount = 4;
            int studentsAmout = 7;
            int counterForIds = 1;

            //interface variables
            string searchString = "";
            string changeData = "";
            int choose = 0;
            int groupchoose = 0;
            int studentchoose = 0;
            int toGroupchoose = 0;
            int studentChangeChoose = 0;

            string[] names = { "Иоганн", "Архип", "Хуан", "Радимир","Эратосфен", "Орэст", "Перуар", "Жорж" ,"Султан","Агапий"};
            string[] surnames = { "Трахтенберг", "Рибентроп", "Хеес", "Штраус", "Огинский", "Шопен", "Бах", "Брунея","Аккбарович","Сименон" };

            Random r = new Random();
            
            //create our Academy
            Academy LevelUpAcademy = new Academy("Level Up");



            for (int i = 1; i <= groupsAmount; i++)
            {
                Group currGroup = new Group("DotNet 14/"+i);
                for (int j = 0; j < studentsAmout; j++)
                {
                    Student currStudent = new Student(names[r.Next(0, 9)], surnames[r.Next(0, 9)], r.Next(16, 30).ToString(), counterForIds++);
                    
                    currGroup.AddStudent(currStudent);
                }
                LevelUpAcademy.AddGroup(currGroup);
            }

            //Console.WriteLine(LevelUpAcademy);
 
            do
            {
                Console.WriteLine("\n Enter number----------\n 1. Show all Students in Academy \n 2. Start editing groups. \n 3. Поиск студента. \n 0. Exit");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.WriteLine(LevelUpAcademy);
                        break;
                    case 2:
                        do
                        {
                            Console.Clear();

                            Console.WriteLine("\n Chose Group number 1-" + groupsAmount +"\n 0. to exit");
                            groupchoose = Convert.ToInt32(Console.ReadLine());
                            if (groupchoose - 1 >= 0 && groupchoose - 1 <= 3) {
                                Console.WriteLine(Academy.Groups[groupchoose - 1]);
                                Console.WriteLine("Выберите номер студента");
                                studentchoose = Convert.ToInt32(Console.ReadLine());

                                if (studentchoose >= 0 && studentchoose < studentsAmout) {
                                    do
                                    {
                                        Console.WriteLine("\n Вы выбрали "+Academy.Groups[groupchoose - 1].Students[studentchoose]);
                                        Console.WriteLine("Выберите действие \n1. Выгнать \n2. Перевести в другую группу \n3. Изменить данные студента. \n0. Выход");
                                        choose = Convert.ToInt32(Console.ReadLine());

                                        switch (choose)
	                                    {
                                            case 1:
                                                LevelUpAcademy.RemoveStudentFromGroup(Academy.Groups[groupchoose - 1].Students[studentchoose]);
                                                Console.WriteLine("\n Вы выгнали " + Academy.Groups[groupchoose - 1].Students[studentchoose]);
                                                choose = 0;
                                                break;
                                            case 2:
                                                Console.WriteLine("Для перевода Студента в другую группу, выберите номер группы 1-{0}\n0. Выход", groupsAmount);
                                                toGroupchoose = Convert.ToInt32(Console.ReadLine());

                                                LevelUpAcademy.MoveStudentToGroup(Academy.Groups[groupchoose - 1].Students[studentchoose], Academy.Groups[toGroupchoose - 1].Name);

                                                Console.WriteLine("Вы перевели Студента в группу {0}, \nДля возврата нажмите любую клавишу.", Academy.Groups[toGroupchoose - 1].Name);
                                                Console.ReadLine();
                                                choose = 0;
                                                break;
                                            case 3:
                                                bool changed = false;
                                                do
	                                            {
	                                                Console.WriteLine("\nВыберите поле для редактирования \n1.Имя\n2.Фамилия\n3.Возраст");
                                                    studentChangeChoose = Convert.ToInt32(Console.ReadLine());
                                                
                                                    switch (studentChangeChoose)
	                                                {
                                                        case 1:
                                                            Console.WriteLine("\nВведите новое имя");
                                                            changeData = Console.ReadLine();
                                                            Academy.Groups[groupchoose - 1].Students[studentchoose].setField("name", changeData);
                                                            changed = true;
                                                            break;
                                                        case 2:
                                                            Console.WriteLine("\nВведите новую фамилию");
                                                            changeData = Console.ReadLine();
                                                            Academy.Groups[groupchoose - 1].Students[studentchoose].setField("surname",changeData);
                                                            changed = true;
                                                            break;
                                                        case 3:
                                                            Console.WriteLine("\nВведите новый возраст");
                                                            changeData = Console.ReadLine();
                                                            Academy.Groups[groupchoose - 1].Students[studentchoose].setField("age", changeData);
                                                            changed = true;
                                                            break;
                                                        default:
                                                                break;
	                                                }
                                                } while (changed == false);
                                                Console.WriteLine("\nСпасибо, теперь ваш студент имееет данные -" + Academy.Groups[groupchoose - 1].Students[studentchoose].ToString());
                                                choose = 0;
                                                break;
		                                    default:
                                                break;
	                                    }

                                    } while (choose != 0);
                                }
                            }

                        } while (groupchoose != 0);
                        choose = 1;
                        break;
                    case 3:
                        Console.WriteLine("\nВведите фамилию или часть фамилии.");
                        searchString = Console.ReadLine();
                        Console.WriteLine(LevelUpAcademy.Search(searchString));
                        Console.WriteLine("\nДля продолжения нажмите любую клавишу");
                        Console.ReadLine();
                        break;
                    case 0:
                        break;
                    default:
                        break;
                }
            } while (choose != 0);

            Console.ReadLine();
        }
    }
}
