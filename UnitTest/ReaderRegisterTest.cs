using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using BookLibrary;

namespace UnitTest
{
    [TestClass]
    public class ReaderRegisterTest
    {
        [TestMethod]
        public void ReaderRegister_CreatedReaderRegister_ReaderRegisterCountShouldBeNull()
        {
            ReaderRegister register = new ReaderRegister();
            int expected = 0;
            int actual = register.Count();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Count_GetCount_CountShouldBeEqualToAddedReaderCount()
        {
            ReaderRegister register = new ReaderRegister();
            register.Add(new Reader("name"));
            register.Add(new Reader("n"));
            register.Count().Should().Be(2);
        }
        [TestMethod]
        public void Add_AddReaderToRegister_AddedReaderShouldBeEqualToGiven()
        {
            Reader expected = new Reader("name");
            ReaderRegister register = new ReaderRegister();
            register.Add(expected);
            Reader actual = register.Get(0);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Get_IndexLessThanZero_ReturnNull()
        {
            ReaderRegister register = new ReaderRegister();
            register.Add(new Reader("name"));
            register.Get(-1).Should().Be(null);
        }
        [TestMethod]
        public void Get_IndexMoreOrEqualCount_ReturnNull()
        {
            ReaderRegister register = new ReaderRegister();
            register.Add(new Reader("name"));
            register.Get(1).Should().Be(null);
        }
        [TestMethod]
        public void Get_IndexMoreOrEqualZeroAndLessThanCount_ExpectedIsEqualActual()
        {
            ReaderRegister register = new ReaderRegister();
            Reader expected = new Reader("name");
            register.Add(expected);
            Reader actual = register.Get(0);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Get_IndexIsZeroAndEmptyRegister_ReturnNull()
        {
            ReaderRegister register = new ReaderRegister();
            register.Get(0).Should().Be(null);
        }
        [TestMethod]
        public void Get_RegisterDoesNotContainReaderWithCertainName_ReturnNull()
        {
            ReaderRegister register = new ReaderRegister();
            register.Add(new Reader("name"));
            register.Get("n").Should().Be(null);
        }
        [TestMethod]
        public void Get_NameAndEmptyRegister_ReturnNull()
        {
            ReaderRegister register = new ReaderRegister();
            register.Get("name").Should().Be(null);
        }
        [TestMethod]
        public void Get_RegisterContainsReaderWithCertainIsbn_ExpectedIsEqualActual()
        {
            ReaderRegister register = new ReaderRegister();
            Reader expected = new Reader("name");
            register.Add(expected);
            Reader actual = register.Get("name");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Contains_RegisterContainsReaderWithCertainName_True()
        {
            ReaderRegister register = new ReaderRegister();
            register.Add(new Reader("name"));
            bool actual = register.Contains("name");
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void Contains_RegisterDoesNotContainReaderWithCertainName_False()
        {
            ReaderRegister register = new ReaderRegister();
            register.Add(new Reader("name"));
            bool actual = register.Contains("n");
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Contains_EmptyRegister_False()
        {
            ReaderRegister register = new ReaderRegister();
            bool actual = register.Contains("name");
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void AddBookCount_AddOneToReadersBookCount_ReaderBookCountShouldBeTwo()
        {
            ReaderRegister register = new ReaderRegister();
            Reader reader = new Reader("name");
            register.Add(reader);
            register.AddBookCount(reader);
            reader.BookCount.Should().Be(2);
        }
        [TestMethod]
        public void MinusBookCount_MinusOneReadersBookCount_ReaderBookCountShoulBeZero()
        {
            ReaderRegister register = new ReaderRegister();
            Reader reader = new Reader("name");
            register.Add(reader);
            register.MinusBookCount(reader);
            reader.BookCount.Should().Be(0);
        }
    }
}
