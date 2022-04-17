using Xunit;

namespace Leetsolu.Tests;

public class SolutionsTests
{
    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
    [InlineData(new[] { -3, 4, 3, 90 }, 0, new[] { 0, 2 })]
    [InlineData(new[] { -10, 7, 19, 15 }, 9, new[] { 0, 2 })]
    public void _1TwoSumTest(int[] nums, int target, int[] result)
    {
        var solutionFor = new Solution();
        Assert.Equal(result, solutionFor.TwoSum(nums, target));
    }

    [Theory]
    [InlineData(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
    [InlineData(new[] { 0 }, new[] { 0 }, new[] { 0 })]
    [InlineData(new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
    public void _2AddTwoNumbersTest(int[] l1, int[] l2, int[] result)
    {
        var solutionFor = new Solution();
        Assert.Equal((ListNode)result, solutionFor.AddTwoNumbers((ListNode)l1, (ListNode)l2));
    }

    [Theory]
    [InlineData("babad", "bab")]
    [InlineData("a", "a")]
    [InlineData("cbbd", "bb")]
    [InlineData("avsesv21212xxxoxxx", "xxxoxxx")]
    public void _5LongestPalindromeTest(string input, string result)
    {
        var solutionFor = new Solution();
        Assert.Equal(result, solutionFor.LongestPalindrome(input));
    }
}