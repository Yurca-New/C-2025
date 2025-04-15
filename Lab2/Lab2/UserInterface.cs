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
    }
}
