using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyProject
{
    class Program
    {
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


            //Fill Academy
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
 
            //Interface
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
                                Console.WriteLine(LevelUpAcademy.Groups[groupchoose - 1]);
                                Console.WriteLine("Выберите номер студента");
                                studentchoose = Convert.ToInt32(Console.ReadLine());

                                if (studentchoose >= 0 && studentchoose < studentsAmout) {
                                    do
                                    {
                                        Console.WriteLine("\n Вы выбрали " + LevelUpAcademy.Groups[groupchoose - 1].Students[studentchoose]);
                                        Console.WriteLine("Выберите действие \n1. Выгнать \n2. Перевести в другую группу \n3. Изменить данные студента. \n0. Выход");
                                        choose = Convert.ToInt32(Console.ReadLine());

                                        switch (choose)
	                                    {
                                            case 1:
                                                LevelUpAcademy.RemoveStudentFromGroup(LevelUpAcademy.Groups[groupchoose - 1].Students[studentchoose]);
                                                Console.WriteLine("\n Вы выгнали " + LevelUpAcademy.Groups[groupchoose - 1].Students[studentchoose]);
                                                choose = 0;
                                                break;
                                            case 2:
                                                Console.WriteLine("Для перевода Студента в другую группу, выберите номер группы 1-{0}\n0. Выход", groupsAmount);
                                                toGroupchoose = Convert.ToInt32(Console.ReadLine());

                                                LevelUpAcademy.MoveStudentToGroup(LevelUpAcademy.Groups[groupchoose - 1].Students[studentchoose], LevelUpAcademy.Groups[toGroupchoose - 1].Name);

                                                Console.WriteLine("Вы перевели Студента в группу {0}, \nДля возврата нажмите любую клавишу.", LevelUpAcademy.Groups[toGroupchoose - 1].Name);
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
                                                            LevelUpAcademy.Groups[groupchoose - 1].Students[studentchoose].setField("name", changeData);
                                                            changed = true;
                                                            break;
                                                        case 2:
                                                            Console.WriteLine("\nВведите новую фамилию");
                                                            changeData = Console.ReadLine();
                                                            LevelUpAcademy.Groups[groupchoose - 1].Students[studentchoose].setField("surname", changeData);
                                                            changed = true;
                                                            break;
                                                        case 3:
                                                            Console.WriteLine("\nВведите новый возраст");
                                                            changeData = Console.ReadLine();
                                                            LevelUpAcademy.Groups[groupchoose - 1].Students[studentchoose].setField("age", changeData);
                                                            changed = true;
                                                            break;
                                                        default:
                                                                break;
	                                                }
                                                } while (changed == false);
                                                Console.WriteLine("\nСпасибо, теперь ваш студент имееет данные -" + LevelUpAcademy.Groups[groupchoose - 1].Students[studentchoose].ToString());
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
