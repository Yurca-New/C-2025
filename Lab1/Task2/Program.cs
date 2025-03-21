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

for (int i = 0; i < coutnSportsmans; i++)
{
    Console.WriteLine($"Спорцмен {i + 1}: " + sportsmans[i].resurnSportsman());
}