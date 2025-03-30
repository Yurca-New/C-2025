using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task1.ArrayOperation;
using Task1;

namespace Task1
{
    internal class ArrayOperation: IArrayOperator
    {
        public int[] GetElementsAfterFirstMin(MyArray massiv) =>
            massiv.Data.Skip(massiv.GetFirstMinIndex() + 1).ToArray();

        public bool ShoudCombineWithArray(MyArray massiv, int elementsToTake) =>
            massiv.GetLastMinIndex() < elementsToTake + 1;

        public int[] GetElementsForCombination(MyArray massiv, int elementsToTake)
        {
            var skipCount = massiv.GetLastMinIndex() + 1;
            return massiv.Data.Skip(skipCount).Take(elementsToTake - skipCount).ToArray();
        }

        public int[] CombineArrays(int[] first, int[] second) =>
            first.Concat(second).ToArray();
    }
}
