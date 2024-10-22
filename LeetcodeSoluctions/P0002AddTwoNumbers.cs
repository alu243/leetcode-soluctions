using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;

namespace LeetcodeSoluctions.P2;

public class Solution
{
    //https://leetcode.com/problems/add-two-numbers/
    // 訓練 linked list 的用法

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var result = l1;
        ListNode prev = null;
        int i = 0;

        int moreThan9 = 0;
        while (l1 != null || l2 != null)
        {
            #region 限制條件判斷
            i++;
            if (i > 100) throw new LeetCodeException("list too long");
            if (i > 1 && l1 != null && l1.next == null && l1.val == 0) throw new LeetCodeException("list 1 leading zero");
            if (i > 1 && l2 != null && l2.next == null && l2.val == 0) throw new LeetCodeException("list 2 leading zero");
            this.NumberConstraint(l1);
            this.NumberConstraint(l2);
            #endregion

            if (l1 == null)
            {
                l1 = new ListNode(0, null);
                if (prev != null) prev.next = l1;
            }

            l1.val += (l2?.val ?? 0) + moreThan9;
            if (l1.val > 9)
            {
                l1.val -= 10;
                moreThan9 = 1;
            }
            else
            {
                moreThan9 = 0;
            }

            prev = l1;
            l1 = l1?.next;
            l2 = l2?.next;
        }
        if (moreThan9 == 1) prev.next = new ListNode(1, null);
        if (result == null) throw new LeetCodeException("no values");
        return result;
    }

    public ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
    {
        var result = new ListNode();
        ListNode prev = null;
        int i = 0;

        int moreThan9 = 0;
        while (l1 != null || l2 != null)
        {
            i++;
            if (i > 100) throw new LeetCodeException("list too long");
            if (i > 1 && l1 != null && l1.next == null && l1.val == 0) throw new LeetCodeException("list 1 leading zero");
            if (i > 1 && l2 != null && l2.next == null && l2.val == 0) throw new LeetCodeException("list 2 leading zero");

            this.NumberConstraint(l1);
            this.NumberConstraint(l2);

            var l1v = l1?.val ?? 0;
            var l2v = l2?.val ?? 0;

            var twoSum = new ListNode(l1v + l2v + moreThan9, null);
            moreThan9 = twoSum.val > 9 ? 1 : 0;
            if (moreThan9 == 1)
            {
                twoSum.val -= 10;
            }

            if (prev == null)
            {
                result = twoSum;
            }
            else
            {
                prev.next = twoSum;
            }
            prev = twoSum;

            l1 = l1?.next;
            l2 = l2?.next;
        }
        if (moreThan9 == 1) prev.next = new ListNode(1, null);
        if (result == null) throw new LeetCodeException("no values");
        return result;
    }

    private void NumberConstraint(ListNode num)
    {
        if (num == null) return;
        if (num.val < 0 || num.val > 9) throw new LeetCodeException("target too large or too small");
    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

[TestFixture()]
public class Test
{
    private Solution solution;

    [SetUp]
    public void Setup()
    {
        // 在每個測試之前都初始化一個 Calculator 對象
        solution = new Solution();
    }

    [Test()]
    public void TestSolution()
    {
        var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
        var result = solution.AddTwoNumbers(l1, l2);
        ClassicAssert.AreEqual(7, result.val);
        ClassicAssert.AreEqual(0, result.next.val);
        ClassicAssert.AreEqual(8, result.next.next.val);
    }
}