using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSystemProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //---1-----------
            //Directory.SetCurrentDirectory("D:/Shturmin");
            //string source = "D:/Shturmin";
            
            //string[] drives = Directory.GetLogicalDrives();
            //for (int i = 0; i < drives.Length; i++)
            //{
            //    Console.WriteLine(drives[i]);
            //}
            //Console.WriteLine("Chose your Drive letter");
            //string drive = Console.ReadLine();
            //source = drive+":/";
            //Console.WriteLine("Enter your mask");
            //string mask = Console.ReadLine();
            //  try
            //{
            //    var dir = Directory.EnumerateFiles(source, mask, SearchOption.AllDirectories);
            //    Console.WriteLine("\n Count - " + dir.Count());
            //    foreach (var item in dir)
            //    {
            //        Console.WriteLine(item);
            //    }
            //    Console.WriteLine("\n End of search.");
            //}
            //  catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //---2-----------
            //string folderToRename = "D:/Shturmin/my";
            //Console.WriteLine("Enter new name for folder -"+folderToRename);
            
            //string newName = Console.ReadLine();
            //Directory.Move(folderToRename, Directory.GetParent(folderToRename) +"/"+ newName);
            //Console.ReadLine();

            //Console.WriteLine("Let`s copy folder -" + folderToRename);

            //---3-----------
            //copy 
            //string folderToCopy = "D:/Shturmin/my";
            //string folder = "D:/Shturmin/test";
            //Console.WriteLine("Let`s copy folder -" + folderToCopy + " to folder -" + folder);

            //not finished. not working code
            //FileSystem.CopyDirectory(folderToCopy, folder, True);
        }
    }
}
