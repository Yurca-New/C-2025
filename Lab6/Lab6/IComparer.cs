using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Provides custom comparer implementations for Person objects
    /// </summary>
    internal interface IComparer
    {
        /// <summary>
        /// Compares Person objects by surname alphabetically
        /// </summary>
        public class SurnameComparer : IComparer<Person>
        {
            /// <summary>
            /// Compares two Person objects by surname
            /// </summary>
            /// <param name="x">First Person to compare</param>
            /// <param name="y">Second Person to compare</param>
            /// <returns>
            /// Less than zero if x's surname precedes y's in alphabetical order,
            /// Zero if surnames are identical,
            /// Greater than zero if x's surname follows y's in alphabetical order
            /// </returns>
            public int Compare(Person x, Person y)
            {
                return string.Compare(x.Surname, y.Surname, StringComparison.Ordinal);
            }
        }

        /// <summary>
        /// Compares Person objects by birth year
        /// </summary>
        public class BirthYearComparer : IComparer<Person>
        {
            /// <summary>
            /// Compares two Person objects by birth year
            /// </summary>
            /// <param name="x">First Person to compare</param>
            /// <param name="y">Second Person to compare</param>
            /// <returns>
            /// Less than zero if x was born before y,
            /// Zero if both were born in the same year,
            /// Greater than zero if x was born after y
            /// </returns>
            public int Compare(Person x, Person y)
            {
                return x.BirthYear.CompareTo(y.BirthYear);
            }
        }
    }
}