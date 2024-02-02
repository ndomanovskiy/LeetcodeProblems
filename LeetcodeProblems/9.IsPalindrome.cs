namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/palindrome-number/
/// </summary>
public class IsPalindrome
{
    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[] { 121, true },
        new object[] { -121, false },
        new object[] { 10, false },
        new object[] { 11, true },
        new object[] { 223322, true },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int x, bool result)
    {
        Assert.Equal(result, Method(x));
    }

    private bool Method(int x)
    {
        var str = x.ToString();

        for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
        {
            if (str[i] != str[j]) return false;
        }

        return true;
    }
}