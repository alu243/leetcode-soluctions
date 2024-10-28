using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;
using System.Linq;

namespace LeetcodeSoluctions.P23;

public class Solution
{
    //https://leetcode.com/problems/merge-k-sorted-lists/

    // 參考 solution
    // Merge2List 請參考第21題
    // K 個List 就真的是 divide and conquer 了
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0) return null;

        return Merge(lists, 0, lists.Length - 1);
    }

    private ListNode Merge(ListNode[] lists, int left, int right)
    {
        if (left == right) return lists[left];

        int mid = left + (right - left) / 2;
        ListNode l1 = Merge(lists, left, mid);
        ListNode l2 = Merge(lists, mid + 1, right);

        return MergeTwoLists(l1, l2);
    }
    private ListNode MergeTwoLists(ListNode list1, ListNode list2)
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



    public ListNode MergeKLists2(ListNode[] lists)
    {
        ListNode head = null;
        ListNode curr = null;
        if (lists == null) return head;
        if (lists.Length == 0) return head;

        var items = new List<ListNode>();
        for (int i = 0; i < lists.Length; i++)
        {
            items.Add(lists[i]);
        }
        while (items.Any(item => item != null))
        {
            int min = int.MaxValue;
            int idx = -1;
            for (int i = 0; i < items.Count; i++)
            {
                if (min >= items[i]?.val)
                {
                    min = items[i].val;
                    idx = i;
                }
            }

            if (head == null)
            {
                head = items[idx];
                curr = items[idx];
            }
            else
            {
                curr.next = items[idx];
                curr = items[idx];
            }
            items[idx] = items[idx]?.next;
        }
        return head;
    }
}

[TestFixture()]
public class Test
{
    [Test()]
    public void TestSolution()
    {
        var list = new List<ListNode>()
        {
            new ListNode(1, new ListNode(4, new ListNode(5))),
            new ListNode(1, new ListNode(3, new ListNode(4))),
            new ListNode(2, new ListNode(6))
        };

        ClassicAssert.AreEqual(1, new Solution().MergeKLists(list.ToArray()).val);

    }
}
