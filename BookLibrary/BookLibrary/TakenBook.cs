using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class TakenBook : Book
    {
        public DateTime ReturnDate { get; set; }
        public Reader Reader { get; set; }
        public TakenBook(Book book, DateTime takenTo, Reader reader) :
            base(book.Name, book.Author, book.Category, book.Language, book.PublicationDate, book.ISBN)
        {
            ReturnDate = takenTo;
            Reader = reader;
        }
    }
}
