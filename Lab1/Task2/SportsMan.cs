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

        public SportsMan(string surname, int BirthYear, double[] results)
        {
            this.surname = surname;
            this.birthYear = birthYear;
            this.results = results;
        }
        private double midleResult()
        {
            double sum = 0;
            for (int i = 0; i < this.results.Length; i++)
            {
                sum += this.results[i];
            }
            sum = sum / this.results.Length;
            return sum;
        }
        public string resurnSportsman()
        {
            return $"Фамилия: {this.surname}, Среднее значения: {this.midleResult}, Год рождения: {this.birthYear}";
        }
    }
}
