namespace Leetsolu;

/// <summary>
/// Definition for singly-linked list.
/// </summary>
public class ListNode
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

    public override string? ToString()
    {
        return base.ToString();
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

public partial class Solution
{
    // todo : dicrease amount of memory usage
    /// <summary>
    /// Add Two Numbers: You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
    /// https://leetcode.com/problems/add-two-numbers/
    /// <para>Runtime: 85 ms, faster than 93.04% of C# online submissions for Add Two Numbers.</para>
    /// <para>Memory Usage: 49.2 MB, less than 6.00% of C# online submissions for Add Two Numbers.</para>
    /// </summary>
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
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
}