using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CubesWithSaves
{
    class CubeGame
    {
        // init scores
        int dropCount = 0;
        int userScore = 0;
        int computerScore = 0;
        string SavedCubes = "";

        public CubeGame() { 
               
        }
        public void StartGame() {
            SavedGame save = new SavedGame();
            if (save.CanBeLoaded() == true)
            {
                Console.WriteLine("\n1) Start New game\n2) Load Previous Game ");
                string chose = Console.ReadLine();
                switch (chose)
                {
                    case "1":
                        playGame();
                        break;
                    case "2":
                        LoadGame();
                        playGame();
                        break;
                    default:
                        Console.WriteLine("You chose Wrong manu item.");
                        StartGame();
                        break;
                }
            }
            else {
                Console.WriteLine("We Start New game");
                Console.ReadLine();
                playGame();
            }
        }
        private void LoadGame() {
            SavedGame save = new SavedGame();
            save.LoadGame();
            this.dropCount = save.dropCount;
            this.userScore = save.userScore;
            this.computerScore = save.computerScore;
            this.SavedCubes = save.savedCubes;

            Console.WriteLine("Game Loaded. Now we have data \n-Moves done -{0}\n-Your Score - {1}\n-Computer Score -{2}\n Log:\n", this.dropCount, this.userScore, this.computerScore);
            Console.WriteLine(this.SavedCubes);
        }
        private void showCube(int number)
        {
            string cubeImage = "";

            // chose cube image
            switch (number)
            {
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
            SavedCubes += cubeImage;
            Console.WriteLine(cubeImage);
            return;
        }
        private int getDropedCubeNumber()
        {
            //get random number
            Random r = new Random();
            int number = r.Next(1, 7);
            return number;
        }
        private void playGame()
        {
            do
            {
                //generate number
                int droppedNumber = getDropedCubeNumber();
                // clear curr cubes Summ
                int currSumm = 0;

                // code for Human
                if (dropCount % 2 == 0 || dropCount == 0)
                {
                    Console.WriteLine("1)Бросайте Кубик\n2)Сохранить и выйти");
                    string chose = Console.ReadLine();

                    switch (chose)
                    {
                        case "1":
                            break;
                        case "2":
                            SavedGame save = new SavedGame();
                            save.SaveGame(dropCount, userScore, computerScore, SavedCubes);
                            Console.WriteLine("Now we will exit");
                            return;
                            break;
                        default:
                            break;
                    }

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
                    SavedCubes += "\nВы выбросили " + currSumm + ", ваш результат - " + userScore + ", теперь бросает компьютерю";
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
                    SavedCubes += "\nКомпьютер выбросил " + currSumm + ", результат компьютера - " + computerScore + ", теперь бросает компьютерю";
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
            else
            {
                Console.WriteLine("\n Ничья");
            }

            //Restart the Game
            Console.WriteLine("\n нажмите любую клавишу что бы сыграть еще");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
