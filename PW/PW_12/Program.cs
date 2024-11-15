using System;

namespace PW_12
{
    internal class Program
    {
        static void bookClass()
        {
            Library library = new Library();

            library.AddBook(new Book("Война и мир", "Л. Толстой"));
            library.AddBook(new Book("Евгений Онегин", "А. Пушкин"));
            library.AddBook(new Book("Мертвые души", "Н. Гоголь"));

            Console.WriteLine("\nВсе книги:");
            library.PrintAllBooks();

            Console.WriteLine("\nКнига по названию \"Евгений Онегин\":");
            Console.WriteLine(library.FindBookByTitle("Евгений Онегин"));

            Console.WriteLine("\nКниги автора \"Л. Толстой\":");
            foreach (var book in library.FindBooksByAuthor("Л. Толстой"))
            {
                Console.WriteLine(book);
            }

            library.RemoveBook(library.FindBookByTitle("Евгений Онегин"));

            Console.WriteLine("\nВсе книги после удаления книги \"Евгений Онегин\":");
            library.PrintAllBooks();
        }

        static void bookInterface()
        {
            LibraryInter libraryInter = new LibraryInter();

            libraryInter.AddBook(new BookInter("Война и мир", "Л. Толстой"));
            libraryInter.AddBook(new BookInter("Евгений Онегин", "А. Пушкин"));
            libraryInter.AddBook(new BookInter("Мертвые души", "Н. Гоголь"));
            libraryInter.AddBook(new BookInter("Преступление и наказание", "Ф. Достоевский"));
            libraryInter.AddBook(new BookInter("Мастер и Маргарита", "М. Булгаков"));
            libraryInter.AddBook(new BookInter("Идиот", "Ф. Достоевский"));
            libraryInter.AddBook(new BookInter("Обломов", "И. Гончаров"));
            libraryInter.AddBook(new BookInter("Братья Карамазовы", "Ф. Достоевский"));
            libraryInter.AddBook(new BookInter("Герой нашего времени", "М. Лермонтов"));
            libraryInter.AddBook(new BookInter("Анна Каренина", "Л. Толстой"));


            Console.WriteLine("\nВсе книги:");
            libraryInter.PrintAllBooks();

            Console.WriteLine("\nКнига по названию \"Евгений Онегин\":");
            Console.WriteLine(libraryInter.FindBookByTitle("Евгений Онегин"));

            Console.WriteLine("\nКниги автора \"Л. Толстой\":");
            foreach (var book in libraryInter.FindBooksByAuthor("Л. Толстой"))
            {
                Console.WriteLine(book);
            }

            IBook bookToRemove = libraryInter.FindBookByTitle("Война и мир");
            if (bookToRemove != null)
            {
                libraryInter.RemoveBook(bookToRemove);
            }

            Console.WriteLine("\nВсе книги после удаления: \"Война и мир\"");
            libraryInter.PrintAllBooks();
        }

        static void Main(string[] args)
        {
            int choice = -1;

            do
            {
                Console.WriteLine("Выберите вариант реализации:");
                Console.WriteLine("1. Использование классов");
                Console.WriteLine("2. Использование интерфейсов");
                Console.WriteLine("0. Выход");
                Console.Write("Ваш выбор: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            bookClass();
                            Console.WriteLine("\n");
                            break;
                        case 2:
                            bookInterface();
                            Console.WriteLine("\n");
                            break;
                        case 0:
                            Console.WriteLine("Выход из программы.");
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                            Console.WriteLine("\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
                    choice = -1;
                    Console.WriteLine("\n");
                }
            } 
            while (choice != 0);
           
        }
    }
}
