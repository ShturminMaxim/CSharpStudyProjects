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
        public bool sortStatus = false;
        public bool readFileStatus = false;

        public FileWorker(string source)
        { 
            files = new List<string>();
            Source = source;
        }
        public Thread createThread(string type) {
            Thread currentThread = null;
            switch (type)
            {
                case "read":
                    currentThread = new Thread(new ThreadStart(this.readFiles));
                    break;
                case "sort":
                    currentThread = new Thread(new ThreadStart(this.Sort));
                    break;
                default:
                    currentThread = null;
                    break;
            }

            if (currentThread != null) {
                currentThread.Name = type;
                currentThread.Start();
            }

            return currentThread;
        }
        public void readFiles() {
            //emulate Reading logic
            readFileStatus = false;
            
            Thread.Sleep(3000);
            
            readFileStatus = true;
        }
        
        public void Sort()
        {
            //get unsorted files list, and create sorted files list
            //emulate sort Logic
            sortStatus = false;
            
            Thread.Sleep(2000);

            sortStatus = true;
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
            Thread readsteream = fr.createThread("read");
            
            Console.WriteLine("\n1.Show Files.\n2.Sort Files.\n3.Show Sorted Files\0.Exit");
            int choose;
            Thread sortsteream = null;
            string text;
            do
            {
                text = Console.ReadLine();
                if (text.Length > 0)
                {
                    choose = Convert.ToInt32(text);
                }
                else {
                    choose = 99;
                }

                switch (choose)
                {
                    case 1:

                        if (readsteream.ThreadState.ToString() != "Stopped")
                        {
                            Console.WriteLine("Sorry, still Reading files!");
                        }
                        else
                        {
                            if (fr.readFileStatus == true)
                            {
                                Console.WriteLine("This is your Files!");
                            }
                        }
                        break;
                    case 2:
                        if (readsteream.ThreadState.ToString() != "Stopped")
                        {
                            Console.WriteLine("Sorry, still Reading files!");
                        }
                        else
                        {
                            if (fr.readFileStatus == true)
                            {
                                if (fr.sortStatus != true)
                                {
                                    sortsteream = fr.createThread("sort");
                                    Console.WriteLine("Sorting...");
                                }
                                else {
                                    Console.WriteLine("Already Sorted! Here is your sorted files.");
                                }
                            } 
                        }
                        break;
                    case 3:
                        if (fr.sortStatus != true && sortsteream == null)
                        {
                            Console.WriteLine("Files still not sorted...");
                            if (sortsteream != null && sortsteream.ThreadState.ToString() == "Stopped")
                            {
                                Console.WriteLine("Files sorted! Here is your sorted files");
                            }
                            else { 
                            
                            }
                        }
                        else
                        {
                            Console.WriteLine("Files sorted! Here is your sorted files");
                        }
                        break;
                    default:
                        Console.WriteLine("choose something");
                        break;
                }
            } while (choose != 0);
        }
    }
}
