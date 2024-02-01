namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/palindrome-number/
/// </summary>
public class IsPalindrome
{
    [Theory]
    [InlineData(121, true)]
    [InlineData(-121, false)]
    [InlineData(10, false)]
    [InlineData(11, true)]
    [InlineData(223322, true)]
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