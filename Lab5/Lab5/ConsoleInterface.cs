using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    /// <summary>
    /// Provides methods for interacting with the user via the console.
    /// </summary>
    internal class ConsoleInterface
    {
        /// <summary>
        /// Reads a line of text from the console.
        /// </summary>
        /// <returns>The input string entered by the user.</returns>
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
        /// Displays an error message in red color to the console.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        public void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Prompts the user for a non-null, non-empty string input.
        /// </summary>
        /// <param name="prompt">The prompt message to display to the user.</param>
        /// <returns>A non-null, non-empty string entered by the user.</returns>
        public string GetNonNullString(string prompt)
        {
            while (true)
            {
                ShowMessage(prompt);
                string result = ReadString();
                bool isNullOrEmpty = string.IsNullOrEmpty(result);
                if (!isNullOrEmpty)
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
