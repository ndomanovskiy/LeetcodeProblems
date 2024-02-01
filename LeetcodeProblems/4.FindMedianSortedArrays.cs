namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/median-of-two-sorted-arrays/
/// </summary>
public class FindMedianSortedArrays
{
    [Theory]
    [InlineData(new[] { 1, 3 }, new[] { 2 }, 2)]
    [InlineData(new[] { 1, 2 }, new[] { 3, 4 }, 2.5)]
    [InlineData(new[] { 1, 3 }, new[] { 2, 7 }, 2.5)]
    public void Test(int[] nums1, int[] nums2, double result)
    {
        Assert.Equal(result, Method(nums1, nums2));
    }

    private double Method(int[] nums1, int[] nums2)
    {
        static double GetAverage(int one, int two)
        {
            return (double)(one + two) / 2;
        }

        if (nums1.Length == nums2.Length && nums1[^1] <= nums2[0])
        {
            return GetAverage(nums1[^1], nums2[0]);
        }

        var overallLenth = nums1.Length + nums2.Length;
        var middle = overallLenth / 2;

        var list = new List<int>(overallLenth);
        list.AddRange(nums1);
        list.AddRange(nums2);
        list.Sort();

        if (overallLenth % 2 == 0)
            return GetAverage(list[middle - 1], list[middle]);

        return list[middle];
    }
}