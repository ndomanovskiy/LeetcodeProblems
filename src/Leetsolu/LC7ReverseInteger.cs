namespace Leetsolu;

public partial class Solution
{
    /// <summary>
    /// Reverse Integer: Given a signed 32-bit integer x, return x with its digits reversed.
    /// If reversing x causes the value to go outside the signed 32-bit integer range [-2^31, 2^31 - 1], then return 0.
    /// 
    /// Assume the environment does not allow you to store 64-bit integers (signed or unsigned).
    ///
    /// https://leetcode.com/problems/reverse-integer/
    /// <para>Runtime: 44 ms, faster than 22.43% of C# online submissions for Reverse Integer.</para>
    /// <para>Memory Usage: 27.1 MB, less than 17.78% of C# online submissions for Reverse Integer.</para>
    /// </summary>
    public static int Reverse(int x)
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
                };
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
