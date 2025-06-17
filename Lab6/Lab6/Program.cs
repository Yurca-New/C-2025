using Lab6;
using Microsoft.VisualBasic;
using System.Reflection;
using static Lab6.IComparer;

/// <summary>
/// Main program entry point for processing person data
/// </summary>
class Program
{
    public const string STUDENT_STATUS = "student";
    public const string TEACHER_STATUS = "teacher";

    public const int MIN_PARTS_COUNT = 3;
    public const int SURNAME_INDEX = 0;
    public const int YEAR_INDEX = 1;
    public const int STATUS_INDEX = 2;
    public const int DATA_START_INDEX = 3;
    /// <summary>
    /// Main execution method
    /// </summary>
    static void Main()
    {
        List<Person> people = LoadPeopleData("../../../people.txt");
        PrintPeopleWithAgeHighlight(people);
        ProcessStudentData(people);
        PrintTeacherWorkloadStats(people);
    }

    /// <summary>
    /// Loads person data from a text file
    /// </summary>
    /// <param name="filePath">Path to the data file</param>
    /// <returns>List of parsed Person objects</returns>
    static List<Person> LoadPeopleData(string filePath)
    {
        List<Person> people = new List<Person>();
        string[] lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var parts = line.Split(' ');

            if (parts.Length < MIN_PARTS_COUNT)
            {
                Console.WriteLine($"Invalid line format: {line}");
                continue;
            }

            string surname = parts[SURNAME_INDEX];
            int year = int.Parse(parts[YEAR_INDEX]);
            string status = parts[STATUS_INDEX];

            if (status == STUDENT_STATUS)
            {
                if (parts.Length > DATA_START_INDEX)
                {
                    int[] grades = parts.Skip(DATA_START_INDEX).Select(int.Parse).ToArray();
                    people.Add(new Student(surname, year, grades));
                }
                else
                {
                    // Если нет оценок — можно добавить пустой массив или как-то обработать
                    people.Add(new Student(surname, year, new int[0]));
                }
            }
            else if (status == TEACHER_STATUS)
            {
                int[] loads = parts.Length > DATA_START_INDEX ?
                    parts.Skip(DATA_START_INDEX).Select(int.Parse).ToArray() : new int[0];
                people.Add(new Teacher(surname, year, loads));
            }
            else
            {
                people.Add(new OtherPerson(surname, year, status));
            }
        }
        return people;
    }

    /// <summary>
    /// Prints all people with age-based color formatting
    /// </summary>
    /// <param name="people">List of people to display</param>
    static void PrintPeopleWithAgeHighlight(List<Person> people)
    {
        foreach (Person p in people)
        {
            int age = DateTime.Now.Year - p.BirthYear;
            if (age < 25)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(p.GetFullInfo());
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(p.GetFullInfo());
            }
        }
    }

    /// <summary>
    /// Processes student data including sorting and filtering
    /// </summary>
    /// <param name="people">List of people to process</param>
    static void ProcessStudentData(List<Person> people)
    {
        // Sort by surname using custom comparer
        people.Sort(new SurnameComparer());

        // Find students with unsatisfactory grades
        var studentsWithUnsat = people
            .OfType<Student>()
            .Where(s => s.SessionResults.Count(g => g <= 2) > 1)
            .OrderByDescending(s => s.BirthYear)
            .ToList();

        Console.WriteLine("\nStudents with more than one unsatisfactory grade (sorted by birth year descending):");
        foreach (var student in studentsWithUnsat)
        {
            Console.WriteLine(student.GetFullInfo());
        }

        Console.WriteLine("\nSorted surnames:");
        foreach (var person in people)
        {
            Console.WriteLine(person.Surname);
        }
    }

    /// <summary>
    /// Calculates and prints average teacher workload for a specific subject
    /// </summary>
    /// <param name="people">List of people containing teachers</param>
    static void PrintTeacherWorkloadStats(List<Person> people)
    {
        Console.Write("\nEnter subject index for workload average (starting from 0): ");
        if (int.TryParse(Console.ReadLine(), out int subjectIndex))
        {
            var teacherWorkloads = people.OfType<Teacher>()
                .Select(t => {
                    // Use reflection to access private field
                    var field = t.GetType().GetField("_workload",
                        BindingFlags.NonPublic | BindingFlags.Instance);
                    return field?.GetValue(t) as int[];
                })
                .Where(wl => wl != null && wl.Length > subjectIndex)
                .Select(wl => wl[subjectIndex]);

            if (teacherWorkloads.Any())
                Console.WriteLine($"Average workload for subject {subjectIndex}: {teacherWorkloads.Average():F2}");
            else
                Console.WriteLine("No data for the specified subject index.");
        }
    }
}