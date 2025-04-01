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
            return sportsmen.OrderBy(s => s.BirthYear);
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
