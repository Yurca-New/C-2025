using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class ConsoleInterface
    {
        public string ReadString()
        {
            string input = Console.ReadLine();
            return input;
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
