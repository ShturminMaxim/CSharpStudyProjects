using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApplication1
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        private static string x = " ";
        private static string y = "\n";
        private static string move = "right";
        private static string man = "#";

        static void Main(string[] args)
        {
            aTimer = new System.Timers.Timer(10000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 100;
            aTimer.Enabled = true;
            ConsoleKeyInfo keyinfo;

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

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            switch (move)
            {
                case "right" :
                    x = x + " ";
                    break;
                case "left" :
                    if (x.Length > 0) {
                        x = x.Remove(0, 1);
                    }
                    break;
                case "down":
                    y = y + "\n";
                    break;
                case "up":
                    if (y.Length > 0)
                    {
                        y = y.Remove(0, 1);
                    }
                    break;
                default:
                    break;
            }
            Console.Clear();
            Console.WriteLine(y + x + man);
        }
    }
}
