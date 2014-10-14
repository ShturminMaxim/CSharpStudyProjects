using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoxGame
{
    class Program
    {
        static void showCube(int number) 
        {
            string cubeImage = "";

            // chose cube image
            switch (number) {
                case 1:
                    cubeImage = "*******\n*     *\n*     *\n*  *  *\n*     *\n*     *\n*******";
                    break;
                case 2:
                    cubeImage = "*******\n*     *\n*     *\n* * * *\n*     *\n*     *\n*******";
                    break;
                case 3:
                    cubeImage = "*******\n*     *\n* *   *\n*  *  *\n*   * *\n*     *\n*******";
                    break;
                case 4:
                    cubeImage = "*******\n*     *\n* * * *\n*     *\n* * * *\n*     *\n*******";
                    break;
                case 5:
                    cubeImage = "*******\n*     *\n* * * *\n*  *  *\n* * * *\n*     *\n*******";
                    break;
                case 6:
                    cubeImage = "*******\n*     *\n* * * *\n* * * *\n* * * *\n*     *\n*******";
                    break;
                default:
                    cubeImage = "";
                    break;
            }

            // show cube
            Console.WriteLine(cubeImage);
            return;
        }
        static int getDropedCubeNumber() {
            //get random number
            Random r = new Random();
            int number = r.Next(1, 7);
            return number;
        }
        static void game() 
        {
            // init scores
            int dropCount = 0;
            int userScore = 0;
            int computerScore = 0;

            do
            {
                //generate number
                int droppedNumber = getDropedCubeNumber();
                // clear curr cubes Summ
                int currSumm = 0;

                // code for Human
                if (dropCount % 2 == 0 || dropCount == 0)
                {
                    Console.WriteLine("Бросайте Кубик");
                    Console.ReadLine();

                    //show first cube
                    showCube(droppedNumber);
                    currSumm += droppedNumber;

                    //get new random number
                    droppedNumber = getDropedCubeNumber();
                    //show second cube
                    showCube(droppedNumber);
                    currSumm += droppedNumber;

                    // encrease user score
                    userScore += currSumm;

                    Console.WriteLine("Вы выбросили {0}, ваш результат - {1}, теперь бросает компьютерю", currSumm, userScore);
                    Thread.Sleep(1000);
                }
                // code for Computer
                else                 
                {
                    //show first cube
                    showCube(droppedNumber);
                    currSumm += droppedNumber;

                    //get new random number
                    droppedNumber = getDropedCubeNumber();
                    //show second cube
                    showCube(droppedNumber);
                    currSumm += droppedNumber;

                    // encrease computer score
                    computerScore += currSumm;

                    Console.WriteLine("Компьютер выбросил {0}, результат компьютера - {1} , теперь бросаее Вы", currSumm, computerScore);
                    Thread.Sleep(1000);
                }
                dropCount++;
            } while (dropCount < 6);

            Console.WriteLine("\nСпасибо, игра закончена.\n\nВаш результат - {0}\nРезультат компьютера - {1}", userScore, computerScore);
            
            // Count game results
            if (userScore > computerScore)
            {
                Console.WriteLine("\n Вы выиграли");
            }
            else if (userScore < computerScore)
            {
                Console.WriteLine("\n Выиграл компьютер");
            }
            else {
                Console.WriteLine("\n Ничья");
            }

            //Restart the Game
            Console.WriteLine("\n нажмите любую клавишу что бы сыграть еще");
            Console.ReadLine();
            Console.Clear();
            game();
        }
        static void Main(string[] args)
        {
            // Start the game
            game();
            Console.ReadLine();
        }
    }
}
