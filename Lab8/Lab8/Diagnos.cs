using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class Diagnos
    {
        public string DiagnosisName;
        private int _durationOfTreatment;
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

        public event EventHandler<string> OnDepartmentChanged;
        public event EventHandler<string> OnDurationChanged;

        public Diagnos(string diagnosisName, int durationOfTreatment, string nameHospitalDipartment)
        {
            DiagnosisName = diagnosisName;
            DurationOfTreatment = durationOfTreatment;
            _nameHospitalDipartment = nameHospitalDipartment;
        }
        public string GetInfo()
        {
            return $"{DiagnosisName} {DurationOfTreatment} {NameHospitalDipartment}";
        }
        
    }
}
