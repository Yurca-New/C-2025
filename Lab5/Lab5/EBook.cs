using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    /// <summary>
    /// Represents an electronic book.
    /// </summary>
    internal class EBook : Book
    {
        private string _bookType;

        /// <summary>
        /// Initializes a new instance of the <see cref="EBook"/> class with the specified title and author.
        /// </summary>
        /// <param name="title">The title of the e-book.</param>
        /// <param name="author">The author of the e-book.</param>
        public EBook(string title, string author)
            : base(title, author)
        {
            _bookType = "Printed";
        }

        /// <summary>
        /// Changes the type of the book to the specified new type.
        /// </summary>
        /// <param name="newType">The new type to set for the book.</param>
        /// <returns>The updated book type.</returns>
        public string ChangeBookType(string newType)
        {
            _bookType = newType;
            return _bookType;
        }

        /// <summary>
        /// Simulates reading the e-book.
        /// </summary>
        /// <returns>A string indicating that the e-book is being read.</returns>
        public string Read()
        {
            return "Reading an e-book";
        }
    }
}
