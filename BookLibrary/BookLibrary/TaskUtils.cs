using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class TaskUtils
    {
        public static void TakeBook(BookRegister allBooks, TakenBookRegister takenBooks, ReaderRegister readers, string isbn, string readerName, DateTime returnDate, out bool successful,
            int maxBookCount)
        {
            successful = false;
            if (!takenBooks.Contains(isbn) && allBooks.Contains(isbn))
            {
                Book book = allBooks.Get(isbn);
                if (readers.Contains(readerName))
                {
                    Reader reader = readers.Get(readerName);
                    if (reader.BookCount < maxBookCount)
                    {
                        readers.AddBookCount(reader);
                        TakenBook takenBook = new TakenBook(book, returnDate, reader);
                        takenBooks.Add(takenBook);
                        successful = true;
                    }
                }
                else
                {
                    Reader reader = new Reader(readerName);
                    readers.Add(reader);
                    TakenBook takenBook = new TakenBook(book, returnDate, reader);
                    takenBooks.Add(takenBook);
                    successful = true;
                }
            }
        }
        public static void ReturnBook(TakenBookRegister takenBooks, ReaderRegister readers, string isbn, out bool lateReturn)
        {
            lateReturn = false;
            TakenBook book = takenBooks.Get(isbn);
            if (DateTime.Now > book.ReturnDate)
            {
                lateReturn = true;
            }
            readers.MinusBookCount(book.Reader);
            takenBooks.Remove(book);
        }
        public static void DeleteBook(TakenBookRegister takenBooks, BookRegister allBooks, ReaderRegister readers, string isbn)
        {
            Book bookToDelete = allBooks.Get(isbn);
            allBooks.Remove(bookToDelete);
            if (takenBooks.Contains(isbn))
            {
                bool lateReturnal;
                ReturnBook(takenBooks, readers, isbn, out lateReturnal);
            }
        } 
    }
}
