using System.Text;

namespace Leetsolu;

public partial class Solution
{
    public string LongestPalindrome(string str)
    {
        static bool IsPolindrom(StringBuilder word)
        {
            if (word.Length == 1) return true;

            for (var i = 0; i < word.Length / 2; i++)
            {
                var charFromBeginning = word[i];
                var symmetricalChar = word[word.Length - 1 - i];

                if (charFromBeginning != symmetricalChar) return false;
            }

            return true;
        }

        var input = new StringBuilder(str);
        var result = new StringBuilder();

        for (var i = 0; i < input.Length; i++)
        {
            // shouldnt iterate full string if we already found the longest palindrom
            if (result.Length >= (input.Length - i)) break;

            var words = new HashSet<string>();
            var currentWord = new StringBuilder();

            for (var j = i; j < input.Length; j++)
            {
                currentWord.Append(input[j]);

                if (IsPolindrom(currentWord) && currentWord.Length > result.Length)
                    result = new StringBuilder(currentWord.ToString());
            }
        }

        return result.ToString();
    }
}
