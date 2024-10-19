﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using NUnit.Framework.Legacy;
using LeetcodeSoluctions.P2;

namespace LeetcodeSoluctions.P1;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, List<int>> ans = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            // 兩數相加的反向就是減掉1數等於另一個數，所以整排數字都是候選人(這樣就不用暴力法去解，只要找一次候選人就好)
            // 把值用 dictionary(hash) 的 key 當作計算，只需要 O(1) 的時間
            // 因為所有的值都是候選者，所以就算這次不是答案，那下一次就有可能是答案，用這樣的想法就不用第一次把 array 整個 load
            var subnum = target - nums[i];
            if (ans.ContainsKey(subnum))
            {
                var match = ans[subnum].FindIndex(d => d != i);
                if (match >= 0)
                {
                    return new int[2] { ans[subnum][match], i };
                }
            }
            if (ans.ContainsKey(nums[i]))
            {
                ans[nums[i]].Add(i);
            }
            else
            {
                var can = new List<int>();
                can.Add(i);
                ans.Add(nums[i], can);
            }
        }
        throw new Exception("No Answer");
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
        var nums = new int[] { 2, 7, 11, 15 };
        var target = 9;
        var result = solution.TwoSum(nums, 9);
        ClassicAssert.AreEqual(0, result[0]);
        ClassicAssert.AreEqual(1, result[1]);
    }
}