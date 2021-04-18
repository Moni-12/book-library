using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using BookLibrary;
using System.Collections.Generic;
using System;

namespace UnitTest
{
    [TestClass]
    public class BookRegisterTest
    {
        [TestMethod]
        public void BookRegister_CreatedBookRegister_BookRegisterCountShouldBeNull()
        {
            BookRegister register = new BookRegister();
            int expected = 0;
            int actual = register.Count();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Count_GetCount_CountShouldBeEqualToAddedBookCount()
        {
            BookRegister register = new BookRegister();
            register.Add(new Book("name", "author", "category", "language", "1999", "123"));
            register.Add(new Book("n", "a", "c", "l", "1999", "789"));
            register.Count().Should().Be(2);
        }
        [TestMethod]
        public void Add_AddBookToRegister_AddedBookShouldBeEqualToGiven()
        {
            Book expected = new Book("name", "author", "category", "language", "1999", "123");
            BookRegister register = new BookRegister();
            register.Add(expected);
            Book actual = register.Get(0);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Get_IndexLessThanZero_ReturnNull()
        {
            BookRegister register = new BookRegister();
            register.Add(new Book("name", "author", "category", "language", "1999", "123"));
            register.Get(-1).Should().Be(null);
        }
        [TestMethod]
        public void Get_IndexMoreOrEqualCount_ReturnNull()
        {
            BookRegister register = new BookRegister();
            register.Add(new Book("name", "author", "category", "language", "1999", "123"));
            register.Get(1).Should().Be(null);
        }
        [TestMethod]
        public void Get_IndexMoreOrEqualZeroAndLessThanCount_ExpectedIsEqualActual()
        {
            BookRegister register = new BookRegister();
            Book expected = new Book("name", "author", "category", "language", "1999", "123");
            register.Add(expected);
            Book actual = register.Get(0);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Get_IndexIsZeroAndEmptyRegister_ReturnNull()
        {
            BookRegister register = new BookRegister();
            register.Get(0).Should().Be(null);
        }
        [TestMethod]
        public void Get_RegisterDoesNotContainBookWithCertainIsbn_ReturnNull()
        {
            BookRegister register = new BookRegister();
            register.Add(new Book("name", "author", "category", "language", "1999", "123"));
            register.Get("1").Should().Be(null);
        }
        [TestMethod]
        public void Get_IsbnAndEmptyRegister_ReturnNull()
        {
            BookRegister register = new BookRegister();
            register.Get("123").Should().Be(null);
        }
        [TestMethod]
        public void Get_RegisterContainsBookWithCertainIsbn_ExpectedIsEqualActual()
        {
            BookRegister register = new BookRegister();
            Book expected = new Book("name", "author", "category", "language", "1999", "123");
            register.Add(expected);
            Book actual = register.Get("123");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Contains_RegisterContainsBookWithCertainIsbn_True()
        {
            BookRegister register = new BookRegister();
            register.Add(new Book("name", "author", "category", "language", "1999", "123"));
            bool actual = register.Contains("123");
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void Contains_RegisterDoesNotContainBookWithCertainIsbn_False()
        {
            BookRegister register = new BookRegister();
            register.Add(new Book("name", "author", "category", "language", "1999", "123"));
            bool actual = register.Contains("1");
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Contains_EmptyRegister_False()
        {
            BookRegister register = new BookRegister();
            bool actual = register.Contains("1");
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Remove_GivenBookIsEqualToOneInRegister_RemovesGivenBookFromRegister()
        {
            BookRegister register = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            Book expected = new Book("n", "a", "c", "l", "1999", "789");
            register.Add(book1);
            register.Add(expected);
            register.Remove(book1);
            Book actual = register.Get(0);
            register.Count().Should().Be(1);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Remove_GivenBookIsbnEqualToOneInRegister_RemovesThatBookFromRegister()
        {
            BookRegister register = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            Book remove = new Book("n", "a", "c", "l", "1999", "123");
            register.Add(book1);
            register.Remove(remove);
            register.Count().Should().Be(0);
        }
        [TestMethod]
        public void Remove_GivenBookIsbnNotEqualToOneInRegister_DoesNotRemove()
        {
            BookRegister register = new BookRegister();
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            Book remove = new Book("n", "a", "c", "l", "1999", "1");
            register.Add(book);
            register.Remove(remove);
            register.Count().Should().Be(1);
        }
        [TestMethod]
        public void CopyToList_CopiesRegisterToList_BooksFromListAreEqualToBooksFromRegister()
        {
            BookRegister register = new BookRegister();
            Book expected1 = new Book("name", "author", "category", "language", "1999", "123");
            Book expected2 = new Book("n", "a", "c", "l", "1999", "789");
            register.Add(expected1);
            register.Add(expected2);
            List<Book> copy = register.CopyToList();
            Book actual1 = copy[0];
            Book actual2 = copy[1];
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }
        [TestMethod]
        public void CopyToList_CopiesEmptyRegister_ReturnsEmptyList()
        {
            BookRegister register = new BookRegister();
            List<Book> copy = register.CopyToList();
            copy.Count.Should().Be(0);
        }
        [TestMethod]
        public void FilterBooks_FilterByAuthor_ActualShoulBeEqualExpected()
        {
            BookRegister register = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            Book expected = new Book("n", "a", "c", "l", "1999", "789");
            register.Add(book1);
            register.Add(expected);
            TakenBookRegister takenBooks = new TakenBookRegister();
            BookRegister filtered = register.FilterBooks("a", "", "", "", "", "", takenBooks);
            Book actual = filtered.Get("789");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FilterBooks_FilterByCategory_ActualShoulBeEqualExpected()
        {
            BookRegister register = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            Book expected = new Book("n", "a", "c", "l", "1999", "789");
            register.Add(book1);
            register.Add(expected);
            TakenBookRegister takenBooks = new TakenBookRegister();
            BookRegister filtered = register.FilterBooks("", "c", "", "", "", "", takenBooks);
            Book actual = filtered.Get("789");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FilterBooks_FilterByOnlyByLanguage_ActualShoulBeEqualExpected()
        {
            BookRegister register = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            Book expected = new Book("n", "a", "c", "l", "1999", "789");
            register.Add(book1);
            register.Add(expected);
            TakenBookRegister takenBooks = new TakenBookRegister();
            BookRegister filtered = register.FilterBooks("", "", "l", "", "", "", takenBooks);
            Book actual = filtered.Get("789");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FilterBooks_FilterByOnlyByIsbn_ActualShoulBeEqualExpected()
        {
            BookRegister register = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            Book expected = new Book("n", "a", "c", "l", "1999", "789");
            register.Add(book1);
            register.Add(expected);
            TakenBookRegister takenBooks = new TakenBookRegister();
            BookRegister filtered = register.FilterBooks("", "", "", "789", "", "", takenBooks);
            Book actual = filtered.Get("789");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FilterBooks_FilterByOnlyByName_ActualShoulBeEqualExpected()
        {
            BookRegister register = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            Book expected = new Book("n", "a", "c", "l", "1999", "789");
            register.Add(book1);
            register.Add(expected);
            TakenBookRegister takenBooks = new TakenBookRegister();
            BookRegister filtered = register.FilterBooks("", "", "", "", "n", "", takenBooks);
            Book actual = filtered.Get("789");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FilterBooks_FilterByOnlyByAvailabiltyAvailable_ActualShoulBeEqualExpected()
        {
            ReaderRegister readerRegister = new ReaderRegister();
            BookRegister register = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            Book expected = new Book("n", "a", "c", "l", "1999", "789");
            register.Add(book1);
            register.Add(expected);
            TakenBookRegister takenBooks = new TakenBookRegister();
            bool successful;
            TaskUtils.TakeBook(register, takenBooks, readerRegister, "123", "reader", Convert.ToDateTime("2021-05-12"), out successful, 3);
            BookRegister filtered = register.FilterBooks("", "", "", "", "", "true", takenBooks);
            Book actual = filtered.Get("789");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FilterBooks_FilterByOnlyByAvailabiltyTaken_ActualShoulBeEqualExpected()
        {
            ReaderRegister readerRegister = new ReaderRegister();
            BookRegister register = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            Book expected = new Book("n", "a", "c", "l", "1999", "789");
            register.Add(book1);
            register.Add(expected);
            TakenBookRegister takenBooks = new TakenBookRegister();
            bool successful;
            TaskUtils.TakeBook(register, takenBooks, readerRegister, "789", "reader", Convert.ToDateTime("2021-05-12"), out successful, 3);
            BookRegister filtered = register.FilterBooks("", "", "", "", "", "false", takenBooks);
            Book actual = filtered.Get("789");
            Assert.AreEqual(expected, actual);
        }
    }
}
