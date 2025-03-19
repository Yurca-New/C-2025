using Task2;
List<SportsMan> sportsmans = new List<SportsMan>();

Console.WriteLine("");
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
Console.WriteLine(coutnSportsmans);