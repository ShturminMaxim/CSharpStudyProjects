using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;


namespace worm
{
    class Program
    {
        private static System.Timers.Timer myTimer;
        private static int fieldWidth = 40;
        private static int fieldHeight = 40;
        private static int[,] field = new int[fieldWidth, fieldHeight];
        private static string head = "0";
        private static int x = 1;
        private static int y = 1;
        private static string map = "";
        private static string move = "right";


        static void Main(string[] args)
        {

            myTimer = new System.Timers.Timer(80);
            myTimer.Elapsed += onTimerUpdater;
            myTimer.Enabled = true;

            ConsoleKeyInfo keyinfo;
            Console.WindowWidth = 50;
            Console.WindowHeight = Console.LargestWindowHeight;

            do
            {
                keyinfo = Console.ReadKey();
                if (keyinfo.Key.ToString() == "LeftArrow")
                {
                    move = "left";
                }
                if (keyinfo.Key.ToString() == "RightArrow")
                {
                    move = "right";
                }
                if (keyinfo.Key.ToString() == "UpArrow")
                {
                    move = "up";
                }
                if (keyinfo.Key.ToString() == "DownArrow")
                {
                    move = "down";
                }
            }
            while (keyinfo.Key != ConsoleKey.X);
        }

        private static void onTimerUpdater(Object source, ElapsedEventArgs e)
        {
            Console.Clear();
            map = "";
            switch (move)
            {
                case "right":
                    x++;
                    break;
                case "left":
                    x--;
                    break;
                case "down":
                    y++;
                    break;
                case "up":
                    y--;
                    break;
                default:
                    break;
            }
            
            if (x > fieldWidth-1)
                x = 0;
            if (y > fieldHeight-1)
                y = 0;
            if (x < 0)
                x = fieldWidth-1;
            if (y < 0)
                y = fieldHeight-1;

            for (int i = 0; i < field.GetLongLength(0); i++)
            {
                for (int j = 0; j < field.GetLongLength(1); j++)
                {
                    field[i, j] = 0;
                }
            }

            field[y, x] = 1;

            for (int i = 0; i < field.GetLongLength(0); i++)
            {
                for (int j = 0; j < field.GetLongLength(1); j++)
                {
                    if (field[i, j] == 0)
                    {
                        map = map + " ";
                    }
                    if (field[i, j] == 1)
                    {
                        map = map + head;
                    }
                }
                map = map + "\n";
            }
            Console.WriteLine(map);
        }
    }
}
