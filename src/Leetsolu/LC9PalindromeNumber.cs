namespace Leetsolu;

public partial class Solution
{
    /// <summary>
    /// Palindrome Number: Given an integer x, return true if x is palindrome integer.
    /// An integer is a palindrome when it reads the same backward as forward.
    /// For example, 121 is a palindrome while 123 is not.
    /// 
    /// https://leetcode.com/problems/palindrome-number/
    /// 
    /// <para>Runtime: 81 ms, faster than 21.72% of C# online submissions for Palindrome Number.</para>
    /// <para>Memory Usage: 27.8 MB, less than 98.29% of C# online submissions for Palindrome Number.</para>
    /// </summary>
    public static bool IsPalindrome(int x)
    {
        var str = x.ToString();

        for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
        {
            if (str[i] != str[j]) return false;
        }

        return true;
    }
}
