using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Abstract base class representing a person
    /// </summary>
    internal abstract class Person
    {
        /// <summary>
        /// Surname of the person
        /// </summary>
        public string Surname;

        /// <summary>
        /// Year of birth
        /// </summary>
        public int BirthYear;

        /// <summary>
        /// Current status (e.g., Student, Teacher, etc.)
        /// </summary>
        public string Status;

        /// <summary>
        /// Initializes a new instance of the Person class
        /// </summary>
        /// <param name="surname">Person's surname</param>
        /// <param name="birthYear">Year of birth</param>
        /// <param name="status">Current status/role</param>
        protected Person(string surname, int birthYear, string status)
        {
            Surname = surname;
            BirthYear = birthYear;
            Status = status;
        }

        /// <summary>
        /// Gets basic information about the person
        /// </summary>
        /// <returns>
        /// String containing the person's current age in the format:
        /// "{age} years"
        /// </returns>
        public virtual string GetInfo()
        {
            int age = DateTime.Now.Year - BirthYear;
            return $"{age} years";
        }

        /// <summary>
        /// Gets complete information about the person
        /// </summary>
        /// <returns>
        /// Formatted string containing surname, birth year, status,
        /// and basic information in a tab-separated format
        /// </returns>
        public virtual string GetFullInfo()
        {
            return $"{Surname}\t{BirthYear}\t{Status}\t \t{GetInfo()}";
        }
    }
}