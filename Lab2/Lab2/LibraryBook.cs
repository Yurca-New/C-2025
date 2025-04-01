using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class LibraryBook
    {
        private readonly UserInterface _userInterface = new UserInterface();
        
        private readonly string title;
        private readonly string author;
        private bool isAvailable;

        public string Title => title;
        public string Author => author;
        public bool IsAvailable => isAvailable;

        public LibraryBook(string title, string author)
        {
            this.title = _userInterface.TestNullString(title, "The title of the book cannot be empty");
            this.author = _userInterface.TestNullString(author, "The author of the book cannot be empty");
            this.isAvailable = true;
        }
        public void BorrowBook()
        {
            if (this.isAvailable)
                this.isAvailable = false;
            else
                _userInterface.ShowMessage("The book is not available");
        }
        public void ReturnBook() =>
            this.isAvailable = true;

        public string GetInfo()
        {
            return $"Title: {this.title}, Author: {this.author}, Available: {this.isAvailable}";
        }
    }
}
