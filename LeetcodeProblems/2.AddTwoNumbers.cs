namespace LeetcodeProblems;

/// <summary>
/// https://leetcode.com/problems/add-two-numbers/
/// </summary>
public class AddTwoNumbers
{
    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[] { new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 } },
        new object[] { new[] { 0 }, new[] { 0 }, new[] { 0 } },
        new object[] { new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 } },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] l1, int[] l2, int[] result)
    {
        Assert.Equal((ListNode)result, Method((ListNode)l1, (ListNode)l2));
    }

    private ListNode Method(ListNode l1, ListNode l2)
    {
        ListNode leftNumber = l1, rightNumber = l2;

        bool needAddOneRank = false;
        ListNode result = null!;
        ListNode root = null!;

        while (leftNumber != null || rightNumber != null)
        {
            var lastDigitOfFirstNumber = leftNumber != null ? leftNumber.val : 0;
            var lastDigitOfSecondNumber = rightNumber != null ? rightNumber.val : 0;
            var sumOfDigits = lastDigitOfFirstNumber + lastDigitOfSecondNumber + (needAddOneRank ? 1 : 0);

            needAddOneRank = sumOfDigits > 9;
            if (needAddOneRank)
                sumOfDigits -= 10;

            var newNode = new ListNode(sumOfDigits);

            if (root == null)
                root = newNode;
            else
                result!.next = newNode;

            result = newNode;

            if (leftNumber != null)
                leftNumber = leftNumber.next!;
            if (rightNumber != null)
                rightNumber = rightNumber.next!;
        }

        if (needAddOneRank)
            result.next = new ListNode(1);

        return root;
    }

    /// <summary>
    /// Definition for singly-linked list.
    /// </summary>
    internal class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int x) => val = x;

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            var @this = this;
            var other = (ListNode)obj;

            while (true)
            {
                if (@this == null && other == null) break;
                if (@this == null && other != null) return false;
                if (@this != null && other == null) return false;

                if (@this?.val != other?.val) return false;

                @this = @this?.next;
                other = other?.next;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static explicit operator ListNode(int[] nums)
        {
            var root = new ListNode(nums[0]);

            if (nums.Length > 1)
            {
                var iterator = new ListNode(nums[1]);
                root.next = iterator;
                for (var i = 2; i < nums.Length; i++)
                {
                    iterator.next = new ListNode(nums[i]);
                    iterator = iterator.next;
                }
            }

            return root;
        }
    }
}