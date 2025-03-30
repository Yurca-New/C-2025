using Task1;

namespace Task1;

public class ArrayProcessingApp
{
    private readonly IArrayOperator _arrayOperator;
    private readonly IUserInterface _userInterface;
    private MyArray? _massivA;
    private MyArray? _massivB;
    private int[] _combinedArray = Array.Empty<int>();

    public ArrayProcessingApp()
    {
        _userInterface = new UserInterface();
        _arrayOperator = new ArrayOperation();
    }

    public void Run()
    {
        _userInterface.ShowWelcomeMessage();

        _massivA = ProcessArrayInput("A");
        _massivB = ProcessArrayInput("B");

        ProcessArraysCombination();
        CalculateAndShowResults();
    }

    private MyArray ProcessArrayInput(string arrayName)
    {
        var massiv = new MyArray(arrayName, _userInterface);
        massiv.InputElements();
        massiv.OutputElements();
        return massiv;
    }

    private void ProcessArraysCombination()
    {
        const int ElementsToTake = 5;

        var partB = _arrayOperator.GetElementsAfterFirstMin(_massivB!);
        _combinedArray = partB.ToArray();

        if (_arrayOperator.ShoudCombineWithArray(_massivA!, ElementsToTake))
        {
            var partA = _arrayOperator.GetElementsForCombination(_massivA!, ElementsToTake);
            _combinedArray = _arrayOperator.CombineArrays(partB, partA);
        }

        _userInterface.ShowArray("C", _combinedArray);
    }

    private void CalculateAndShowResults()
    {
        var calculator = new Calculator(_massivA!, _massivB!, _combinedArray);
        var results = calculator.CalculateAll();

        _userInterface.ShowCalculationResults(results);
        _userInterface.ShowFinalResult(results.FinalResult);
    }
}