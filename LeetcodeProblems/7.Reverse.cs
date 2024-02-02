namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/reverse-integer/
/// </summary>
public class Reverse
{
    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[] { 123, 321 },
        new object[] { -123, -321 },
        new object[] { 120, 21 },
        new object[] { 901000, 109 },
        new object[] { 1534236469, 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int x, int result)
    {
        Assert.Equal(result, Method(x));
    }

    private int Method(int x)
    {
        if (x == 0) return x;

        int y = 0;
        bool isNegative = x < 0;

        while (true)
        {
            var _x = Math.Abs(x % 10);

            if (y + _x >= int.MaxValue)
                return 0;

            y += _x;

            x /= 10;

            if (x == 0)
                break;

            try
            {
                checked
                {
                    y *= 10;
                }
            }
            catch
            {
                return 0;
            }
        }

        if (y > 0 && isNegative)
            y *= -1;

        return y;
    }
}