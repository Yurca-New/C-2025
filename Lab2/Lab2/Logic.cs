using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2;
namespace Lab2
{
    internal class Logic
    {
        UserInterface userInterface = new UserInterface();
        public string GetNonNullString(string prompt)
        {
            while (true)
            {
                userInterface.ShowMessage(prompt);
                string result = userInterface.ReadString();
                if (!string.IsNullOrWhiteSpace(result))
                    return result;

                else
                    userInterface.ShowError("The entered text must not be empty");
            }
        }
    
        public LibraryBook CreateLibraryBook()
        {
            string title = GetNonNullString("Enter the book title:");
            string author = GetNonNullString("Enter the book author:");
            return new LibraryBook(title, author);
        }
    }
}
