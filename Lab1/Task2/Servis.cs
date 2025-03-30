using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace Task2
{
    class Servis
    {
        public IEnumerable<SportsMan> GetSportsMenByYearRange(IEnumerable<SportsMan> sportsmen)
        {
            var minYear = sportsmen.Min(s => s.BirthYear);
            var maxYear = sportsmen.Max(s => s.BirthYear);

            return sportsmen
                .OrderBy(s => s.BirthYear)
                .GroupBy(s => s.BirthYear)
                .SelectMany(g => g);
        }

        public IEnumerable<SportsMan> FilterByAverage(IEnumerable<SportsMan> sportsmen, double minValue)
        {
            return sportsmen.Where(s => s.AverageResult > minValue);
        }

        public IEnumerable<SportsMan> FilterByRange(IEnumerable<SportsMan> sportsmen, double min, double max)
        {
            return sportsmen.Where(s => s.AverageResult > min && s.AverageResult < max);
        }

    }
}
