using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Teacher : Person
    {
        private int[] _workload;

        public Teacher(string surname, int birthYear, int[] workload)
            : base(surname, birthYear, "Teacher")
        {
            _workload = workload;
        }

        public override string GetInfo()
        {
            return $"Total workload: {_workload.Sum()} hours";
        }
    }
}