using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        class Library
        {
            //Fist solution
            public static List<Book> ScienseBooks = new List<Book>();
            public static List<Book> LogicBooks = new List<Book>();
            public static List<Book> NatureBooks = new List<Book>();
            public string[] BooksTypes { set; get; }

            // Second solution with Dictionary test, Not used in main application
            public static IDictionary<string, List<Book>> bookTypes = new Dictionary<string, List<Book>>();

            public Library()
            {
                this.BooksTypes = new string[] { "science", "logic", "nature" };
            }

            //add books to dictionary - second method. test, Not used in main application
            public void addBookToDictionary(Book book)
            {
                // Add to exist category or create new
                if (bookTypes.ContainsKey(book.BookType))
                {
                    bookTypes[book.BookType].Add(book);
                }
                else
                {
                    bookTypes[book.BookType] = new List<Book>();
                    bookTypes[book.BookType].Add(book);
                }
            }

            // add new book to library
            public void addBook(Book book)
            {
                switch (book.BookType)
                {
                    case "science":
                        ScienseBooks.Add(book);
                        break;
                    case "logic" :
                        LogicBooks.Add(book);
                        break;
                    case "nature" : 
                        NatureBooks.Add(book);
                        break;
                    default:
                        break;
                }
            }
            
            //remove book from library
            public void removeBook(string type)
            {
                switch (type)
                {
                    case "science":
                        if (ScienseBooks.Count > 0)
                        {
                            ScienseBooks.RemoveAt(0);
                        }
                        else
                        {
                            this.ShowMessages("empty", type);
                            return;
                        }
                        break;
                    case "logic":
                        if (LogicBooks.Count > 0)
                        {
                            LogicBooks.RemoveAt(0);
                        }
                        else
                        {
                            this.ShowMessages("empty", type);
                            return;
                        }
                        break;
                    case "nature":
                        if (NatureBooks.Count > 0)
                        {
                            NatureBooks.RemoveAt(0);
                        }
                        else
                        {
                            this.ShowMessages("empty", type);
                            return;
                        }
                        break;
                    default:
                        break;
                }
                this.ShowMessages("thank", type);
            }
            
            //public messages
            public void ShowBooksAmout()
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("===============Books in Library Store===========\n\t\tSciense Books - {0}\n\t\tLogic Books - {2}\n\t\tNature Books - {1}", ScienseBooks.Count, NatureBooks.Count, LogicBooks.Count);
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            //private messages
            private void ShowMessages(string messageType, string bookType)
            {
                switch (messageType)
                {
                    case "thank":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("-------------------\nThank you, you get your {0} book\n-------------------", bookType);
                    Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "empty": 
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("-------------------\nSorry, we dont have {0} books, try another.\n-------------------", bookType);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        break;
                }
            }
        }

        class Book
        {
            public string BookType { set; get; }
            public string BookName { set; get; } 
        }


        static void Main(string[] args)
        {
            Library CityLibrary = new Library();
            int variant = 0;

            //set how many books of each Type will be stored inside our Library
            int totalBooksAmout = 10;

            //fill our Library
            for (int i = 0; i < CityLibrary.BooksTypes.Length; i++)
            {
                for (int j = 0; j < totalBooksAmout; j++)
                {
                    Book currentNewBook = new Book();
                    currentNewBook.BookName = "Book number " + (j+1).ToString();
                    currentNewBook.BookType = CityLibrary.BooksTypes[i];
                    
                    //first variant of storing elements
                    CityLibrary.addBook(currentNewBook);

                    //Second variant storing books in Dictionary , test, Not used in main application
                    CityLibrary.addBookToDictionary(currentNewBook);
                }   
            }
            Console.WriteLine("\n\t\t    Greetings.\n");
            CityLibrary.ShowBooksAmout();

            do
            {
                Console.WriteLine("========================\n1-Take Science book from Library\n2-Take Logic book from Library\n3-Take Nature book from Library\n===========================\n4-How many books left in Library\n======================\n0-Leave Library\n======================\n");
                try
                {
                    variant = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry, there are some validatoin errors, please try again.");
                }


                switch (variant)
                {
                    case 1 :
                        CityLibrary.removeBook("science");
                        break;
                    case 2 :
                        CityLibrary.removeBook("logic");
                        break;
                    case 3:
                        CityLibrary.removeBook("nature");
                        break;
                    case 4 :
                        CityLibrary.ShowBooksAmout();
                        break;
                    case 0 :
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please, choose numbers 0-4");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

            } while (variant !=0);

            Console.WriteLine("See you later, homie. \n press any key");
            Console.ReadLine();
        }
    }
}
