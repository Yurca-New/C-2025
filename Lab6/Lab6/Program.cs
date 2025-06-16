using Lab6;

List<Person> people = new List<Person>();
string[] lines = File.ReadAllLines("../../../people.txt");

foreach (var line in lines)
{
    var parts = line.Split(' ');
    if (parts.Length < 3)
    {
        Console.WriteLine($"Invalid line format: {line}");
    }
    else
    {
        string surname = parts[0];
        int year = int.Parse(parts[1]);
        string status = parts[2];

        if (status == "Student")
        {
            int[] grades = parts.Skip(3).Select(int.Parse).ToArray();
            people.Add(new Student(surname, year, grades));
        }
        else if (status == "Teacher")
        {
            int[] loads = new int[0];
            if (parts.Length > 4)
            {
                loads = parts.Skip(3).Select(int.Parse).ToArray();
            }
            people.Add(new Teacher(surname, year, loads));
        }
        else
        {
            people.Add(new OtherPerson(surname, year, status));
        }
    }
}
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

var sortedSurnames = people.Select(p => p.Surname).OrderBy(s => s).ToArray();
Console.WriteLine("\nSorted surnames:");
foreach (var surname in sortedSurnames)
{
    Console.WriteLine(surname);
}

Console.Write("\nEnter subject index for workload average (starting from 0): ");
if (int.TryParse(Console.ReadLine(), out int subjectIndex))
{
    var teacherWorkloads = people.OfType<Teacher>()
        .Select(t => t.GetType().GetField("_workload", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(t) as int[])
        .Where(wl => wl != null && wl.Length > subjectIndex)
        .Select(wl => wl[subjectIndex]);

    if (teacherWorkloads.Any())
        Console.WriteLine($"Average workload for subject {subjectIndex}: {teacherWorkloads.Average():F2}");
    else
        Console.WriteLine("No data for the specified subject index.");
}
