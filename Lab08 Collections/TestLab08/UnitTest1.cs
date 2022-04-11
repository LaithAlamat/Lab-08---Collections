using static CollectionsApp.Program;
using System;
using Xunit;

namespace TestCollections
{
    public class UnitTest1
    {
        [Fact]
        public void AddBook()
        {
            Library library = new Library();

            library.Add("test1", "test1", "test1", 120);

            Assert.Equal(1, library.Count);

        }

        [Fact]
        public void BorrowBook()
        {
            Library library = new Library();
            library.Add("test1", "test1", "test1", 120);
            library.Add("test2", "test2", "test2", 120);

            library.Borrow("test2");

            Assert.Equal(1, library.Count);

        }

        [Fact]
        public void BorrowMissingBook()
        {
            Library library = new Library();
            library.Add("test1", "test1", "test1", 120);
            library.Add("test2", "test2", "test2", 120);


            Assert.Null(library.Borrow("test3"));

        }

        [Fact]
        public void PackTest()
        {

            Backpack<string> names = new Backpack<string>();

            string name = "bash";
            names.Pack(name);

            Assert.Contains(name, names);

        }

        [Fact]
        public void UnpackTest()
        {

            Backpack<string> names = new Backpack<string>();

            string name = "bash";
            string name1 = "Laith";

            names.Pack(name);
            names.Pack(name1);
            names.Unpack(0);

            Assert.DoesNotContain(name, names);

        }

        [Fact]
        public void ReturnBook()
        {

            Library library = new Library();
            library.Add("test1", "test1", "test1", 120);
            library.Add("test2", "test2", "test2", 120);
            Book book = library.Borrow("test1");
            library.Return(book);

            Assert.Contains(book, library);

        }
    }
}