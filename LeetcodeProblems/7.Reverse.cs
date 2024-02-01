namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/reverse-integer/
/// </summary>
public class Reverse
{
    [Theory]
    [InlineData(123, 321)]
    [InlineData(-123, -321)]
    [InlineData(120, 21)]
    [InlineData(901000, 109)]
    [InlineData(1534236469, 0)]
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