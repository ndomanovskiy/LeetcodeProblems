namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/multiply-strings/description/
/// </summary>
public class MultiplyStrings
{
    [Theory]
    [InlineData("2", "3", "6")]
    [InlineData("0", "0", "0")]
    [InlineData("6", "0", "0")]
    [InlineData("3", "3", "9")]
    [InlineData("999", "999", "998001")]
    [InlineData("123", "456", "56088")]
    [InlineData("1234", "567", "699678")]
    [InlineData("567", "1234", "699678")]
    public void Test(string num1, string num2, string expected)
    {
        Assert.Equal(Method(num1, num2), expected);
    }

    private string Method(string num1, string num2)
    {
        var multiplicand = num1.Length >= num2.Length ? num1 : num2;
        var multiplier = num2.Length > num1.Length ? num1 : num2;
        var steps = multiplier.Length - 1;
        var results = new List<int[]>();

        var buffer = new int[multiplicand.Length + multiplier.Length];

        while (steps >= 0)
        {
            for (var i = 0; i < buffer.Length; buffer[i++] = 0) ;
            var index = buffer.Length - 1 - (multiplier.Length - 1 - steps);

            for (var i = multiplicand.Length - 1; i >= 0; i--, index--)
            {
                var a = char.GetNumericValue(multiplicand[i]);
                var b = char.GetNumericValue(multiplier[steps]);
                var c = buffer[index];
                var current = a * b + c;
                if (current >= 10) buffer[index - 1] = (int)current / 10;
                buffer[index] = (int)current % 10;
            }

            results.Add((int[])buffer.Clone());
            steps--;
        }

        for (var i = 0; i < buffer.Length; buffer[i++] = 0) ;
        for (var i = buffer.Length - 1; i >= 0; i--)
        {
            var sum = results.Select(x => x[i]).Sum() + buffer[i];
            if (sum >= 10) buffer[i - 1] = sum / 10;
            buffer[i] = sum % 10;
        }

        var answer = string.Concat(buffer).TrimStart('0');
        return string.IsNullOrEmpty(answer) ? "0" : answer;
    }
}