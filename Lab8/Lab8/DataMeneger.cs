using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab8
{
    internal class DataManager
    {
        public List<Pacient> Pacients { get; private set; }
        public List<Diagnos> Diagnoses { get; private set; }
        public int SortOrder { get; set; } = 0; // 0: Ascending, 1: Descending

        public event EventHandler OnDataChanged;

        public DataManager(List<Pacient> pacients, List<Diagnos> diagnoses)
        {
            Pacients = pacients;
            Diagnoses = diagnoses;
        }

        public void AddPacient(Pacient pacient)
        {
            Pacients.Add(pacient);
            OnDataChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RemovePacient(Pacient pacient)
        {
            pacient.Unsubscribe();
            Pacients.Remove(pacient);
            OnDataChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RaiseDataChanged()
        {
            OnDataChanged?.Invoke(this, EventArgs.Empty);
        }

        public int GetPacientCount() => Pacients.Count;

        public IEnumerable<Pacient> GetSortedPacients()
        {
            return SortOrder == 0
                ? Pacients.OrderBy(p => p.Surname)
                : Pacients.OrderByDescending(p => p.Surname);
        }

        public List<Pacient> SearchBySurname(string surname) =>
            Pacients.Where(p => p.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase)).ToList();

        public List<Pacient> SearchByAdmissionDate(DateTime date) =>
            Pacients.Where(p => p.DateAdmission < date).ToList();

        public List<Pacient> SearchByDischargeDate(DateTime date) =>
            Pacients.Where(p => p.DateDischarge > date).ToList();
    }
}