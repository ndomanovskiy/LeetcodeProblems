namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/longest-substring-without-repeating-characters/
/// </summary>
public class LengthOfLongestSubstring
{
    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    public void Test(string s, int result) => Assert.Equal(result, Method(s));

    private int Method(string s)
    {
        var maxCount = 0;

        for (int i = 0; i < s.Length; i++)
        {
            var startIndex = i;
            var count = 0;
            var existCharsDictionary = new Dictionary<char, int>();
            for (var j = startIndex; j < s.Length; j++)
            {
                if (existCharsDictionary.ContainsKey(s[j]))
                    break;

                existCharsDictionary.Add(s[j], 1);
                count++;
            }

            if (count > maxCount)
                maxCount = count;

            existCharsDictionary.Clear();

            if (maxCount >= s.Length - i)
                break;
        }

        return maxCount;
    }
}