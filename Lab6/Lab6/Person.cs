using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal abstract class Person
    {
        public string Surname;
        public int BirthYear;
        public string Status;

        protected Person(string surname, int birthYear, string status)
        {
            Surname = surname;
            BirthYear = birthYear;
            Status = status;
        }
        public virtual string GetInfo()
        {
            int age = DateTime.Now.Year - BirthYear;
            return $"{age} years";
        }
        public virtual string GetFullInfo()
        {
            return $"{Surname}\t{BirthYear}\t{Status}\t \t{GetInfo()}";
        }
    }
}
