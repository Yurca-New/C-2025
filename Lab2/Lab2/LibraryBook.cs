using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /// <summary>
    /// Represents a book in the library.
    /// </summary>
    internal class LibraryBook
    {
        
        private readonly string _title;
        private readonly string _author;
        private bool _isAvailable;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryBook"/> class.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The author of the book.</param>
        public LibraryBook(string title, string author)
        {
            _title = title;
            _author = author;
            _isAvailable = true;
        }

        /// <summary>
        /// Attempts to borrow the book.
        /// </summary>
        /// <returns>True if borrowing was successful; otherwise, false.</returns>
        public bool BorrowBook()
        {
            if (_isAvailable)
            {
                _isAvailable = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the book to the library.
        /// </summary>
        public void ReturnBook() =>
            _isAvailable = true;

        /// <summary>
        /// Gets information about the book.
        /// </summary>
        /// <returns>A string that contains the title, author, and availability status.</returns>
        public string GetInfo()
        {
            string info = $"Title: {_title}, Author: {_author}, Available: {_isAvailable}";
            return info;
        }
    }
}
