using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Calculator: ICalculator
    {
        private readonly MyArray _massivA;
        private readonly MyArray _massivB;
        private readonly int[] _combinedArray;

        public Calculator(MyArray massivA, MyArray massivB, int[] combinedArray)
        {
            _massivA = massivA;
            _massivB = massivB;
            _combinedArray = combinedArray;
        }

        public CalculationResults CalculateAll()
        {
            return new CalculationResults(
                CalculateSum(_massivA.Data),
                CalculateSum(_massivB.Data) * 2,
                CalculateSum(_combinedArray) / 2
            );
        }

        private static int CalculateSum(int[] data)
        {
            var arr = data;
            var firstPositiveIndex = Array.FindIndex(arr, x => x > 0);
            return firstPositiveIndex == -1
                ? 0
                : arr.Skip(firstPositiveIndex + 1).Where(x => x < 0).Sum();
        }
    }
}
