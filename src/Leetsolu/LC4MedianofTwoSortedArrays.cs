namespace Leetsolu;

public partial class Solution
{
    /// <summary>
    /// Median of Two Sorted Arrays: Given two sorted arrays nums1 and nums2 of size m and n respectively,
    /// return the median of the two sorted arrays.
    /// 
    /// https://leetcode.com/problems/median-of-two-sorted-arrays/
    /// <para>Runtime: 148 ms, faster than 42.22% of C# online submissions for Median of Two Sorted Arrays.</para>
    /// <para>Memory Usage: 39.9 MB, less than 35.00% of C# online submissions for Median of Two Sorted Arrays.</para>
    /// </summary>
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
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
