using System;
using System.Collections.Generic;
using System.Linq;

namespace PW_12
{
    internal class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book) => books.Add(book);

        public void RemoveBook(Book book) => books.Remove(book);

        public Book FindBookByTitle(string title) => books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        public List<Book> FindBooksByAuthor(string author) => books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();

        public void PrintAllBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
