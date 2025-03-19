using System.IO;
using System.Security;
using Task1;
const int v = 5;

Massiv A = new Massiv("A");
A.Input();
A.Output();
Massiv B = new Massiv("B");
B.Input();
B.Output();
var partB = B.Data.Skip(B.LeftMin() + 1);
var C = partB.ToArray();
if (A.RightMin() < v + 1)
{
    var partA = A.Data.Skip(A.RightMin() + 1).Take(v - (A.RightMin() + 1));
    C = partB.Concat(partA).ToArray();
}


Console.Write("Массив C: ");
Console.WriteLine(string.Join(", ", C));


int a = A.Data.Skip(Array.FindIndex(A.Data, x => x > 0) + 1).Where(x => x < 0).Sum();
int b = (B.Data.Skip(Array.FindIndex(B.Data, x => x > 0) + 1).Where(x => x < 0).Sum())*2;
int c = (C.Skip(Array.FindIndex(C, x => x > 0) + 1).Where(x => x < 0).Sum())/2;
Console.WriteLine($"a:{a}, b:{b}, c:{c}");

double result = (2 * Math.Sin(a) + 3 * b * Math.Pow(Math.Cos(c), 3)) / (a + b);
Console.WriteLine(result);