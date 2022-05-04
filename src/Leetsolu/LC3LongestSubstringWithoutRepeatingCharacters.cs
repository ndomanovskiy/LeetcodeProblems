namespace Leetsolu;

public partial class Solution
{
    /// <summary>
    /// Longest Substring Without Repeating Characters: Given a string s,
    /// find the length of the longest substring without repeating characters.
    /// 
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
    /// <para>Runtime: 295 ms, faster than 8.19% of C# online submissions for Longest Substring Without Repeating Characters.</para>
    /// <para>Memory Usage: 36.7 MB, less than 93.54% of C# online submissions for Longest Substring Without Repeating Characters.</para>
    /// </summary>
    public static int LengthOfLongestSubstring(string s)
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
