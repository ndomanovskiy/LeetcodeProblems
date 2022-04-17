using Xunit;

namespace Leetsolu.Tests;

public class MediumProblemsSolutionTests
{
    [Theory]
    [InlineData("babad", "bab")]
    [InlineData("a", "a")]
    [InlineData("cbbd", "bb")]
    public void Five_LongestPalindromicSubstringTest(string input, string result)
    {
        var solutionFor = new Solution();
        Assert.Equal(solutionFor.LongestPalindrome(input), result);
    }
}