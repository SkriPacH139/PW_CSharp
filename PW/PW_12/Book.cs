namespace PW_12
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public override string ToString() => $"Название: {Title}, Автор: {Author}";
    }
}
