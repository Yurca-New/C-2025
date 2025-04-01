using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class UserInterface
    {
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
                Console.WriteLine(prompt);
                string result = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(result))
                    return result;
                
                else
                    ShowError("The entered text must not be empty");
            }   
        }
        public string TestNullString(string count, string prompt) 
        {
            if (string.IsNullOrWhiteSpace(count))
            {
                ShowError(prompt);
                Environment.Exit(0);
                return "..";
            }
            else
                return count;
        }
    }
}
