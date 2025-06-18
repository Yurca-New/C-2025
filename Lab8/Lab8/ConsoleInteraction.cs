using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal static class ConsoleInteraction
    {
        /// <summary>
        /// Displays a message to the console.
        /// </summary>
        /// <param name="message">The message to display.</param>
        private static void DisplayeMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Displays an error message in red color to the console.
        /// </summary>
        /// <param name="errorMessage">The error message to display.</param>
        private static void DisplayError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            DisplayeMessage($"Error: {errorMessage}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a list of patients grouped by diagnosis, including their treatment department.
        /// </summary>
        /// <param name="pacients">The list of patients to display.</param>
        /// <param name="diagnos">The list of diagnoses for grouping and department information.</param>
        public static void DisplayPacients(List<Pacient> pacients, List<Diagnos> diagnos)
        {
            if (pacients == null || pacients.Count == 0)
            {
                DisplayError("No patients found.");
                return;
            }
            foreach (Diagnos d in diagnos)
            {
                List<Pacient> filteredPacients = pacients.Where(p => p.Diagnosis == d.DiagnosisName).ToList();
                if (filteredPacients.Count == 0)
                {
                    DisplayError($"No patients found with diagnosis: {d.DiagnosisName}");
                    continue;
                }
                DisplayeMessage(d.DiagnosisName);
                Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-20}", "LastName", "Diagnosis", "Admission", "Discharge", "Department");
                for (int i = 0; i < filteredPacients.Count; i++)
                {
                    Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-20}",
                        filteredPacients[i].Surname,
                        filteredPacients[i].Diagnosis,
                        filteredPacients[i].DateAdmission.ToShortDateString(),
                        filteredPacients[i].DateDischarge.ToShortDateString(),
                        filteredPacients[i].HospitalDipartment);
                }
                Console.WriteLine();
            }
        }
    }
}
