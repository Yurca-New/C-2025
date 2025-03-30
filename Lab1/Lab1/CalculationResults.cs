using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public record CalculationResults(int A, int B, int C)
    {
        public double FinalResult => (2 * Math.Sin(A) + 3 * B * Math.Pow(Math.Cos(C), 3)) / (A + B);
    }
}
