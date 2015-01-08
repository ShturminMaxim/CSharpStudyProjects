using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegexpProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = "dasdasdasd";
            //Regex regex = new Regex("asd");
            //MatchCollection matchcollection = regex.Matches(s);
            //string Text = "";

            //for (int i = 0; i < matchcollection.Count; i++)
            //{
            //    Text += i+"-"+  matchcollection[i].Value + " ";
            //}
            //Console.WriteLine(Text);

            ///
             string s = "1 слон 2 слон 3 слон 4 слон 5 слон ";
             string sregx = "слон";
             Regex regex = new Regex(sregx); 
             Match match = regex.Match(s);

             string Text = "";

             if (match.Success)
             {
                 for (int i = 0; i < match.Groups.Count; i++)
                 {
                     Text += match.Groups[i].Value.ToString() + " ";
                 }
             }
             Console.WriteLine(Text);

             //int viI0 = 1;
             //while(match.Success) 
             //{
             // System.Console.WriteLine
             //   ("Применение регулярного выражения к строке " +
             //        Convert.ToString(viI0) + "й раз");
             // viI0++;
             //   System.Console.WriteLine("Match содержит: " + match.ToString());
             //       for(int i = 0; i < match.Groups.Count; i++)
             //       {
             //       Group group = match.Groups[i];
             //       System.Console.WriteLine("Group № "+Convert.ToString(i)+
             //                           " Значение: " + group);
             //       }
             // match = match.NextMatch();
             //}
            



        }
    }
}
