using System.Text;

namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/string-to-integer-atoi/
/// </summary>
public class MyAtoi
{
    [Theory]
    [InlineData("123", 123)]
    [InlineData("-42", -42)]
    [InlineData("   -42", -42)]
    [InlineData("4193 with words", 4193)]
    [InlineData("-91283472332", int.MinValue)]
    [InlineData("words and 987", 0)]
    [InlineData("3.14159", 3)]
    [InlineData("+-12", 0)]
    [InlineData("   +0 123", 0)]
    [InlineData("  +  413", 0)]
    public void Test(string s, int result)
    {
        Assert.Equal(result, Method(s));
    }

    private int Method(string s)
    {
        if (s is null || s.Length > 200) throw new ArgumentException(message: nameof(s));

        bool isNegative = false;
        bool signIsReaded = false;

        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if ((sb.Length > 0 || signIsReaded) && !char.IsDigit(s[i])) break;

            if (s[i] == '.') break;
            else if (char.IsLetter(s[i])) break;
            else if (char.IsWhiteSpace(s[i])) continue;
            else if (!signIsReaded && char.IsDigit(s[i])) signIsReaded = true;
            else if (signIsReaded && (s[i] == '+' || s[i] == '-')) break;

            if (!signIsReaded)
            {
                if (s[i] == '+') signIsReaded = true;
                else if (s[i] == '-') signIsReaded = isNegative = true;
                else break;

                continue;
            }

            sb.Append(s[i]);
        }

        if (sb.Length == 0) return 0;

        int result;

        try
        {
            unchecked
            {
                result = int.Parse(sb.ToString());
            }
        }
        catch
        {
            return isNegative ? int.MinValue : int.MaxValue;
        }

        if (result > 0 && isNegative)
            result *= -1;

        return result;
    }
}