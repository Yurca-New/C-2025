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
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Displays an error message in red color to the console.
        /// </summary>
        /// <param name="errorMessage">The error message to display.</param>
        public static void DisplayError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            DisplayMessage($"Error: {errorMessage}");
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

                DisplayMessage(d.DiagnosisName);
                Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-20}", "LastName", "Diagnosis", "Admission", "Discharge", "Department");

                foreach (var p in filteredPacients)
                {
                    Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-20}",
                        p.Surname, p.Diagnosis,
                        p.DateAdmission.ToShortDateString(),
                        p.DateDischarge.ToShortDateString(),
                        p.HospitalDipartment);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Displays the main menu for the hospital management system.
        /// </summary>
        public static void DisplayMenu()
        {
            Console.WriteLine("\n===== Hospital Management System =====");
            Console.WriteLine("1. Show all patients");
            Console.WriteLine("2. Add new patient");
            Console.WriteLine("3. Remove patient");
            Console.WriteLine("4. Show statistics");
            Console.WriteLine("5. Toggle sort order");
            Console.WriteLine("6. Search by surname");
            Console.WriteLine("7. Search by admission date");
            Console.WriteLine("8. Search by discharge date");
            Console.WriteLine("9. Exit");
            Console.Write("Select an option: ");
        }

        /// <summary>
        /// Displays statistics and a sorted list of patients.
        /// </summary>
        /// <param name="count">Total number of patients.</param>
        /// <param name="sortedPatients">Sorted list of patients.</param>
        public static void DisplayStatistics(int count, IEnumerable<Pacient> sortedPatients)
        {
            Console.WriteLine("\n===== System Statistics =====");
            Console.WriteLine($"Total patients: {count}");
            Console.WriteLine("Sorted patient list:");

            foreach (var p in sortedPatients)
            {
                Console.WriteLine($"- {p.Surname} (Admitted: {p.DateAdmission:yyyy-MM-dd})");
            }
        }

        /// <summary>
        /// Displays search results for patients.
        /// </summary>
        /// <param name="results">List of found patients.</param>
        public static void DisplaySearchResults(List<Pacient> results)
        {
            if (results.Count == 0)
            {
                DisplayMessage("No patients found.");
                return;
            }

            Console.WriteLine("\nSearch results:");
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}", "Surname", "Diagnosis", "Admission", "Discharge");

            foreach (var p in results)
            {
                Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}",
                    p.Surname, p.Diagnosis,
                    p.DateAdmission.ToShortDateString(),
                    p.DateDischarge.ToShortDateString());
            }
        }
    }
}
