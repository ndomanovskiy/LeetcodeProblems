namespace Leetsolu;

public partial class Solution
{
    /// <summary>
    /// Longest Palindromic Substring: Given a string s, return the longest palindromic substring in s.
    /// https://leetcode.com/problems/longest-palindromic-substring/
    /// <para>Runtime: 204 ms, faster than 47.04% of C# online submissions for Longest Palindromic Substring.</para>
    /// <para>Memory Usage: 37.4 MB, less than 65.55% of C# online submissions for Longest Palindromic Substring.</para>
    /// </summary>
    public string LongestPalindrome(string str)
    {
        int resultStartIndex = 0;
        int resultLength = 0;

        int i = 0;
        int j = 0;

        int firstInSS = 0;
        int lastInSS = 0;

        bool @break = false;

        for (; i < str.Length; i++)
        {
            // shouldnt iterate full string if we already found the longest palindrom
            if (resultLength >= (str.Length - i)) break;

            for (j = i; j < str.Length; j++)
            {
                @break = false;

                for (firstInSS = i, lastInSS = j; firstInSS < lastInSS; firstInSS++, lastInSS--)
                {
                    if (str[firstInSS] != str[lastInSS])
                    {
                        @break = true;
                        break;
                    }
                }

                if (!@break && (j - i + 1) > resultLength)
                {
                    resultStartIndex = i;
                    resultLength = j - i + 1;
                }
            }
        }

        return str.Substring(resultStartIndex, resultLength);
    }
}
