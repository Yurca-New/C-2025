using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class Pacient
    {
        public string Surname;
        public DateTime DateAdmission;
        public DateTime DateDischarge;
        public string Diagnosis;
        public string HospitalDipartment;
        public int StayInHospital { get; set; }

        public Pacient(string surname, DateTime dateAdmission, string diagnosis, List<Diagnos> diagnos)
        {
            Surname = surname;
            DateAdmission = dateAdmission;
            Diagnosis = diagnosis;
            Diagnos diagnos1 = diagnos.FirstOrDefault(d => d.DiagnosisName == diagnosis);
            if (diagnos1 != null)
            {
                HospitalDipartment = diagnos1.NameHospitalDipartment;
                StayInHospital = diagnos1.DurationOfTreatment;
                DateDischarge = dateAdmission.AddDays(StayInHospital);
                diagnos1.OnDepartmentChanged += Diagnos1_OnDepartmentChanged;
                diagnos1.OnDurationChanged += Diagnos1_OnDurationChanged;
            }
            else
            {
                DateDischarge = dateAdmission;
                HospitalDipartment = "Unknown";
                StayInHospital = 0;
            }
        }

        private void Diagnos1_OnDepartmentChanged(object sender, string newDepartment)
        {
            HospitalDipartment = newDepartment;
        }
        private void Diagnos1_OnDurationChanged(object sender, string newDuration)
        {
            if (int.TryParse(newDuration, out int duration))
            {
                StayInHospital = duration;
                DateDischarge = DateAdmission.AddDays(StayInHospital);
            }
        }

        public string GetInfow()
        {
            return $"{Surname}\t\t{Diagnosis}\t\t{DateAdmission.ToShortDateString()}\t\t{DateDischarge.ToShortDateString()}";
        }
        public (string, string, string, string) GetInfo()
        {
            return (Surname, Diagnosis, DateAdmission.ToShortDateString(), DateDischarge.ToShortDateString());
        }
    }
}
