using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class UserInterface: IUserInterface
    {
        public void ShowWelcomeMessage() =>
            Console.WriteLine("Програма нахождения функции\n");

        public void ShowMessage(string message) =>
            Console.WriteLine(message);

        public void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ошибка: {message}");
            Console.ResetColor();
        }

        public void ShowArray(string name, int[] array)
        {
            Console.Write($"Массив {name}: ");
            Console.WriteLine(string.Join(", ", array));
        }

        public void ShowCalculationResults(CalculationResults results)
        {
            Console.WriteLine($"A: {results.A},B: {results.B},C: {results.C}");
        }

        public void ShowFinalResult(double FinalResult)
        {
            Console.WriteLine($"Финальный результат функции будет: {FinalResult}");
        }

        public int GetPositiveIntInput(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out var result) && result > 0)
                    return result;

                ShowError(errorMessage);
            }
        }

        public int GetIntInput(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out var result))
                    return result;

                ShowError(errorMessage);
            }
        }
    }
}
