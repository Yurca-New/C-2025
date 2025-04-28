using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab4
{
    /// <summary>
    /// Provides methods to process sentences.
    /// </summary>
    internal class StringProcessor
    {
        /// <summary>
        /// Forms an array of strings containing the first two words
        /// from sentences that include numbers.
        /// </summary>
        /// <param name="text">The input text containing sentences.</param>
        /// <returns>An array of string with the first two words of matching sentences.</returns>
        public string[] GetFirstTwoWordsFromSentencesWithNumbers(string text)
        {
            List<string> result = new List<string>();
            string[] sentences = text.Split('.');
            foreach (string sentence in sentences)
            {
                string trimmedSentence = sentence.Trim();
                if (ContainsNumber(trimmedSentence))
                {
                    string[] words = trimmedSentence.Split(' ');
                    if (words.Length >= 2)
                    {
                        string firstTwoWords = $"{words[0]} {words[1]}";
                        result.Add(firstTwoWords);
                    }
                    else if (words.Length == 1)
                    {
                        result.Add(words[0]);
                    }
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Determines whether the specified text contains a number.
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <returns>True if the text contains a number; otherwise, false.</returns>
        private bool ContainsNumber(string text)
        {
            return Regex.IsMatch(text, @"\d");
        }
    }
}
