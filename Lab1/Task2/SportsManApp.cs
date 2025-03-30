using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace Task2
{
    public class SportsManApp
    {
        public void Run() 
        {
            var ui = new ConsoleUserInterface();
            var servis = new Servis();

            var count = ui.GetPositiveInt("Введите количество спортсменов:", "Некорректное количество!");
            var sportsmen = new List<SportsMan>();

            for (int i = 0; i < count; i++)
            {
                var surname = ui.GetString($"Введите фамилию спортсмена {i + 1}:");
                var birthYear = ui.GetPositiveInt($"Введите год рождения спортсмена {i + 1}:", "Некорректный год!");
                var resultsCount = ui.GetPositiveInt($"Введите количество результатов:", "Некорректное количество!");

                var results = new List<double>();
                for (int j = 0; j < resultsCount; j++)
                {
                    results.Add(ui.GetPositiveDouble($"Введите результат {j + 1}:", "Некорректный результат!"));
                }

                sportsmen.Add(new SportsMan(surname, birthYear, results.ToArray()));
            }

            var SortList = servis.GetSportsMenByYearRange(sportsmen);
            ui.DisplayNameAndBirthYear(SortList);
            ui.DisplaySportsMen(servis.FilterByAverage(SortList, ui.GetPositiveDouble("Введите минимальное среднёе значения", "Некорректный результат!")));
            ui.DisplaySportsMen(servis.FilterByRange(SortList, ui.GetPositiveDouble("Введите минимальное среднёе значения", "Некорректный результат!"), ui.GetPositiveDouble("Введите максимальное среднёе значения", "Некорректный результат!")));
        }
    }
}
