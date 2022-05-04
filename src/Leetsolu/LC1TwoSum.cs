namespace Leetsolu;

public partial class Solution
{
    /// <summary>
    /// Two Sum: Given an array of integers nums and an integer target,
    /// return indices of the two numbers such that they add up to target.
    /// 
    /// https://leetcode.com/problems/two-sum/
    /// <para>Runtime: 161 ms, faster than 82.88% of C# online submissions for Two Sum.</para>
    /// <para>Memory Usage: 44.2 MB, less than 21.66% of C# online submissions for Two Sum.</para>
    /// </summary>
    public static int[]? TwoSum(int[] nums, int target)
    {
        int i = 0;
        int j = 0;

        for (; i < nums.Length; i++)
        {
            for (j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return new[] { i, j };
            }
        }

        return default;
    }
}
