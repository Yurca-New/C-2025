using Lab8;
using System;
using System.Collections.Generic;

string pacientFile = "../../../patients.txt";
string diagnosFile = "../../../diagnoses.txt";

List<Diagnos> diagnoses = FileInteraction.ReadDiagnos(diagnosFile);
List<Pacient> pacients = FileInteraction.ReadPacient(pacientFile, diagnoses);

DataManager dataManager = new DataManager(pacients, diagnoses);

// Subscribe to data changes
dataManager.OnDataChanged += (sender, e) =>
{
    ConsoleInteraction.DisplayStatistics(
        dataManager.GetPacientCount(),
        dataManager.GetSortedPacients()
    );
};

// Initial statistics display
dataManager.RaiseDataChanged();

// Main menu loop
while (true)
{
    ConsoleInteraction.DisplayMenu();
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ConsoleInteraction.DisplayPacients(dataManager.Pacients, dataManager.Diagnoses);
            break;

        case "2":
            AddPacient(dataManager);
            break;

        case "3":
            RemovePacient(dataManager);
            break;

        case "4":
            dataManager.RaiseDataChanged();
            break;

        case "5":
            ToggleSortOrder(dataManager);
            break;

        case "6":
            Console.Write("Enter surname: ");
            string surname = Console.ReadLine();
            ConsoleInteraction.DisplaySearchResults(dataManager.SearchBySurname(surname));
            break;

        case "7":
            Console.Write("Enter date (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime admDate))
                ConsoleInteraction.DisplaySearchResults(dataManager.SearchByAdmissionDate(admDate));
            else
                ConsoleInteraction.DisplayError("Invalid date format");
            break;

        case "8":
            Console.Write("Enter date (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime disDate))
                ConsoleInteraction.DisplaySearchResults(dataManager.SearchByDischargeDate(disDate));
            else
                ConsoleInteraction.DisplayError("Invalid date format");
            break;

        case "9":
            return;

        default:
            ConsoleInteraction.DisplayError("Invalid option");
            break;
    }
}

void AddPacient(DataManager dm)
{
    Console.Write("Surname: ");
    string surname = Console.ReadLine();

    Console.Write("Admission date (yyyy-MM-dd): ");
    if (!DateTime.TryParse(Console.ReadLine(), out DateTime dateAdm))
    {
        ConsoleInteraction.DisplayError("Invalid date format");
        return;
    }

    Console.WriteLine("Available diagnoses:");
    dm.Diagnoses.ForEach(d => Console.WriteLine($"- {d.DiagnosisName}"));

    Console.Write("Diagnosis: ");
    string diagnosName = Console.ReadLine();

    if (!dm.Diagnoses.Any(d => d.DiagnosisName == diagnosName))
    {
        ConsoleInteraction.DisplayError("Invalid diagnosis");
        return;
    }

    Pacient p = new(surname, dateAdm, diagnosName, dm.Diagnoses);
    dm.AddPacient(p);
    ConsoleInteraction.DisplayMessage("Patient added successfully");
}

void RemovePacient(DataManager dm)
{
    Console.Write("Patient surname to remove: ");
    string surname = Console.ReadLine();
    var found = dm.SearchBySurname(surname);

    if (found.Count == 0)
    {
        ConsoleInteraction.DisplayError("Patients not found");
        return;
    }

    Console.WriteLine("Found patients:");
    for (int i = 0; i < found.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {found[i].Surname} (Admitted: {found[i].DateAdmission:yyyy-MM-dd})");
    }

    Console.Write("Select number to remove: ");
    if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= found.Count)
    {
        dm.RemovePacient(found[index - 1]);
        ConsoleInteraction.DisplayMessage("Patient removed successfully");
    }
    else
    {
        ConsoleInteraction.DisplayError("Invalid selection");
    }
}

void ToggleSortOrder(DataManager dm)
{
    dm.SortOrder = dm.SortOrder == 0 ? 1 : 0;
    Console.WriteLine($"Sort order changed to: {(dm.SortOrder == 0 ? "Ascending" : "Descending")}");
    dm.RaiseDataChanged();
}
