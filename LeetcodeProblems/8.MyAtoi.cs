using System.Text;

namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/string-to-integer-atoi/
/// </summary>
public class MyAtoi
{
    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[] { "123", 123 },
        new object[] { "-42", -42 },
        new object[] { "   -42", -42 },
        new object[] { "4193 with words", 4193 },
        new object[] { "-91283472332", int.MinValue },
        new object[] { "words and 987", 0 },
        new object[] { "3.14159", 3 },
        new object[] { "+-12", 0 },
        new object[] { "   +0 123", 0 },
        new object[] { "  +  413", 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
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