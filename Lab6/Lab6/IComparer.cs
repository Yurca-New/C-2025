using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal interface IComparer
    {
        public class SurnameComparer : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return string.Compare(x.Surname, y.Surname, StringComparison.Ordinal);
            }
        }

        public class BirthYearComparer : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.BirthYear.CompareTo(y.BirthYear);
            }
        }
    }
}
