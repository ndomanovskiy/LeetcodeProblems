namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/median-of-two-sorted-arrays/
/// </summary>
public class FindMedianSortedArrays
{
    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[] { new[] { 1, 3 }, new[] { 2 }, 2 },
        new object[] { new[] { 1, 2 }, new[] { 3, 4 }, 2.5 },
        new object[] { new[] { 1, 3 }, new[] { 2, 7 }, 2.5 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
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