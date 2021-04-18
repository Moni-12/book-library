using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using BookLibrary;
using System;

namespace UnitTest
{
    [TestClass]
    public class TaskUtilsTest
    {
        [TestMethod]
        public void TakeBook_TakenBookRegisterContainsBookWithCertainIsbn_SuccessfullFalse()
        {
            BookRegister libraryRegister = new BookRegister();
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            libraryRegister.Add(book);
            ReaderRegister readerRegister = new ReaderRegister();
            Reader reader = new Reader("Name");
            readerRegister.Add(reader);
            TakenBookRegister takenRegister = new TakenBookRegister();
            takenRegister.Add(new TakenBook(book, Convert.ToDateTime("2021-05-12"), reader));
            bool successful;
            TaskUtils.TakeBook(libraryRegister, takenRegister, readerRegister, "123", "John", Convert.ToDateTime("2021-05-16"), out successful, 3);
            Assert.IsFalse(successful);
        }
        [TestMethod]
        public void TakeBook_BookRegisterDoenNotContainBookWithCertainIsbn_SuccessfullFalse()
        {
            BookRegister libraryRegister = new BookRegister();
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            libraryRegister.Add(book);
            ReaderRegister readerRegister = new ReaderRegister();
            TakenBookRegister takenRegister = new TakenBookRegister();
            bool successful;
            TaskUtils.TakeBook(libraryRegister, takenRegister, readerRegister, "1", "John", Convert.ToDateTime("2021-05-16"), out successful, 3);
            Assert.IsFalse(successful);
        }
        [TestMethod]
        public void TakeBook_ReaderHasAlreadyTakenThreeBooks_SuccessfullFalse()
        {
            BookRegister libraryRegister = new BookRegister();
            Book book = new Book("name", "author", "category", "language", "1999", "123");
            libraryRegister.Add(book);
            ReaderRegister readerRegister = new ReaderRegister();
            Reader reader = new Reader("Name");
            readerRegister.Add(reader);
            readerRegister.AddBookCount(reader);
            readerRegister.AddBookCount(reader);
            TakenBookRegister takenRegister = new TakenBookRegister();
            bool successful;
            TaskUtils.TakeBook(libraryRegister, takenRegister, readerRegister, "123", "Name", Convert.ToDateTime("2021-05-16"), out successful, 3);
            Assert.IsFalse(successful);
        }
        [TestMethod]
        public void TakeBook_NewReaderTakesBook_SuccessfullTrueAddbookToTakenBookRegisterAndAddsNewReaderToReaderRegister()
        {
            BookRegister libraryRegister = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            libraryRegister.Add(book1);
            ReaderRegister readerRegister = new ReaderRegister();
            TakenBookRegister takenRegister = new TakenBookRegister();
            bool successful;
            TaskUtils.TakeBook(libraryRegister, takenRegister, readerRegister, "123", "Name", Convert.ToDateTime("2021-05-16"), out successful, 3);
            bool containsTakenRegister = takenRegister.Contains("123");
            bool containsReaderRegister = readerRegister.Contains("Name");
            Assert.IsTrue(successful);
            Assert.IsTrue(containsTakenRegister);
            Assert.IsTrue(containsReaderRegister);
        }
        [TestMethod]
        public void TakeBook_ReaderHasAlreadyTakenOneBook_SuccessfullTrueAddbookToTakenBookRegisterAndAddPlusOneToReaderBookCount()
        {
            BookRegister libraryRegister = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            Book book2 = new Book("n", "a", "c", "language", "1999", "123456");
            libraryRegister.Add(book1);
            libraryRegister.Add(book2);
            ReaderRegister readerRegister = new ReaderRegister();
            TakenBookRegister takenRegister = new TakenBookRegister();
            bool successful;
            TaskUtils.TakeBook(libraryRegister, takenRegister, readerRegister, "123", "Name", Convert.ToDateTime("2021-05-16"), out successful, 3);
            TaskUtils.TakeBook(libraryRegister, takenRegister, readerRegister, "123456", "Name", Convert.ToDateTime("2021-05-16"), out successful, 3);
            bool containsTakenRegister = takenRegister.Contains("123456");
            Assert.IsTrue(successful);
            Assert.IsTrue(containsTakenRegister);
            readerRegister.Get("Name").BookCount.Should().Be(2);
        }
        [TestMethod]
        public void ReturnBook_ReturnDateIsLate_LateReturnIsTrueAndReaderMinusBookCountAndRemoveBookFfromTakenBookRegister()
        {
            BookRegister libraryRegister = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            libraryRegister.Add(book1);
            ReaderRegister readerRegister = new ReaderRegister();
            TakenBookRegister takenRegister = new TakenBookRegister();
            bool successful;
            TaskUtils.TakeBook(libraryRegister, takenRegister, readerRegister, "123", "Name", Convert.ToDateTime("2020-04-16"), out successful, 3);
            bool lateReturn;
            TaskUtils.ReturnBook(takenRegister, readerRegister, "123", out lateReturn);
            readerRegister.Get("Name").BookCount.Should().Be(0);
            Assert.IsTrue(lateReturn);
            takenRegister.Get("123").Should().Be(null);
        }
        [TestMethod]
        public void ReturnBook_ReturnDateIsNotLate_LateReturnIsFalseAndReaderMinusBookCountAndRemoveBookFfromTakenBookRegister()
        {
            BookRegister libraryRegister = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            libraryRegister.Add(book1);
            ReaderRegister readerRegister = new ReaderRegister();
            TakenBookRegister takenRegister = new TakenBookRegister();
            bool successful;
            TaskUtils.TakeBook(libraryRegister, takenRegister, readerRegister, "123", "Name", Convert.ToDateTime("2022-05-16"), out successful, 3);
            bool lateReturn;
            TaskUtils.ReturnBook(takenRegister, readerRegister, "123", out lateReturn);
            readerRegister.Get("Name").BookCount.Should().Be(0);
            Assert.IsFalse(lateReturn);
            takenRegister.Get("123").Should().Be(null);
        }
        [TestMethod]
        public void DeleteBook_DeletesBookFromBookRegisterAndTakenBookREgister_BookRegisterAndTakenBookRegisterDoesNotContainBook()
        {
            BookRegister libraryRegister = new BookRegister();
            Book book1 = new Book("name", "author", "category", "language", "1999", "123");
            libraryRegister.Add(book1);
            ReaderRegister readerRegister = new ReaderRegister();
            TakenBookRegister takenRegister = new TakenBookRegister();
            bool successful;
            TaskUtils.TakeBook(libraryRegister, takenRegister, readerRegister, "123", "Name", Convert.ToDateTime("2022-05-16"), out successful, 3);
            TaskUtils.DeleteBook(takenRegister, libraryRegister, readerRegister, "123");
            bool containsBookRegister = takenRegister.Contains("123");
            bool containsTakenBookRegister = readerRegister.Contains("123");
            Assert.IsFalse(containsBookRegister);
            Assert.IsFalse(containsTakenBookRegister);
        }
    }
}
