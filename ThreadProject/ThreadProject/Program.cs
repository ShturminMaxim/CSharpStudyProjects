using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadProject
{
    class FileWorker {
        public string Source { get; set; }
        public List<string> files;
        public List<string> sortedFiles;

        public FileWorker(string source)
        { 
            files = new List<string>();
            Source = source;
        }

        public void readFiles() {
            
            //emulate Reading logic
            Thread.Sleep(3000);
        }
        
        public void Sort()
        {
            //get unsorted files list, and create sorted files list
            //emulate sort Logic
            Thread.Sleep(2000);
        }

        public void getReadState() { 
        
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any source for File Searching.");
            string source = Console.ReadLine();

            FileWorker fr = new FileWorker(source);
            Thread readFilesThread = new Thread(new ThreadStart(fr.readFiles));
            readFilesThread.Name = "Read files Tread";
            readFilesThread.Start();
            
            Console.WriteLine("\n1.Show Files.\n2.Sort Files.\n3.Show Sorted Files");
            int choose = Convert.ToInt32(Console.ReadLine());
            switch (choose)
	        {
                case 1:
                    //Console.WriteLine(readFilesThread.ThreadState.ToString());
                    if (readFilesThread.ThreadState.ToString() != "Stopped")
                    {
                        Console.WriteLine("Sorry, still Reading files!");
                    }
                    else {
                        Console.WriteLine("This is your Files!"); 
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
		        default:
                    break;
	        }
            
            

        }
    }
}
