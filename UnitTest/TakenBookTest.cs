using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLibrary;
using System;

namespace UnitTest
{
    [TestClass]
    public class TakenBookTest
    {
        [TestMethod]
        public void TakenBook_CreatedTakenBook_BookValuesShouldBeEqualToGiven()
        {
            string expectedName = "name";
            string expectedAuthor = "author";
            string expectedCategory = "category";
            string expectedLanguage = "language";
            string ecpectedPublicationDate = "1999";
            string expectedIsbn = "isbn";
            Book book = new Book(expectedName, expectedAuthor, expectedCategory, expectedLanguage, ecpectedPublicationDate, expectedIsbn);
            string expectedReaderName = "name reader";
            int expectedReaderBookCount = 1;
            Reader reader = new Reader(expectedReaderName);
            DateTime expectetReturnDate = Convert.ToDateTime("2021-05-16");
            TakenBook takenBook = new TakenBook(book, expectetReturnDate, reader);

            string actualName = takenBook.Name;
            string actualAuthor = takenBook.Author;
            string actualCategory = takenBook.Category;
            string actualLanguage = takenBook.Language;
            string actualPublicationDate = takenBook.PublicationDate;
            string actualIsbn = takenBook.ISBN;
            DateTime actualReturnDate = takenBook.ReturnDate;
            string actualReaderName = takenBook.Reader.Name;
            int actualReaderBookCount = takenBook.Reader.BookCount;
            
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedAuthor, actualAuthor);
            Assert.AreEqual(expectedCategory, actualCategory);
            Assert.AreEqual(expectedLanguage, actualLanguage);
            Assert.AreEqual(ecpectedPublicationDate, actualPublicationDate);
            Assert.AreEqual(expectedIsbn, actualIsbn);
            Assert.AreEqual(expectetReturnDate, actualReturnDate);
            Assert.AreEqual(expectedReaderName, actualReaderName);
            Assert.AreEqual(expectedReaderBookCount, actualReaderBookCount);
        }
    }
}
