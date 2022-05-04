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
    public void LC1TwoSumTest(int[] nums, int target, int[] result)
    {
        Assert.Equal(result, Solution.TwoSum(nums, target));
    }

    [Theory]
    [InlineData(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
    [InlineData(new[] { 0 }, new[] { 0 }, new[] { 0 })]
    [InlineData(new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
    public void LC2AddTwoNumbersTest(int[] l1, int[] l2, int[] result)
    {
        Assert.Equal((ListNode)result, Solution.AddTwoNumbers((ListNode)l1, (ListNode)l2));
    }

    [Theory]
    [InlineData("babad", "bab")]
    [InlineData("a", "a")]
    [InlineData("cbbd", "bb")]
    [InlineData("avsesv21212xxxoxxx", "xxxoxxx")]
    public void LC5LongestPalindromeTest(string input, string result)
    {
        Assert.Equal(result, Solution.LongestPalindrome(input));
    }

    [Theory]
    [InlineData(new[] { 1, 3 }, new[] { 2 }, 2)]
    [InlineData(new[] { 1, 2 }, new[] { 3, 4 }, 2.5)]
    [InlineData(new[] { 1, 3 }, new[] { 2, 7 }, 2.5)]
    public void LC4MedianofTwoSortedArraysTest(int[] nums1, int[] nums2, double result)
    {
        Assert.Equal(result, Solution.FindMedianSortedArrays(nums1, nums2));
    }

    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    public void LC3LongestSubstringWithoutRepeatingCharacters(string s, int result)
    {
        Assert.Equal(result, Solution.LengthOfLongestSubstring(s));
    }

    [Theory]
    [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [InlineData("a", 1, "a")]
    public void LC6ZigzagConversion(string s, int numRows, string result)
    {
        Assert.Equal(result, Solution.Convert(s, numRows));
    }
}
