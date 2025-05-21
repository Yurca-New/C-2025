using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class MainLogic
    {
        private ConsoleInterface _consoleInterface;
        private List<Book> _books;
        public MainLogic()
        {
            _consoleInterface = new ConsoleInterface();
            _books = new List<Book>();
        }
        private void ShowListBook()
        {
            for (int i = 0; i < _books.Count; i++)
            {
                _consoleInterface.ShowMessage($"{i + 1}. {_books[i].GetType().Name} - Title: {_books[i].Title}, Author: {_books[i].Author}");
            }
        }
        private void ShowMenu()
        {
            _consoleInterface.ShowMessage("\nLibrary Management System");
            _consoleInterface.ShowMessage("1. View all books");
            _consoleInterface.ShowMessage("2. Add new book");
            _consoleInterface.ShowMessage("3. Remove book");
            _consoleInterface.ShowMessage("4. Change book type");
            _consoleInterface.ShowMessage("5. Exit");
        }
        private void ViewAllBooks()
        {
            if (_books.Count == 0)
            {
                _consoleInterface.ShowMessage("No books available.");
            }
            else
            {
                ShowListBook();
            }
        }
        private void AddNewBook()
        {
            string title = _consoleInterface.GetNonNullString("Enter book title:");
            string author = _consoleInterface.GetNonNullString("Enter book author:");
            string bookType = _consoleInterface.GetNonNullString("Enter book type (EBook/PrintedBook):");
            Book book;
            if (bookType.Equals("EBook", StringComparison.OrdinalIgnoreCase))
            {
                book = new EBook(title, author);
            }
            else if (bookType.Equals("PrintedBook", StringComparison.OrdinalIgnoreCase))
            {
                book = new PrintedBook(title, author);
            }
            else
            {
                _consoleInterface.ShowError("Invalid book type. Please enter either 'EBook' or 'PrintedBook'.");
                return;
            }
            _books.Add(book);
            _consoleInterface.ShowMessage($"Added {bookType} - Title: {title}, Author: {author}");
        }
        public void Run()
        {
            while (true)
            {
                ShowMenu();
                string choice = _consoleInterface.GetNonNullString("Select an option (1-5):");

                switch (choice)
                {
                    case "1":
                        ViewAllBooks();
                        break;

                    case "2":
                        AddNewBook();
                        break;

                    case "3":
                        if (_books.Count == 0)
                        {
                            _consoleInterface.ShowMessage("No books to remove.");
                            break;
                        }
                        ShowListBook();
                        string removeInput = _consoleInterface.GetNonNullString("Enter the number of the book to remove:");
                        if (int.TryParse(removeInput, out int removeIndex) && removeIndex >= 1 && removeIndex <= _books.Count)
                        {
                            var removedBook = _books[removeIndex - 1];
                            _books.RemoveAt(removeIndex - 1);
                            _consoleInterface.ShowMessage($"Removed book: {removedBook.Title}");
                        }
                        else
                        {
                            _consoleInterface.ShowError("Invalid selection.");
                        }
                        break;

                    case "4":
                        if (_books.Count == 0)
                        {
                            _consoleInterface.ShowMessage("No books to modify.");
                            break;
                        }
                        ShowListBook();
                        string changeInput = _consoleInterface.GetNonNullString("Enter the number of the book to change type:");
                        if (int.TryParse(changeInput, out int changeIndex) && changeIndex >= 1 && changeIndex <= _books.Count)
                        {
                            var selectedBook = _books[changeIndex - 1];
                            string newType = _consoleInterface.GetNonNullString("Enter new type (EBook/PrintedBook):");
                            if (newType.Equals("EBook", StringComparison.OrdinalIgnoreCase) && selectedBook is not EBook)
                            {
                                _books[changeIndex - 1] = new EBook(selectedBook.Title, selectedBook.Author);
                                _consoleInterface.ShowMessage("Book type changed to EBook.");
                            }
                            else if (newType.Equals("PrintedBook", StringComparison.OrdinalIgnoreCase) && selectedBook is not PrintedBook)
                            {
                                _books[changeIndex - 1] = new PrintedBook(selectedBook.Title, selectedBook.Author);
                                _consoleInterface.ShowMessage("Book type changed to PrintedBook.");
                            }
                            else
                            {
                                _consoleInterface.ShowError("Invalid type or book is already of this type.");
                            }
                        }
                        else
                        {
                            _consoleInterface.ShowError("Invalid selection.");
                        }
                        break;

                    case "5":
                        _consoleInterface.ShowMessage("Exiting...");
                        return;

                    default:
                        _consoleInterface.ShowError("Invalid option. Please select 1-5.");
                        break;
                }
            }
        }
    }
}
