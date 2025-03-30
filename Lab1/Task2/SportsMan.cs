using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SportsMan
    {
        public string Surname { get; }
        public int BirthYear { get; }
        public double[] Results { get; }
        public double AverageResult => Results.Average();

        public SportsMan(string surname, int birthYear, double[] results)
        {
            Surname = surname;
            BirthYear = birthYear;
            Results = results;
        }

        public override string ToString()
        {
            return $"Фамилия: {Surname}, Год рождения: {BirthYear}, Средний результат: {AverageResult:F2}";
        }
    }
}
