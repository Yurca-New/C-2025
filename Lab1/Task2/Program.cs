using System;
using Task2;
using static System.Runtime.InteropServices.JavaScript.JSType;
List<SportsMan> sportsmans = new List<SportsMan>();

Console.WriteLine("Введите количество спорцменов");
int coutnSportsmans = 0;
for (int i = 0; i < 1;)
{
    if (int.TryParse(Console.ReadLine(),out coutnSportsmans) && coutnSportsmans > 0){
        i++;
    }
    else
    {
        Console.WriteLine("КОЛИЧЕСТВО ЭТО ТОЛЬКО ЦЕЛОЕ ПОЛОЖИТЕЛЬНОЕ ЧИСЛО");
    }
}
for (int i = 0; i < coutnSportsmans; i++)
{
    Console.WriteLine($"Ввудите фамилию спорцмена {i + 1}");
    string surname = Console.ReadLine();
    int birthYear = 0;
    for (int j = 0; j < 1;)
    {
        Console.WriteLine($"Ведите год рождения спорцмена {i + 1}");
        if (int.TryParse(Console.ReadLine(), out birthYear) && birthYear > 0)
        {
            j++;
        }
        else
        {
            Console.WriteLine("ГОД РОЖДЕНИЯ ЭТО ТОЛЬКО ЦЕЛОЕ ПОЛОЖИТЕЛЬНОЕ ЧИСЛО");
        }
    }
    int countResults = 0;
    for (int j = 0; j < 1;)
    {
        Console.WriteLine($"Введите количество результатов спорцмена {i + 1}");
        if (int.TryParse(Console.ReadLine(), out countResults) && countResults > 0)
        {
            j++;
        }
        else
        {
            Console.WriteLine("КОЛИЧЕСТВО ЭТО ТОЛЬКО ЦЕЛОЕ ПОЛОЖИТЕЛЬНОЕ ЧИСЛО");
        }
    }
    double[] results = new double[countResults];
    for (int j = 0; j < countResults; j++)
    {
        for (int z = 0; z < 1;)
        {
            Console.WriteLine($"Введите {j + 1} результат спорцмена {i + 1}");
            if (double.TryParse(Console.ReadLine(), out results[j]) && coutnSportsmans > 0)
            {
                z++;
            }
            else
            {
                Console.WriteLine("КОЛИЧЕСТВО ЭТО ТОЛЬКО ЦЕЛОЕ ПОЛОЖИТЕЛЬНОЕ ЧИСЛО");
            }
        }
    }
    Console.WriteLine("Фамилия: "+surname);
    Console.WriteLine("Год рождения: "+birthYear);
    Console.WriteLine("Результаты: "+string.Join("; ", results));
    sportsmans.Add(new SportsMan(surname, birthYear, results));
}

int minYear = sportsmans.Min(s => s.getBirthYear());
int maxYear = sportsmans.Max(s => s.getBirthYear());
for (; minYear <= maxYear + 1; minYear++)
{
    for (int i = 0; i < sportsmans.Count; i++)
    {

        if (sportsmans[i].getBirthYear() == minYear)
        {
            Console.WriteLine(sportsmans[i].resurnSportsman());
        }
    }
}
double minCount = 0;
int countSporstmanM = 0;
for (int j = 0; j < 1;)
{
    Console.WriteLine("Введите предел средних результатов");
    if (double.TryParse(Console.ReadLine(), out minCount) && minCount > 0)
    {
        j++;
    }
    else
    {
        Console.WriteLine("ПРЕДЕЛ СРЕДНИХ ЗНАЧЕНИЙ ЭТО ТОЛЬКО ПОЛОЖИТЕЛЬНОЕ ЧИСЛО");
    }
}
for (int i = 0; i < coutnSportsmans; i++)
{
    if (sportsmans[i].midleResult() > minCount)
    {
        countSporstmanM++;
    }
}
Console.WriteLine("Количество спорцменов в которых средний результат был больше заданого: " + countSporstmanM);

double minRange = 0;
double maxRange = 0;
for (int j = 0; j < 1;)
{
    Console.WriteLine("Введите минимальный предел диапазона результатов");
    if (double.TryParse(Console.ReadLine(), out minRange) && minRange > 0)
    {
        j++;
    }
    else
    {
        Console.WriteLine("МИНИМАЛЬНЫЙ ПРЕДЕЛ ДИАПАЗОНА ЭТО ТОЛЬКО ПОЛОЖИТЕЛЬНОЕ ЧИСЛО");
    }
}
for (int j = 0; j < 1;)
{
    Console.WriteLine("Введите максимальный предел диапазона результатов");
    if (double.TryParse(Console.ReadLine(), out maxRange) && maxRange > minRange)
    {
        j++;
    }
    else
    {
        Console.WriteLine("МАКСИМАЛЬНЫЙ ПРЕДЕЛ ДИАПАЗОНА ДОЛЖЕН БЫТЬ ПОЛОЖИТЕЛЬНОЕ ЧИСЛО БОЛЬШЕ МИНИМАЛЬНОГО ПРЕДЕЛА");
    }
}
List<SportsMan> listSportsmans = new List<SportsMan>();
for (int i = 0; i < coutnSportsmans; i++)
{
    if (sportsmans[i].midleResult() > minRange && sportsmans[i].midleResult() < maxRange)
    {
        listSportsmans.Add(sportsmans[i]);
    }
}
minYear = listSportsmans.Min(s => s.getBirthYear()); 
maxYear = listSportsmans.Max(s => s.getBirthYear());
for (; minYear <= maxYear + 1; minYear++)
{
    int f = 0;
    for (int i = 0; i < listSportsmans.Count; i++)
    {
        
        if (listSportsmans[i].getBirthYear() == minYear)
        {
            if (f == 0)
            {
                Console.WriteLine($"Год рождения: {minYear}");
                f++;
            }
            Console.WriteLine(listSportsmans[i].resurnSportsman());
        }
    }
}