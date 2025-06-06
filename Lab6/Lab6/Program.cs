using Lab6;

List<Person> people = new List<Person>();
string[] lines = File.ReadAllLines("../../../people.txt");

foreach (var line in lines)
{
    var parts = line.Split(' ');
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
        int[] loads = parts.Skip(3).Select(int.Parse).ToArray();
        people.Add(new Teacher(surname, year, loads));
    }
    else
    {
        people.Add(new OtherPerson(surname, year, status));
    }
}

foreach (Person p in people)
{
    Console.WriteLine(p.GetFullInfo());
}