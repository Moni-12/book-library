using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BookLibrary
{
    class InOutUtils
    {
        public static BookRegister ReadBooksJson(string fileName)
        {
            BookRegister allBooks = new BookRegister();
            string jsonString = File.ReadAllText(fileName);
            var array = JArray.Parse(jsonString);

            foreach (var item in array)
            {
                allBooks.Add(item.ToObject<Book>());
            }
            return allBooks;
        }
        public static void PrintAllCommands()
        {
            Console.WriteLine("Command list:");
            Console.WriteLine("/help - shows all commands");
            Console.WriteLine("/add - adds book");
            Console.WriteLine("/take - reader takes books");
            Console.WriteLine("/return - reader returns book");
            Console.WriteLine("/list - formats list of books");
            Console.WriteLine("/delete - deletes book");
            Console.WriteLine("/exit - close program");
            Console.WriteLine();
        }
        public static Book ReadBook()
        {
            Console.WriteLine("Enter information about a book:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Author: ");
            string author = Console.ReadLine();
            Console.Write("Category: ");
            string category = Console.ReadLine();
            Console.Write("Language: ");
            string language = Console.ReadLine();
            Console.Write("Publication date: ");
            string publicationDate = Console.ReadLine();
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();
            return new Book(name, author, category, language, publicationDate, isbn);
        }
        public static void PrintBooks(BookRegister books)
        {
            string horizontalGridLine = new string('-', 125);
            Console.WriteLine(horizontalGridLine);
            Console.WriteLine(String.Format("| {0,-20} | {1,-20} | {2,-20} | {3,-10} | {4,-16} | {5,-20} |",
                "Name", "Author", "Category", "Language", "Publication Date", "ISBN"));
            Console.WriteLine(horizontalGridLine);
            for (int i = 0; i < books.Count(); i++)
            {
                Console.WriteLine(books.Get(i));
            }
            Console.WriteLine(horizontalGridLine);
        }
        public static void PrintBooksJson(BookRegister register, string fileName)
        {
            List<Book> books = register.CopyToList();
            var convertedJson = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(fileName, convertedJson);
        }
    }
}
