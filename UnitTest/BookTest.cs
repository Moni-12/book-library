using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLibrary;
using System;

namespace UnitTest
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        public void Book_CreatedBook_BookValuesShouldBeEqualToGiven()
        {
            string expectedName = "name";
            string expectedAuthor = "author";
            string expectedCategory = "category";
            string expectedLanguage = "language";
            string ecpectedDate = "1999";
            string expectedIsbn = "isbn";
            Book book = new Book(expectedName, expectedAuthor, expectedCategory, expectedLanguage, ecpectedDate, expectedIsbn);
            string actualName = book.Name;
            string actualAuthor = book.Author;
            string actualCategory = book.Category;
            string actualLanguage = book.Language;
            string actualDate = book.PublicationDate;
            string actualIsbn = book.ISBN;
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedAuthor, actualAuthor);
            Assert.AreEqual(expectedCategory, actualCategory);
            Assert.AreEqual(expectedLanguage, actualLanguage);
            Assert.AreEqual(ecpectedDate, actualDate);
            Assert.AreEqual(expectedIsbn, actualIsbn);
        }
        [TestMethod]
        public void Equal_ObjectIsNull_False()
        {
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            object obj = null;
            bool actual = book.Equals(obj);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Equal_ObjectIsNotBook_False()
        {
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            Reader obj = new Reader("Name");
            bool actual = book.Equals(obj);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Equal_ObjectIsBookWithDifferentIsbn_False()
        {
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            Book obj = new Book("n", "a", "c", "l", "1999", "789");
            bool actual = book.Equals(obj);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Equal_ObjectIsBookWithSametIsbn_True()
        {
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            Book obj = new Book("n", "a", "c", "l", "1999", "123");
            bool actual = book.Equals(obj);
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void ToString_ConvertsToString_AreEqualWithExpectedString()
        {
            string expected = String.Format("| {0,-20} | {1,-20} | {2,-20} | {3,-10} | {4,-16} | {5,-20} |",
                "name", "author", "category", "language", "1999", "123");
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            string actual = book.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
