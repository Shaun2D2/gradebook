using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        public delegate string WriteLogDelegate(string logMessage);

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;

            log = ReturnMessage;

            var result = log("Hello!");

            Assert.Equal("Hello!", result); 
        }
        
        string ReturnMessage(string message)
        {
            return message;
        }

        [Fact]
        public void ValueTypesAlsoPassedByValue()
        {
            var x = GetInt();

            SetInt(ref x);

            Assert.Equal(4, x);
        }

        private void SetInt(ref  int x)
        {
            x = 4;
        }

        [Fact]
        public void StringBehaveLikeValueTypes() 
        {
            string name = "Scott";

            var upper = MakeUppercase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUppercase(string param)
        {
            return param.ToUpper();
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpIsPassedByRef()
        {
            var book1 = GetBook("Book1");
            GetBookSetName(ref book1, "NewName");

            Assert.Equal("NewName", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }


        [Fact]
        public void CSharpIsPassedByValue()
        {
            var book1 = GetBook("Book1");
            GetBookSetName(book1, "NewName");

            Assert.Equal("Book1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameByReference()
        {
            var book1 = GetBook("Book1");
            SetName(book1, "NewName");

            Assert.Equal("NewName", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("Book1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
