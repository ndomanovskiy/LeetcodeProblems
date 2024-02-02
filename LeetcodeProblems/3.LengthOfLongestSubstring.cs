namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/longest-substring-without-repeating-characters/
/// </summary>
public class LengthOfLongestSubstring
{
    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[] { "abcabcbb", 3 },
        new object[] { "bbbbb", 1 },
        new object[] { "pwwkew", 3 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
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