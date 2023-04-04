using System;
using System.Collections.Generic;


namespace _05_book_storage
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            const string CommandAddBook = "1";
            const string CommandRemoveBook = "2";
            const string CommandShowBooks = "3";
            const string CommandSearchBooksByParameters = "4";
            const string CommandExitProgram = "5";

            bool isProgramWork = true;
            BookStorage bookStorage = new BookStorage();

            while (isProgramWork)
            {
                Console.Clear();
                Console.WriteLine($"{CommandAddBook}) Добавить книгу.\n{CommandRemoveBook}) Удалить книгу.\n{CommandShowBooks}) Вывод всех книг.\n{CommandSearchBooksByParameters}) Поиск Книг по параметрам.\n{CommandExitProgram}) Выход");
                Console.Write("Выбирите команду: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddBook:
                        bookStorage.AddBook();
                        break;

                    case CommandRemoveBook:
                        bookStorage.RemoveBook();
                        break;

                    case CommandShowBooks:
                        bookStorage.ShowBooks();
                        break;

                    case CommandSearchBooksByParameters:
                        bookStorage.SearchBooksByParameters();
                        break;

                    case CommandExitProgram:
                        isProgramWork = false;
                        break;
                }
            }        
        }
    }

    class Book
    {
        private string _name;
        private string _author;
        private int _yearOfRelease;

        public Book(string name, string author, int yearOfRelease)
        {
            _name = name;
            _author = author;
            _yearOfRelease = yearOfRelease;
        }        

        public void SearchName(string userInput)
        {           
            if (userInput == _name)
            {
                Console.Write("Результат Поиска: ");
                Show();
                Console.ReadKey();
            }            
        }

        public void SearchAuthor(string userInput)
        {
            if (userInput == _author)
            {
                Console.Write("Результат Поиска: ");
                Show();
                Console.ReadKey();
            }            
        }

        public void SearchYearOfRelease(int userInput)
        {           
            if (userInput == _yearOfRelease)
            {
                Console.Write("Результат Поиска: ");
                Show();
                Console.ReadKey();
            }            
        }

        public void Show()
        {
            Console.WriteLine($"{_name} - {_author} - {_yearOfRelease}");
        }
    }

    class BookStorage
    {
        private List<Book> Books = new List<Book>();

        public BookStorage() 
        {
            DefaultBooks();
        }
        
        public void AddBook()
        {
            Console.Clear();
            Console.Write($"Введите Название книги: ");
            string userInputName = Console.ReadLine();
            Console.Write($"Введите Автора книги: ");
            string userInputAutor = Console.ReadLine();
            Console.Write($"Введите год издания книги: ");
            int.TryParse(Console.ReadLine(), out int yearOfRelease);

            Books.Add(new Book(userInputName, userInputAutor, yearOfRelease));
            Console.WriteLine($"Книга {userInputName} - {userInputAutor} - {yearOfRelease} добавлена.");
            Console.ReadKey();
        }

        public void RemoveBook()
        {
            Console.Clear();
            VerifyAvailabilityBooks();
            Console.Write("Введите порядковый номер книги, которую хотите удалить: ");           
            int.TryParse(Console.ReadLine(), out int index);
            
            if (index <= Books.Count)
            {
                Books.RemoveAt(index - 1);
                Console.Write($"Книга Удалена");
            }
            else
            {
                Console.WriteLine($"Книга не найдена");                
            }

            Console.ReadKey();
        }

        public void SearchBooksByParameters()
        {
            const string CommandName = "1";
            const string CommandAutor = "2";
            const string CommandYearOfRelease = "3";

            VerifyAvailabilityBooks();          

            Console.Clear();
            Console.WriteLine($"Выберете параметр поиска: \n{CommandName} - Название Книги. \n{CommandAutor} - Автор \n{CommandYearOfRelease} - Год.");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandName:
                    SearchBooksByName();
                    break;

                case CommandAutor:
                    SearchBooksByAutor();
                    break;

                case CommandYearOfRelease:
                    SearchBooksYearOfReleaseBook();
                    break;
            }
        }

        public void ShowBooks()
        {
            VerifyAvailabilityBooks();
            Console.Clear();
            Console.WriteLine("Список Книг:");
            for (int i = 0; i < Books.Count; i++)
            {
                foreach (Book book in Books)
                {
                    i++;
                    Console.Write($"{i})");
                    book.Show();
                }
            }

            Console.ReadKey();
        }

        private void DefaultBooks()
        {
            Books.Add(new Book("Дорога", "Маккарти", 2006));
            Books.Add(new Book("Поправки", "Франзен", 2001));
            Books.Add(new Book("Искупление", "Макьюэн", 2001));
            Books.Add(new Book("Белые зубы", "Смит", 2000));
            Books.Add(new Book("За чертой", "Маккарти", 1994));
        }

        private void SearchBooksByName()        
        {
            Console.Write("Введите название книги:");
            string userInput = Console.ReadLine();

            foreach (Book books in Books)
            {
                books.SearchName(userInput);
            }
        }

        private void SearchBooksByAutor()
        {
            Console.Write("Введите Автора книги:");
            string userInput = Console.ReadLine();

            foreach (Book book in Books)
            {
                book.SearchAuthor(userInput);
            }
        }

        private void SearchBooksYearOfReleaseBook()
        {
            Console.Write("Введите Год издания книги:");
            int.TryParse(Console.ReadLine(), out int userInput);

            foreach (Book book in Books)
            {
                book.SearchYearOfRelease(userInput);
                Console.ReadKey();
            }
        }        

        private void VerifyAvailabilityBooks()
        {
            if (Books.Count > 0) { }
            else
            {
                Console.WriteLine("Книг в хранилище нет.");
                Console.ReadKey();
            }
        }
    }
}
