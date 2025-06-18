using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lab8;

namespace Lab8
{
    internal static class FileInteraction
    {
        private const int PacientPartsCount = 4;
        private const int PacientSurnameIndex = 0;
        private const int PacientDateAdmissionIndex = 1;
        private const int PacientDiagnosisIndex = 3;

        private const int DiagnosPartsCount = 3;
        private const int DiagnosNameIndex = 0;
        private const int DiagnosDurationIndex = 1;
        private const int DiagnosHospitalDipartmentIndex = 2;
        public static List<Pacient> ReadPacient(string inputFile, List<Diagnos> diagnos)
        {
            return File.ReadAllLines(inputFile)
                .Select(line => line.Split(';'))
                .Where(parts => parts.Length == PacientPartsCount)
                .Select(parts => new Pacient(parts[PacientSurnameIndex], DateTime.Parse(parts[PacientDateAdmissionIndex]), parts[PacientDiagnosisIndex], diagnos))
                .ToList();
        }
        public static List<Diagnos> ReadDiagnos(string inputFile)
        {
            return File.ReadAllLines(inputFile)
                .Select(line => line.Split(';'))
                .Where(parts => parts.Length == DiagnosPartsCount)
                .Select(parts => new Diagnos(parts[DiagnosNameIndex], int.Parse(parts[DiagnosDurationIndex]), parts[DiagnosHospitalDipartmentIndex]))
                .ToList();
        }
    }
}
