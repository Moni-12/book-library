using System;
using System.IO;


namespace BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            const string json = "BookData.json";
            const int maxBookCountForOneReader = 3;
            const int maxMonthCount = 2;
            BookRegister allBooks;
            if (File.Exists(json))
            {
                allBooks = InOutUtils.ReadBooksJson(json);
            }
            else
            {
                allBooks = new BookRegister();
            }
            TakenBookRegister takenBooks = new TakenBookRegister();
            ReaderRegister readers = new ReaderRegister();
            InOutUtils.PrintAllCommands();
            string command = Console.ReadLine();
            bool flag = true;
            while (flag)
            {
                switch (command.ToLower())
                {
                    case "/help":
                        InOutUtils.PrintAllCommands();
                        break;
                    case "/add":
                        Book book = InOutUtils.ReadBook();
                        allBooks.Add(book);
                        InOutUtils.PrintBooksJson(allBooks, json);
                        Console.WriteLine("Book added");
                        break;
                    case "/take":
                        Console.Write("Enter book's ISBN: ");
                        string takenIsbn = Console.ReadLine();
                        Console.Write("Enter readers name: ");
                        string readerName = Console.ReadLine();
                        Reader reader = new Reader(readerName);
                        Console.Write("Enter return date: ");
                        DateTime returnDate = Convert.ToDateTime(Console.ReadLine());
                        if (DateTime.Now.AddMonths(maxMonthCount) >= returnDate && returnDate >= DateTime.Now)
                        {
                            bool successfulOperation;
                            TaskUtils.TakeBook(allBooks, takenBooks, readers, takenIsbn, readerName, returnDate, out successfulOperation, maxBookCountForOneReader);
                            if (successfulOperation)
                            {
                                Console.WriteLine("Book taken");
                            }
                            else
                            {
                                Console.WriteLine("Book can not be taken");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Book can only be taken for maximum 2 month period and return date can not be in the past.");
                        }
                        break;
                    case "/return":
                        Console.Write("Enter ISBN of book: ");
                        string returnIsbn = Console.ReadLine();
                        if (takenBooks.Contains(returnIsbn))
                        {
                            bool lateReturnal;
                            TaskUtils.ReturnBook(takenBooks, readers, returnIsbn, out lateReturnal);
                            if (lateReturnal)
                            {
                                Console.WriteLine("Return your book rigth MEOW");
                            }
                            else
                            {
                                Console.WriteLine("Operation successful");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Book with this ISBN can not be returned");
                        }
                        break;
                    case "/list":
                        Console.WriteLine("Enter parameter to filter data. (If do not want to filter data by certain parameter, leave field empty.)");
                        Console.Write("Author: ");
                        string author = Console.ReadLine();
                        Console.Write("Category: ");
                        string category = Console.ReadLine();
                        Console.Write("Language: ");
                        string language = Console.ReadLine();
                        Console.Write("ISBN: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Available (true/false): ");
                        string availability = Console.ReadLine();
                        BookRegister filtered = allBooks.FilterBooks(author, category, language, isbn, name, availability, takenBooks);
                        if (filtered.Count() > 0)
                        {
                            InOutUtils.PrintBooks(filtered);
                        }
                        else
                        {
                            Console.WriteLine("Book not found");
                        }
                        break;
                    case "/delete":
                        Console.Write("Enter ISBN of book: ");
                        string deletedIsbn = Console.ReadLine();
                        if (allBooks.Contains(deletedIsbn))
                        {
                            TaskUtils.DeleteBook(takenBooks, allBooks, readers, deletedIsbn);
                            InOutUtils.PrintBooksJson(allBooks, json);
                            Console.WriteLine("Book deleted");
                        }
                        else
                        {
                            Console.WriteLine("Books with this ISBN can not be deleted");
                        }
                        break;
                    case "/exit":
                        flag = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
