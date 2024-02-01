using System.Text;

namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/zigzag-conversion/
/// </summary>
public class Convert
{
    [Theory]
    [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [InlineData("a", 1, "a")]
    public void Test(string s, int numRows, string result)
    {
        Assert.Equal(result, Method(s, numRows));
    }

    private string Method(string s, int numRows)
    {
        if (numRows == 1)
        {
            return s;
        }

        var arrays = new StringBuilder[numRows];

        for (var i = 0; i < arrays.Length; i++)
        {
            arrays[i] = new StringBuilder(s.Length / 2 + 1);
        }

        for (int i = 0; i < s.Length;)
        {
            for (int j = 0; j < arrays.Length && i < s.Length; j++, i++)
            {
                arrays[j].Append(s[i]);
            }

            if (arrays.Length > 2)
            {
                for (int k = 2; k <= arrays.Length - 1 && i < s.Length; k++, i++)
                {
                    arrays[^k].Append(s[i]);
                }
            }
        }

        return arrays.Aggregate((s1, s2) => s1.Append(s2)).ToString();
    }
}