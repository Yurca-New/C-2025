using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class Diagnos
    {
        /// <summary>
        /// Gets or sets the name of the diagnosis.
        /// </summary>
        public string DiagnosisName;

        private int _durationOfTreatment;

        /// <summary>
        /// Gets or sets the duration of treatment in days.
        /// When set, triggers the <see cref="OnDurationChanged"/> event if the value changes.
        /// </summary>
        public int DurationOfTreatment
        {
            get => _durationOfTreatment;
            set
            {
                if (_durationOfTreatment != value)
                {
                    _durationOfTreatment = value;
                    OnDurationChanged?.Invoke(this, value.ToString());
                }
            }
        }

        private string _nameHospitalDipartment;

        /// <summary>
        /// Gets or sets the name of the hospital department.
        /// When set, triggers the <see cref="OnDepartmentChanged"/> event if the value changes.
        /// </summary>
        public string NameHospitalDipartment
        {
            get => _nameHospitalDipartment;
            set
            {
                if (_nameHospitalDipartment != value)
                {
                    _nameHospitalDipartment = value;
                    OnDepartmentChanged?.Invoke(this, value);
                }
            }
        }

        /// <summary>
        /// Occurs when the hospital department name is changed.
        /// </summary>
        public event EventHandler<string> OnDepartmentChanged;

        /// <summary>
        /// Occurs when the duration of treatment is changed.
        /// </summary>
        public event EventHandler<string> OnDurationChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="Diagnos"/> class.
        /// </summary>
        /// <param name="diagnosisName">The name of the diagnosis.</param>
        /// <param name="durationOfTreatment">The duration of treatment in days.</param>
        /// <param name="nameHospitalDipartment">The name of the hospital department.</param>
        public Diagnos(string diagnosisName, int durationOfTreatment, string nameHospitalDipartment)
        {
            DiagnosisName = diagnosisName;
            DurationOfTreatment = durationOfTreatment;
            _nameHospitalDipartment = nameHospitalDipartment;
        }

        /// <summary>
        /// Returns a string that represents the current diagnosis information.
        /// </summary>
        /// <returns>A string containing the diagnosis name, duration, and department.</returns>
        public string GetInfo()
        {
            return $"{DiagnosisName} {DurationOfTreatment} {NameHospitalDipartment}";
        }
    }
}
