using Lab4;

StringProcessor processor = new StringProcessor();
Console.WriteLine("Enter the text:");
string inputText = Console.ReadLine();
string[] result = processor.GetFirstTwoWordsFromSentencesWithNumbers(inputText);
Console.WriteLine("First two words from sentences containing numbers:");
foreach (string item in result)
{
    Console.WriteLine(item);
}