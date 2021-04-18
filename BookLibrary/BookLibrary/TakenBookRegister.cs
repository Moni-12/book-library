using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class TakenBookRegister
    {
        private List<TakenBook> allBooks = new List<TakenBook>();
        public int Count()
        {
            return this.allBooks.Count();
        }
        public void Add(TakenBook book)
        {
            this.allBooks.Add(book);
        }
        public TakenBook Get(int index)
        {
            if (index >= 0 && index < allBooks.Count)
            {
                return this.allBooks[index];
            }
            return null;
        }
        public TakenBook Get(string isbn)
        {
            foreach (TakenBook book in allBooks)
            {
                if (book.ISBN == isbn)
                {
                    return book;
                }
            }
            return null;
        }
        public bool Contains(string isbn)
        {
            foreach (Book book in allBooks)
            {
                if (book.ISBN == isbn)
                {
                    return true;
                }
            }
            return false;
        }
        public void Remove(TakenBook book)
        {
            allBooks.Remove(book);
        }
    }
}
