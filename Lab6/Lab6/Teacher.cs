using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Represents a teacher with specific workload information
    /// </summary>
    internal class Teacher : Person
    {
        /// <summary>
        /// Array storing workload hours per subject
        /// </summary>
        private int[] _workload;

        /// <summary>
        /// Initializes a new instance of the Teacher class
        /// </summary>
        /// <param name="surname">Teacher's surname</param>
        /// <param name="birthYear">Year of birth</param>
        /// <param name="workload">Array of workload hours per subject</param>
        public Teacher(string surname, int birthYear, int[] workload)
            : base(surname, birthYear, "Teacher")
        {
            _workload = workload;
        }

        /// <summary>
        /// Gets summary information about the teacher's workload
        /// </summary>
        /// <returns>
        /// String containing total workload hours in the format:
        /// "Total workload: {total} hours"
        /// </returns>
        public override string GetInfo()
        {
            return $"Total workload: {_workload.Sum()} hours";
        }
    }
}