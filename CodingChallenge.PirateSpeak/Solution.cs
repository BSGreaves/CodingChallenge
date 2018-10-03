using System;
using System.Linq;

namespace CodingChallenge.PirateSpeak
{
    public class Solution
    {
        // *** Note: I don't normally leave comments. 
        // In my opinion, clean code should be self documenting whenever possible.
        // These comments are for illustrating my thought patterns.

        public string[] GetPossibleWords(string jumble, string[] dictionary)
        {
            // when you can, scrub your inputs
            if (!IsValidInput(jumble) ||
                !InputHasValidDictionaryMatch(jumble, dictionary))
                return null;
            
            // basically, we're looking for anagrams
            // we can reason that any 2 words can be alphebetised and compared to see if they are anagrams
            var alphabetisedInput = GetAlphabetisedString(jumble);
            return dictionary.Where(word => string.Equals(GetAlphabetisedString(word), alphabetisedInput))
                             .ToArray();
        }

        // Is this function necessary? Probably not.
        // But it gives us a nice SRP unit-of-work,
        // and if we ever add more validation 
        // (pirate utterances can't contain numbers or punctuation, etc.)
        // then future devs know exactly where to place those new rules.
        bool IsValidInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        // Why use this function? The name is Self-documenting. 
        // Devs can skim the function name without trying to parse line after line of linq
        bool InputHasValidDictionaryMatch(string input, string[] dictionary)
        {
            return dictionary.Select(word => word.Length)
                             .Any(wordLength => wordLength == input.Length);
        }

        string GetAlphabetisedString(string input)
        {
            var inputChars = input.ToCharArray();
            Array.Sort<char>(inputChars);
            return new string(inputChars);
        }
    }
}