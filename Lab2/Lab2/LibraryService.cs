using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class LibraryService
    {
        /// <summary>
        /// Provides services for creating library books.
        /// </summary>
        private readonly UserInterface _userInterface;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryService"/> class.
        /// </summary>
        /// <param name="userInterface">The user interface to interact with the user.</param>
        public LibraryService(UserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        /// <summary>
        /// Creates a new library book based on user input.
        /// </summary>
        /// <returns>A new instance of <see cref="LibraryBook"/>.</returns>
        public LibraryBook CreateLibraryBook()
        {
            string title = _userInterface.GetNonNullString("Enter the book title:");
            string author = _userInterface.GetNonNullString("Enter the book author:");
            LibraryBook book = new LibraryBook(title, author);
            return book;
        }
    }
}
