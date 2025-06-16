using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Represents a student with academic session results
    /// </summary>
    internal class Student : Person
    {
        /// <summary>
        /// Array storing the student's session grades
        /// </summary>
        public int[] SessionResults;

        /// <summary>
        /// Initializes a new instance of the Student class
        /// </summary>
        /// <param name="surname">Student's surname</param>
        /// <param name="birthYear">Year of birth</param>
        /// <param name="sessionResults">Array of session grades</param>
        public Student(string surname, int birthYear, int[] sessionResults)
            : base(surname, birthYear, "Student")
        {
            SessionResults = sessionResults;
        }

        /// <summary>
        /// Gets academic performance information
        /// </summary>
        /// <returns>
        /// String containing average score formatted to 2 decimal places when results exist,
        /// or "No results" when the session results array is empty
        /// </returns>
        public override string GetInfo()
        {
            return SessionResults.Length > 0
                ? $"Average score: {SessionResults.Average():F2}"
                : "No results";
        }
    }
}