using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    class Program
    {
        class Library {
            public static List<Book> Books { get; private set; }

            public Library(List<Book> books) {
                Books = books;
            }

            public void GiveBook(string Name)
            { 
                for (int i = 0; i < Books.Count; i++)
			    {
                    if (Books[i].Name == Name)
                    {
                        Books.RemoveAt(i);
                    }
			    }
            }
        }

        class Book {
            public string Name { get; set; }

            public Book(string name) {
                this.Name = name; 
            }
        }

        static void Main(string[] args)
        {
            int choose = 0;
            List<Book> books = new List<Book>();

            //init books
            for (int i = 0; i < 20; i++)
            {
                books.Add(new Book("Book number " + (i + 1)));
                //Console.WriteLine(books[i].Name);
            }

            //init library with books
            Library CityLibrary = new Library(books);

            Random r = new Random();
            do
            {
                Console.WriteLine("1-Take book from Library\n2-How many books left\n0-Leave Library");
                choose = Convert.ToInt32(Console.ReadLine());
                string chosenBookname = "Book number " + r.Next(0, 20).ToString();

                switch (choose)
                {
                    case 1:
                        Console.WriteLine("You took {0} from library", chosenBookname);
                        CityLibrary.GiveBook(chosenBookname);
                        break;
                    case 2:
                        Console.WriteLine(Library.Books.Count +" left in City Library.");
                        break;
                    case 0:
                        Console.WriteLine("Good day.");
                        break;
                    default:
                        break;
                }
            } while (choose != 0);
        }
    }
}
