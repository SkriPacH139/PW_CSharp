using System;
using System.Collections.Generic;
using System.Linq;

namespace PW_12
{
    internal class LibraryInter
    {
        private List<IBook> books = new List<IBook>();

        public void AddBook(IBook book) => books.Add(book);

        public void RemoveBook(IBook book) => books.Remove(book);

        public IBook FindBookByTitle(string title) => books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        public List<IBook> FindBooksByAuthor(string author) => books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();

        public void PrintAllBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
