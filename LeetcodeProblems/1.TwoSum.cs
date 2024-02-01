namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/two-sum/description/
/// </summary>
public class TwoSum
{
    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
    [InlineData(new[] { -3, 4, 3, 90 }, 0, new[] { 0, 2 })]
    [InlineData(new[] { -10, 7, 19, 15 }, 9, new[] { 0, 2 })]
    public void Test(int[] nums, int target, int[] expected)
    {
        Assert.Equal(Method(nums, target), expected);
    }

    private int[]? Method(int[] nums, int target)
    {
        var i = 0;
        int j;

        for (; i < nums.Length; i++)
        {
            for (j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return [i, j];
            }
        }

        return null;
    }
}