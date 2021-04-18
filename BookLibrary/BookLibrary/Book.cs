using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string PublicationDate { get; set; }
        public string ISBN { get; set; }

        public Book(string name, string author, string category, string language, string publicationDate, string isbn)
        {
            Name = name;
            Author = author;
            Category = category;
            Language = language;
            PublicationDate = publicationDate;
            ISBN = isbn;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Book bookObject = obj as Book;
            if (bookObject == null)
            {
                return false;
            }
            return this.ISBN == bookObject.ISBN;
        }
        public override int GetHashCode()
        {
            return this.ISBN.GetHashCode();
        }
        public override string ToString()
        {
            return String.Format("| {0,-20} | {1,-20} | {2,-20} | {3,-10} | {4,-16} | {5,-20} |", this.Name, this.Author, this.Category, this.Language,
                this.PublicationDate, this.ISBN);
        }
    }
}
