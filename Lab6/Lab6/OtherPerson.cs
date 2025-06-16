using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Represents a person with a non-standard status (neither Student nor Teacher)
    /// </summary>
    internal class OtherPerson : Person
    {
        /// <summary>
        /// Initializes a new instance of the OtherPerson class
        /// </summary>
        /// <param name="surname">Person's surname</param>
        /// <param name="birthYear">Year of birth</param>
        /// <param name="status">
        /// Custom status description (e.g., "Researcher", "Administrator", etc.)
        /// </param>
        public OtherPerson(string surname, int birthYear, string status)
            : base(surname, birthYear, status)
        {
            // Inherits all functionality from base Person class
        }
    }
}