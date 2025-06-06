using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Student : Person
    {
        public int[] SessionResults;

        public Student(string surname, int birthYear, int[] sessionResults)
            : base(surname, birthYear, "Student")
        {
            SessionResults = sessionResults;
        }

        public override string GetInfo()
        {
            return SessionResults.Length > 0
                ? $"Average score: {SessionResults.Average():F2}"
                : "No results";
        }
    }
}
