using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetcodeSoluctions.P21;

public class Solution
{
    //https://leetcode.com/problems/merge-two-sorted-lists/description/

    // Solution 用 Divide and Conquer(遞迴)
    // 遞迴的兩種想法：
    // 1 往上一步推進 (Divide and Conquer)
    // 2 往下一步推進 (backtracking)
    // 不用遞迴的話，可以考慮 DP (dynamic programming)
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;
        ListNode result = new ListNode();
        if (list1.val <= list2.val)
        {
            result = list1;
            result.next = MergeTwoLists(list1.next, list2);
        }
        else
        {
            result = list2;
            result.next = MergeTwoLists(list1, list2.next);
        }
        return result;
    }

    public ListNode MergeTwoLists2(ListNode list1, ListNode list2)
    {
        ListNode head = null;
        ListNode curr = null;
        ListNode prev = null;
        var curr1 = list1;
        var curr2 = list2;
        while (curr1 != null || curr2 != null)
        {
            prev = curr;

            if (curr1 == null)
            {
                curr = curr2;
                curr2 = curr2.next;
            }
            else if (curr2 == null)
            {
                curr = curr1;
                curr1 = curr1.next;
            }
            else if (curr1.val < curr2.val)
            {
                curr = curr1;
                curr1 = curr1.next;
            }
            else
            {
                curr = curr2;
                curr2 = curr2.next;
            }

            if (head == null)
            {
                head = curr;
            }

            if (prev == null)
            {
                prev = curr;
            }
            else
            {
                prev.next = curr;
            }
        }

        return head;
    }

    private ListNode GetNextNode(ListNode node)
    {
        return node.next;
    }
}

[TestFixture()]
public class Test
{
    [Test()]
    public void TestSolution()
    {
        var l1 = new ListNode(1, new ListNode(2, new ListNode(4)));
        var l2 = new ListNode(1, new ListNode(3, new ListNode(4)));
        ClassicAssert.AreEqual(4, new Solution().MergeTwoLists(l1, l2).next.next.next.next.next.val);

    }
}
