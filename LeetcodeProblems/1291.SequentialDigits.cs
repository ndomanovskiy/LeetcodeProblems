using System.Text;

namespace LeetcodeProblems;

public class SequentialDigits
{
    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[] { 100, 300, new[] { 123, 234 } },
        new object[] { 100, 1000000001, Array.Empty<int>() },
        new object[] { 100000000, 1000000000, new[] { 123456789 } },
        new object[] { 9, 1000, Array.Empty<int>() },
        new object[] { 100, 100, Array.Empty<int>() },
        new object[] { 1000, 13000, new[] { 1234, 2345, 3456, 4567, 5678, 6789, 12345 } },
        new object[] { 58, 155, new[] { 67, 78, 89, 123 } },
        new object[] { 234, 2314, new[] { 234, 345, 456, 567, 678, 789, 1234 } },
        new object[] { 8511, 23553, new[] { 12345, 23456 } },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int low, int high, IList<int> expected)
    {
        Assert.Equal(Method(low, high), expected);
    }

    private IList<int> Method(int low, int high)
    {
        if (low >= high || low < 10 || high > Math.Pow(10, 9)) return Array.Empty<int>();

        var lowString = low.ToString();
        var list = new List<int>();
        var first = (int)char.GetNumericValue(lowString[0]);

        var currentNumberLength = lowString.Length;

        while (true)
        {
            var sb = new StringBuilder(currentNumberLength);
            for (int i = 0, ss = first; i < currentNumberLength && ss <= 9; i++, sb.Append(ss++)) ;

            var result = int.Parse(sb.ToString());
            if (result > high) break;
            if (result >= low && result <= high) list.Add(result);
            if (result == 123456789) break;

            if (sb[^1] == '9')
            {
                currentNumberLength++;
                first = 1;
            }
            else first++;
        }

        return list;
    }
}