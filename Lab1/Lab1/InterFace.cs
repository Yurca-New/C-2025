using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1
{
    public interface IUserInterface
    {
        void ShowWelcomeMessage();
        void ShowMessage(string message);
        void ShowError(string message);
        void ShowArray(string name, int[] array);
        void ShowCalculationResults(CalculationResults result);
        void ShowFinalResult(double FinalResult);
        int GetPositiveIntInput(string prompt, string errorMessage);
        int GetIntInput(string prompt, string errorMessage);
    }

    internal interface IArrayOperator
    {
        int[] GetElementsAfterFirstMin(MyArray massiv);
        bool ShoudCombineWithArray(MyArray massiv, int elementsToTake);
        int[] GetElementsForCombination(MyArray massivA, int elementsToTake);
        int[] CombineArrays(int[] first, int[] second);
    }

    public interface ICalculator
    {
        CalculationResults CalculateAll();
    }
}
