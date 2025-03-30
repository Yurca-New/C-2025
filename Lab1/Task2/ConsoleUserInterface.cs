using Task2;

namespace Task2
{
    public class ConsoleUserInterface
    {
        public int GetPositiveInt(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out int result) && result > 0)
                    return result;

                ShowError(errorMessage);
            }
        }

        public double GetPositiveDouble(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (double.TryParse(Console.ReadLine(), out double result) && result > 0)
                    return result;

                ShowError(errorMessage);
            }
        }

        public string GetString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ошибка: {message}");
            Console.ResetColor();
        }

        public void DisplaySportsMen(IEnumerable<SportsMan> sportsmen)
        {
            foreach (var sportsman in sportsmen)
            {
                Console.WriteLine(sportsman);
            }
        }

        public void DisplayNameAndBirthYear(IEnumerable<SportsMan> sportsmen)
        {
            foreach(var sportsman in sportsmen)
            {
                Console.WriteLine($"{sportsman.Surname}: {sportsman.BirthYear}");
            }
        }
    }
}