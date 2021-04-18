using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLibrary;
using System;

namespace UnitTest
{
    [TestClass]
    public class ReaderTest
    {
        [TestMethod]
        public void Reader_CreatedReader_ReaderValuesShouldBeEqualToGiven()
        {
            string expectedName = "name";
            int expectedBookCount = 1;
            Reader reader = new Reader(expectedName);
            string actualName = reader.Name;
            int actualBookCount = reader.BookCount;
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedBookCount, actualBookCount);
        }
        [TestMethod]
        public void Equal_ObjectIsNull_False()
        {
            Reader reader = new Reader("name");
            object obj = null;
            bool actual = reader.Equals(obj);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Equal_ObjectIsNotReader_False()
        {
            Reader reader = new Reader("name");
            Book obj = new Book("name", "author", "category", "language", "1999", "123");
            bool actual = reader.Equals(obj);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Equal_ObjectIsBookWithDifferentName_False()
        {
            Reader reader = new Reader("name");
            Reader obj = new Reader("n");
            bool actual = reader.Equals(obj);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Equal_ObjectIsBookWithSametIsbn_True()
        {
            Reader reader = new Reader("name");
            Reader obj = new Reader("name");
            bool actual = reader.Equals(obj);
            Assert.IsTrue(actual);
        }
    }
}
