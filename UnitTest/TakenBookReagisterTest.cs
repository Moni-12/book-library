using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using BookLibrary;
using System;

namespace UnitTest
{
    [TestClass]
    public class TakenBookReagisterTest
    {
        [TestMethod]
        public void TakenBookRegister_CreatedTakenBookRegister_TakenBookRegisterCountShouldBeNull()
        {
            TakenBookRegister register = new TakenBookRegister();
            int expected = 0;
            int actual = register.Count();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Count_GetCount_CountShouldBeEqualToAddedBookCount()
        {
            TakenBookRegister register = new TakenBookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            Book book2 = new Book("n", "a", "c", "l", "1999", "789");
            Reader reader1 = new Reader("Name");
            Reader reader2 = new Reader("N");
            register.Add(new TakenBook(book1, Convert.ToDateTime("2021-05-12"), reader1));
            register.Add(new TakenBook(book2, Convert.ToDateTime("2021-05-12"), reader2));
            register.Count().Should().Be(2);
        }
        [TestMethod]
        public void Add_AddBookToRegister_AddedBookShouldBeEqualToGiven()
        {
            TakenBookRegister register = new TakenBookRegister();
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            Reader reader = new Reader("Name");
            TakenBook expected = new TakenBook(book, Convert.ToDateTime("2021-05-12"), reader);
            register.Add(expected);
            TakenBook actual = register.Get(0);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Get_IndexLessThanZero_ReturnNull()
        {
            TakenBookRegister register = new TakenBookRegister();
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            Reader reader = new Reader("Name");
            register.Add(new TakenBook(book, Convert.ToDateTime("2021-05-12"), reader));
            register.Get(-1).Should().Be(null);
        }
        [TestMethod]
        public void Get_IndexMoreOrEqualCount_ReturnNull()
        {
            TakenBookRegister register = new TakenBookRegister();
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            Reader reader = new Reader("Name");
            register.Add(new TakenBook(book, Convert.ToDateTime("2021-05-12"), reader));
            register.Get(1).Should().Be(null);
        }
        [TestMethod]
        public void Get_IndexMoreOrEqualZeroAndLessThanCount_ExpectedIsEqualActual()
        {
            TakenBookRegister register = new TakenBookRegister();
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            Reader reader = new Reader("Name");
            TakenBook expected = new TakenBook(book, Convert.ToDateTime("2021-05-12"), reader);
            register.Add(expected);
            TakenBook actual = register.Get(0);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Get_IndexIsZeroAndEmptyRegister_ReturnNull()
        {
            TakenBookRegister register = new TakenBookRegister();
            register.Get(0).Should().Be(null);
        }
        [TestMethod]
        public void Get_RegisterDoesNotContainBookWithCertainIsbn_ReturnNull()
        {
            TakenBookRegister register = new TakenBookRegister();
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            Reader reader = new Reader("Name");
            register.Add(new TakenBook(book, Convert.ToDateTime("2021-05-12"), reader));
            register.Get("1").Should().Be(null);
        }
        [TestMethod]
        public void Get_IsbnAndEmptyRegister_ReturnNull()
        {
            TakenBookRegister register = new TakenBookRegister();
            register.Get("123").Should().Be(null);
        }
        [TestMethod]
        public void Get_RegisterContainsBookWithCertainIsbn_ExpectedIsEqualActual()
        {
            TakenBookRegister register = new TakenBookRegister();
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            Reader reader = new Reader("Name");
            TakenBook expected = new TakenBook(book, Convert.ToDateTime("2021-05-12"), reader);
            register.Add(expected);
            TakenBook actual = register.Get("123");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Contains_RegisterContainsBookWithCertainIsbn_True()
        {
            TakenBookRegister register = new TakenBookRegister();
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            Reader reader = new Reader("Name");
            register.Add(new TakenBook(book, Convert.ToDateTime("2021-05-12"), reader));
            bool actual = register.Contains("123");
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void Contains_RegisterDoesNotContainBookWithCertainIsbn_False()
        {
            TakenBookRegister register = new TakenBookRegister();
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            Reader reader = new Reader("Name");
            register.Add(new TakenBook(book, Convert.ToDateTime("2021-05-12"), reader));
            bool actual = register.Contains("1");
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Contains_EmptyRegister_False()
        {
            TakenBookRegister register = new TakenBookRegister();
            bool actual = register.Contains("1");
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Remove_GivenBookIsbnEqualToOneInRegister_RemovesThatBookFromRegister()
        {
            BookRegister register = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            Book book2 = new Book("n", "a", "c", "l", "1999", "123");
            Reader reader1 = new Reader("Name");
            Reader reader2 = new Reader("N");
            TakenBook takenBook = new TakenBook(book1, Convert.ToDateTime("2021-05-12"), reader1);
            TakenBook bookToRemove = new TakenBook(book2, Convert.ToDateTime("2021-05-12"), reader2);
            register.Add(takenBook);
            register.Remove(bookToRemove);
            register.Count().Should().Be(0);
        }
        [TestMethod]
        public void Remove_GivenBookIsbnNotEqualToOneInRegister_DoesNotRemove()
        {
            BookRegister register = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            Book book2 = new Book("n", "a", "c", "l", "1999", "789");
            Reader reader1 = new Reader("Name");
            Reader reader2 = new Reader("N");
            TakenBook takenBook = new TakenBook(book1, Convert.ToDateTime("2021-05-12"), reader1);
            TakenBook bookToRemove = new TakenBook(book2, Convert.ToDateTime("2021-05-12"), reader2);
            register.Add(takenBook);
            register.Remove(bookToRemove);
            register.Count().Should().Be(1);
        }
    }
}
