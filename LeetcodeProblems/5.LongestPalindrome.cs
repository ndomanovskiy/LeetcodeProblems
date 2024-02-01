namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/longest-palindromic-substring/
/// </summary>
public class LongestPalindrome
{
    [Theory]
    [InlineData("babad", "bab")]
    [InlineData("a", "a")]
    [InlineData("cbbd", "bb")]
    [InlineData("avsesv21212xxxoxxx", "xxxoxxx")]
    public void Test(string input, string result)
    {
        Assert.Equal(result, Method(input));
    }

    private string Method(string str)
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