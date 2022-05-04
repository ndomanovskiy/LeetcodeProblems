using System.Text;

namespace Leetsolu;

public partial class Solution
{
    /// <summary>
    /// Zigzag Conversion: The string "PAYPALISHIRING" is written in a zigzag pattern on
    /// a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility).
    /// P   A   H   N
    /// A P L S I I G
    /// Y   I   R
    /// And then read line by line: "PAHNAPLSIIGYIR"
    /// Write the code that will take a string and make this conversion given a number of rows.
    ///
    /// https://leetcode.com/problems/zigzag-conversion/
    /// <para>Runtime: 119 ms, faster than 50.98% of C# online submissions for Zigzag Conversion.</para>
    /// <para>Memory Usage: 42.6 MB, less than 23.28% of C# online submissions for Zigzag Conversion.</para>
    /// </summary>
    public static string Convert(string s, int numRows)
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
