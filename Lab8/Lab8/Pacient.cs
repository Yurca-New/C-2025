using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class Pacient
    {
        /// <summary>
        /// Gets or sets the surname of the patient.
        /// </summary>
        public string Surname;

        /// <summary>
        /// Gets or sets the date of admission to the hospital.
        /// </summary>
        public DateTime DateAdmission;

        /// <summary>
        /// Gets or sets the date of discharge from the hospital.
        /// </summary>
        public DateTime DateDischarge;

        /// <summary>
        /// Gets or sets the diagnosis of the patient.
        /// </summary>
        public string Diagnosis;

        /// <summary>
        /// Gets or sets the hospital department where the patient is treated.
        /// </summary>
        public string HospitalDipartment;

        /// <summary>
        /// Gets or sets the number of days the patient stays in the hospital.
        /// </summary>
        public int StayInHospital { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pacient"/> class.
        /// Subscribes to diagnosis events to update department and duration automatically.
        /// </summary>
        /// <param name="surname">The surname of the patient.</param>
        /// <param name="dateAdmission">The date of admission.</param>
        /// <param name="diagnosis">The diagnosis name.</param>
        /// <param name="diagnos">The list of available diagnoses.</param>
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

        /// <summary>
        /// Handles the event when the hospital department for the diagnosis changes.
        /// Updates the patient's department accordingly.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="newDepartment">The new department name.</param>
        private void Diagnos1_OnDepartmentChanged(object sender, string newDepartment)
        {
            HospitalDipartment = newDepartment;
        }

        /// <summary>
        /// Handles the event when the duration of treatment for the diagnosis changes.
        /// Updates the patient's stay and discharge date accordingly.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="newDuration">The new duration as a string.</param>
        private void Diagnos1_OnDurationChanged(object sender, string newDuration)
        {
            if (int.TryParse(newDuration, out int duration))
            {
                StayInHospital = duration;
                DateDischarge = DateAdmission.AddDays(StayInHospital);
            }
        }

        /// <summary>
        /// Returns a formatted string with patient information for display.
        /// </summary>
        /// <returns>A string containing surname, diagnosis, admission and discharge dates.</returns>
        public string GetInfow()
        {
            return $"{Surname}\t\t{Diagnosis}\t\t{DateAdmission.ToShortDateString()}\t\t{DateDischarge.ToShortDateString()}";
        }

        /// <summary>
        /// Returns a tuple with patient information.
        /// </summary>
        /// <returns>A tuple containing surname, diagnosis, admission and discharge dates as strings.</returns>
        public (string, string, string, string) GetInfo()
        {
            return (Surname, Diagnosis, DateAdmission.ToShortDateString(), DateDischarge.ToShortDateString());
        }
    }
}
