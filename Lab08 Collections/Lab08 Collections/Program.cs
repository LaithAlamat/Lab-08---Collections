using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab08_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

    public class Book
        {
            public string Title { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public int NumberOfPages { get; set; }
            public Book(string Title, string FirstName, string LastName, int NumberOfPages)
            {
                this.Title = Title;
                this.FirstName = FirstName;
                this.LastName = LastName;
                this.NumberOfPages = NumberOfPages;
            }
        }

        public class Library : ILibrary
        {
            public int Count => throw new NotImplementedException();

           private Dictionary<string, Book> BorrowedBooks = new Dictionary<string, Book>();

            //public void Set(string key, Book)
            //{
            //    if (BorrowedBooks.ContainsKey(key))
            //    {
            //        BorrowedBooks[key] = Book;
            //    }
            //    else
            //    {
            //        BorrowedBooks.Add(key, value);
            //    }
            //}

            public Book Get(string key)
            {
                Book result = null;
                if (BorrowedBooks.ContainsKey(key))
                {
                    result = BorrowedBooks[key];
                }

                return result;
            }
            public void Add(string title, string firstName, string lastName, int numberOfPages)
            {
                Book book1 = new Book(title, firstName, lastName, numberOfPages);
                BorrowedBooks.Add(title, book1);
            }

            public Book Borrow(string title)
            {


                Book book2;
                BorrowedBooks.TryGetValue(title, out book2);
                if (BorrowedBooks.ContainsKey(title))
                {
                    //Bag.Add(title, book2);
                    BorrowedBooks.Remove(title);
                    return BorrowedBooks[title];
                 }
                else
                {
                    return null;
                }
            }

            public IEnumerator<Book> GetEnumerator() ///// to be done later (needs furthur explanation)
            {
                throw new NotImplementedException();
            }

            public void Return(Book book)
            {
                BorrowedBooks.Add(book.Title, book);
            }

            IEnumerator IEnumerable.GetEnumerator() ///// to be done later (needs furthur explanation)
            {
                throw new NotImplementedException();
            }
        }




        public interface ILibrary : IReadOnlyCollection<Book>
        {
            /// <summary>
            /// Add a Book to the library.
            /// </summary>
            void Add(string title, string firstName, string lastName, int numberOfPages);

            /// <summary>
            /// Remove a Book from the library with the given title.
            /// </summary>
            /// <returns>The Book, or null if not found.</returns>
            Book Borrow(string title);

            /// <summary>
            /// Return a Book to the library.
            /// </summary>
            void Return(Book book);
        }

        public class Backpack<T> : IBag<T>
        {
            public Dictionary<string, Book> Bag = new Dictionary<string, Book>();

            public IEnumerator<T> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public void Pack(T item)
            {
                //Bag.Add();
            }

            public T Unpack(int index)
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }


        public interface IBag<T> : IEnumerable<T>
        {
            /// <summary>
            /// Add an item to the bag. <c>null</c> items are ignored.
            /// </summary>
            void Pack(T item);

            /// <summary>
            /// Remove the item from the bag at the given index.
            /// </summary>
            /// <returns>The item that was removed.</returns>
            T Unpack(int index);
        }
    }
}
