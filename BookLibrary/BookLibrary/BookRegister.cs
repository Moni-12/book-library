using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class BookRegister
    {
        private List<Book> allBooks = new List<Book>();
        public int Count()
        {
            return allBooks.Count;
        }
        public void Add(Book book)
        {
            this.allBooks.Add(book);
        }
        public Book Get(int index)
        {
            if (index >= 0 && index < allBooks.Count)
            {
                return this.allBooks[index];
            }
            return null;
        }
        public Book Get(string isbn)
        {
            foreach (Book book in allBooks)
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
        public void Remove(Book book)
        {
            allBooks.Remove(book);
        }
        public List<Book> CopyToList()
        {
            List<Book> copy = new List<Book>();
            foreach (Book book in this.allBooks)
            {
                copy.Add(book);
            }
            return copy;
        }
        public BookRegister FilterBooks(string author, string category, string language, string isbn, string name, string availability, TakenBookRegister takenBooks)
        {
            BookRegister filteredByAuthor;
            BookRegister filteredByCategory;
            BookRegister filteredByLanguage;
            BookRegister filteredByIsbn;
            BookRegister filteredByName;
            BookRegister filteredByAvailability;
            if (author != "") 
            {
                filteredByAuthor = this.FilterByAuthor(author);
            }
            else
            {
                filteredByAuthor = this;
            }
            if (category != "")
            {
                filteredByCategory = filteredByAuthor.FilterByCategory(category);
            }
            else
            {
                filteredByCategory = filteredByAuthor;
            }
            if (language != "")
            {
                filteredByLanguage = filteredByCategory.FilterByLanguage(language);
            }
            else
            {
                filteredByLanguage = filteredByCategory;
            }
            if (isbn != "")
            {
                filteredByIsbn = filteredByLanguage.FilterByISBN(isbn);
            }
            else
            {
                filteredByIsbn = filteredByLanguage;
            }
            if (name != "")
            {
                filteredByName = filteredByIsbn.FilterByName(name);
            }
            else
            {
                filteredByName = filteredByIsbn;
            }
            if (availability != "")
            {
                bool available;
                Boolean.TryParse(availability, out available);
                filteredByAvailability = filteredByName.FilterByAvailability(available, takenBooks);
            }
            else
            {
                filteredByAvailability = filteredByName;
            }
            return filteredByAvailability;
        }
        private BookRegister FilterByAuthor(string author)
        {
            BookRegister filtered = new BookRegister();
            foreach (Book book in this.allBooks)
            {
                if (book.Author.ToLower() == author.ToLower())
                {
                    filtered.Add(book);
                }
            }
            return filtered;
        }
        private BookRegister FilterByCategory(string category)
        {
            BookRegister filtered = new BookRegister();
            foreach (Book book in this.allBooks)
            {
                if (book.Category.ToLower() == category.ToLower())
                {
                    filtered.Add(book);
                }
            }
            return filtered;
        }
        private BookRegister FilterByLanguage(string language)
        {
            BookRegister filtered = new BookRegister();
            foreach (Book book in this.allBooks)
            {
                if (book.Language.ToLower() == language.ToLower())
                {
                    filtered.Add(book);
                }
            }
            return filtered;
        }
        private BookRegister FilterByISBN(string ISBN)
        {
            BookRegister filtered = new BookRegister();
            foreach (Book book in this.allBooks)
            {
                if (book.ISBN == ISBN)
                {
                    filtered.Add(book);
                }
            }
            return filtered;
        }
        private BookRegister FilterByName(string name)
        {
            BookRegister filtered = new BookRegister();
            foreach (Book book in this.allBooks)
            {
                if (book.Name.ToLower() == name.ToLower())
                {
                    filtered.Add(book);
                }
            }
            return filtered;
        }
        private BookRegister FilterByAvailability(bool available, TakenBookRegister takenBooks)
        {
            BookRegister filtered = new BookRegister();
            foreach (Book book in this.allBooks)
            {
                if (takenBooks.Contains(book.ISBN) != available)
                {
                    filtered.Add(book);
                }
            }
            return filtered;
        }
    }
}
