using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class SportsMan
    {
        private string surname;
        private int birthYear;
        private double[] results;

        public SportsMan(string Surname, int BirthYear, double[] Results)
        {
            surname = Surname;
            birthYear = BirthYear;
            results = Results;
        }
        public int getBirthYear()
        {
            return birthYear;
        }
        public double midleResult()
        {
            double sum = 0;
            for (int i = 0; i < results.Length; i++)
            {
                sum += results[i];
            }
            sum = sum / results.Length;
            return sum;
        }
        public string resurnSportsman()
        {
            return $"Фамилия: {surname}, Среднее значения: {midleResult()}, Год рождения: {birthYear}";
        }
    }
}
