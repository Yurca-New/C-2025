using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    /// <summary>
    /// Represents a patient in the hospital.
    /// </summary>
    internal class Pacient
    {
        private List<Diagnos> _diagnosList;
        private Diagnos _diagnos;

        /// <summary>
        /// Gets or sets the surname of the patient.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the date of admission to the hospital.
        /// </summary>
        public DateTime DateAdmission { get; set; }

        /// <summary>
        /// Gets or sets the date of discharge from the hospital.
        /// </summary>
        public DateTime DateDischarge { get; set; }

        /// <summary>
        /// Gets or sets the diagnosis of the patient.
        /// </summary>
        public string Diagnosis { get; set; }

        /// <summary>
        /// Gets or sets the hospital department where the patient is treated.
        /// </summary>
        public string HospitalDipartment { get; set; }

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
        /// <param name="diagnosList">The list of available diagnoses.</param>
        public Pacient(string surname, DateTime dateAdmission, string diagnosis, List<Diagnos> diagnosList)
        {
            Surname = surname;
            DateAdmission = dateAdmission;
            Diagnosis = diagnosis;
            _diagnosList = diagnosList;

            _diagnos = _diagnosList.FirstOrDefault(d => d.DiagnosisName == diagnosis);
            if (_diagnos != null)
            {
                HospitalDipartment = _diagnos.NameHospitalDipartment;
                StayInHospital = _diagnos.DurationOfTreatment;
                DateDischarge = dateAdmission.AddDays(StayInHospital);

                _diagnos.OnDepartmentChanged += Diagnos_OnDepartmentChanged;
                _diagnos.OnDurationChanged += Diagnos_OnDurationChanged;
            }
            else
            {
                DateDischarge = dateAdmission;
                HospitalDipartment = "Unknown";
                StayInHospital = 0;
            }
        }

        /// <summary>
        /// Unsubscribes from diagnosis events.
        /// </summary>
        public void Unsubscribe()
        {
            if (_diagnos != null)
            {
                _diagnos.OnDepartmentChanged -= Diagnos_OnDepartmentChanged;
                _diagnos.OnDurationChanged -= Diagnos_OnDurationChanged;
            }
        }

        /// <summary>
        /// Handles the event when the hospital department for the diagnosis changes.
        /// Updates the patient's department accordingly.
        /// </summary>
        private void Diagnos_OnDepartmentChanged(object sender, string newDepartment)
        {
            HospitalDipartment = newDepartment;
        }

        /// <summary>
        /// Handles the event when the duration of treatment for the diagnosis changes.
        /// Updates the patient's stay and discharge date accordingly.
        /// </summary>
        private void Diagnos_OnDurationChanged(object sender, string newDuration)
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
        public string GetInfow()
        {
            return $"{Surname}\t\t{Diagnosis}\t\t{DateAdmission.ToShortDateString()}\t\t{DateDischarge.ToShortDateString()}";
        }

        /// <summary>
        /// Returns a tuple with patient information.
        /// </summary>
        public (string, string, string, string) GetInfo()
        {
            return (Surname, Diagnosis, DateAdmission.ToShortDateString(), DateDischarge.ToShortDateString());
        }
    }
}
