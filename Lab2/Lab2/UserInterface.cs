using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /// <summary>
    /// Provides methods for user interaction via the console.
    /// </summary>
    internal class UserInterface
    {
        /// <summary>
        /// Reads a string input from the user.
        /// </summary>
        /// <returns>The entered string.</returns>
        public string ReadString()
        {
            string input = Console.ReadLine();
            return input;
        }

        /// <summary>
        /// Displays a message to the console.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public void ShowMessage(string message) =>
            Console.WriteLine(message);


        /// <summary>
        /// Displays an error message in red color.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        public void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Prompts the user until a non-null, non-whitespace string is entered.
        /// </summary>
        /// <param name="prompt">The prompt message.</param>
        /// <returns>The non-null string entered by the user.</returns>
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
    }
}
