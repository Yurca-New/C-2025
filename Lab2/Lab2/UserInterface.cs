using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class UserInterface
    {
        public string ReadString()
        {
            return Console.ReadLine();
        }
        public void ShowMessage(string message) =>
            Console.WriteLine(message);

        public void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
        }
        public string GetNonNullString(string prompt)
        {
            while (true)
            {
                ShowMessage(prompt);
                string result = ReadString();
                if (!string.IsNullOrWhiteSpace(result))
                {
                    return result;
                }
                else
                {
                    ShowError("The entered text must not be empty");
                }
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
