using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    /// <summary>
    /// Represents an abstract book with title and author.
    /// </summary>
    internal abstract class Book
    {
        private string _title;
        private string _author;

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        public string Title
        {
            get => _title;
            set => _title = value;
        }

        /// <summary>
        /// Gets or sets the author of the book.
        /// </summary>
        public string Author
        {
            get => _author;
            set => _author = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class with the specified title and author.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The author of the book.</param>
        public Book(string title, string author)
        {
            _title = title;
            _author = author;
        }
    }
}
