using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithCommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            ////1---------------
            //pullRequest(@"C:\Users\Max\WebstormProjects\JS\lovehoney.co.uk\Sandbox\1-Debug");
            
           // pullRequest(@"C:\Users\Max\WebstormProjects\JS\bingohuone.com\Sandbox\1-Debug");

            pullRequest(@"C:\Users\Max\WebstormProjects\JS\casinohuone.com\Sandbox\1-Debug");

            ////2----------------------------------
            //const string strCmdText = "/C cd C:/Users/Max/Dropbox&dir";
            //Process.Start("CMD.exe", strCmdText);
            

            Console.ReadKey();
        }
        static void ResetAndPull(string folder) { 
            //// создаем процесс cmd.exe
            ProcessStartInfo psiOpt = new ProcessStartInfo(@"cmd.exe", @"/C git reset --hard origin/master&git clean -f -d&git pull origin master");
            psiOpt.WorkingDirectory = folder;
            // скрываем окно запущенного процесса
            psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            psiOpt.RedirectStandardOutput = true;
            psiOpt.UseShellExecute = false;
            psiOpt.CreateNoWindow = true;
            // запускаем процесс
            Process procCommand = Process.Start(psiOpt);
            // получаем ответ запущенного процесса
            StreamReader srIncoming = procCommand.StandardOutput;
            // выводим результат
            Console.WriteLine(srIncoming.ReadToEnd());
            // закрываем процесс
            Console.WriteLine("Done.");
            procCommand.WaitForExit();
        }
    }
}
