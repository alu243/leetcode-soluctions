using NUnit.Framework;

namespace LeetcodeSoluctions.P24;

public class Solution
{
    //https://leetcode.com/problems/swap-nodes-in-pairs/

    // 參考 solution
    // Merge2List 請參考第21題
    // N 個List 就真的是 divide and conquer
    public ListNode SwapPairs(ListNode head)
    {
        if (head == null || head.next == null) return head;
        var newHead = head.next;
        var curr = head;
        ListNode prev = null;
        while (curr != null && curr.next != null)
        {
            if (prev != null) prev.next = curr.next;
            Exchange(curr, curr.next);
            prev = curr;
            curr = curr.next;
        }

        return newHead;
    }

    private void Exchange(ListNode a, ListNode b)
    {
        if (a == null || b == null) return;
        a.next = b.next;
        b.next = a;
    }
}

[TestFixture()]
public class Test
{
    [Test()]
    public void TestSolution()
    {
        //var list = new List<ListNode>()
        //{
        //    new ListNode(1, new ListNode(4, new ListNode(5))),
        //    new ListNode(1, new ListNode(3, new ListNode(4))),
        //    new ListNode(2, new ListNode(6))
        //};

        //ClassicAssert.AreEqual(1, new Solution().MergeKLists(list.ToArray()).val);

    }
}
