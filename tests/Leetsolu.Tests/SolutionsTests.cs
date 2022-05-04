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

    [Theory]
    [InlineData(123, 321)]
    [InlineData(-123, -321)]
    [InlineData(120, 21)]
    [InlineData(901000, 109)]
    [InlineData(1534236469, 0)]
    public void LC7ReverseInteger(int x, int result)
    {
        Assert.Equal(result, Solution.Reverse(x));
    }

    [Theory]
    [InlineData("123", 123)]
    [InlineData("-42", -42)]
    [InlineData("   -42", -42)]
    [InlineData("4193 with words", 4193)]
    [InlineData("-91283472332", int.MinValue)]
    [InlineData("words and 987", 0)]
    [InlineData("3.14159", 3)]
    [InlineData("+-12", 0)]
    [InlineData("   +0 123", 0)]
    [InlineData("  +  413", 0)]
    public void LC8StringtoInteger(string s, int result)
    {
        Assert.Equal(result, Solution.MyAtoi(s));
    }

    [Theory]
    [InlineData(121, true)]
    [InlineData(-121, false)]
    [InlineData(10, false)]
    [InlineData(11, true)]
    [InlineData(223322, true)]
    public void LC9PalindromeNumber(int x, bool result)
    {
        Assert.Equal(result, Solution.IsPalindrome(x));
    }
}
