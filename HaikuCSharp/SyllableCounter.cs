using System.Text.RegularExpressions;

namespace HaikuCSharp
{
    internal static class SyllableCounter
    {
        /// <summary>
        /// Get syllables for a line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        internal static int GetSyllablesPerLine(string line)
        {
            // split into words
            var words = line.Trim().ToLower().Split(' ');

            // get syllables for each word (removing non letters) and return total
            int syllables = 0;
            foreach (var word in words)
            {
                Regex rgx = new Regex("[^a-z]");
                var wordLettersOnly = rgx.Replace(word, "");
                syllables += GetSyllablesPerWord(wordLettersOnly);
            }

            return syllables;
        }

        /// <summary>
        /// Get syllables for a word
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private static int GetSyllablesPerWord(string word)
        {
            int syllables = 0;

            // iterate through each character to check for traditional vowels
            for (int i = 0; i < word.Length; i++)
            {
                // if it is a vowel, this is a syllable (except for cases in nested if statements)
                if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u')
                {
                    // If the current letter is a vowel and the next letter is a vowel (or the next letter is an ending y ie key), don't count the syllable and continue 
                    if (i < word.Length - 1 && 
                        (word[i+1] == 'a' || word[i+1] == 'e' || word[i+1] == 'i' || word[i+1] == 'o' || word[i+1] == 'u' || (i == word.Length - 2 && word[i+1] == 'y')))
                    {
                        continue;
                    }

                    // if the word ends in e and has another vowel, the e is silent and not a vowel (ie home)
                    if (i == word.Length - 1 && word[i] == 'e' && syllables > 0)
                    {
                        continue;
                    }

                    syllables++;
                }
            }

            // if the last letter is y, that is a vowel
            if (word[word.Length - 1] == 'y')
            {
                syllables++;
            }

            // throw exception if no syllables found
            if (syllables <= 0)
            {
                throw new Exception($"Error: Got {syllables} syllables for the word {word}");
            }

            return syllables;
        }
    }
}
