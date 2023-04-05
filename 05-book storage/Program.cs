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
            Storage bookStorage = new Storage();

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
        public string Name;
        public string Author;
        public int YearOfRelease;        

        public Book(string name, string author, int yearOfRelease)
        {
            Name = name;
            Author = author;
            YearOfRelease = yearOfRelease;            
        }         

        public void Show()
        {
            Console.WriteLine($"{Name} - {Author} - {YearOfRelease}");
        }
    }

    class Storage
    {
        private List<Book> _books = new List<Book>();

        public Storage() 
        {
            FillDefaultBooks();
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

            _books.Add(new Book(userInputName.ToLower(), userInputAutor.ToLower(), yearOfRelease));
            Console.WriteLine($"Книга {userInputName} - {userInputAutor} - {yearOfRelease} добавлена.");
            Console.ReadKey();
        }

        public void RemoveBook()
        {
            Console.Clear();
            VerifyAvailabilityBooks();
            Console.Write("Введите порядковый номер книги, которую хотите удалить: ");           
            int.TryParse(Console.ReadLine(), out int index);
            
            if (index <= _books.Count && index > 0)
            {
                _books.RemoveAt(index - 1);
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
                    SearchByName();
                    break;

                case CommandAutor:
                    SearchByAutor();
                    break;

                case CommandYearOfRelease:
                    SearchYearOfReleaseBook();
                    break;
            }
        }

        public void ShowBooks()
        {
            VerifyAvailabilityBooks();
            Console.Clear();
            Console.WriteLine("Список Книг:");

            for (int i = 0; i < _books.Count; i++)   //for нужен для вывода порядкового номера
            {
                foreach (Book book in _books)
                {
                    i++;
                    Console.Write($"{i})");
                    book.Show();
                }
            }

            Console.ReadKey();
        }

        private void FillDefaultBooks()
        {
            _books.Add(new Book("дорога", "маккарти", 2006));
            _books.Add(new Book("поправки", "франзен", 2001));
            _books.Add(new Book("искупление", "макьюэн", 2001));
            _books.Add(new Book("белые Зубы", "смит", 2000));
            _books.Add(new Book("за чертой", "маккарти", 1994));
        }

        private void SearchByName()        
        {
            Console.Write("Введите название книги:");
            string userInput = Console.ReadLine();            

            foreach (Book book in _books)
            {
                if (userInput.ToLower() == book.Name)
                {
                    Console.Write("Результат Поиска: ");
                    book.Show();                  
                }
            }

            Console.ReadKey();
        }

        private void SearchByAutor()
        {
            Console.Write("Введите Автора книги:");
            string userInput = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (userInput.ToLower() == book.Author)
                {
                    Console.Write("Результат Поиска: ");
                    book.Show();                    
                }
            }

            Console.ReadKey();
        }

        private void SearchYearOfReleaseBook()
        {
            Console.Write("Введите Год издания книги:");
            int.TryParse(Console.ReadLine(), out int userInput);

            foreach (Book book in _books)
            {
                if (userInput == book.YearOfRelease)
                {
                    Console.Write("Результат Поиска: ");
                    book.Show();                    
                }
            }

            Console.ReadKey();
        }        

        private void VerifyAvailabilityBooks()
        {
            if (_books.Count <= 0) 
            {
                Console.WriteLine("Книг в хранилище нет.");
                Console.ReadKey();
            }           
        }
    }
}
