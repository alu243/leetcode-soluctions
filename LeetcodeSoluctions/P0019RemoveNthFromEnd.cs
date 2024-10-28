using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;

namespace LeetcodeSoluctions.P19;

public class Solution
{
    //https://leetcode.com/problems/remove-nth-node-from-end-of-list/
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        if (n == 0) return head;

        var curr = head;
        var list = new List<ListNode>();
        while (curr != null)
        {
            list.Add(curr);
            curr = curr.next;
        }

        if (list.Count - n == 0) return head.next;

        //var remove = list[list.Count - n];
        //var prev = list[list.Count - n - 1];
        list[list.Count - n - 1].next = list[list.Count - n].next;
        return list[0];
    }

}

[TestFixture()]
public class Test
{
    [Test()]
    public void TestSolution()
    {
        var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
        ClassicAssert.AreEqual(3, new Solution().RemoveNthFromEnd(l1, 2).next.val);
        ClassicAssert.AreEqual(6, new Solution().RemoveNthFromEnd(l1, 1).next.val);
    }
}
