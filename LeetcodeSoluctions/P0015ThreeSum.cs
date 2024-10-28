using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;

namespace LeetcodeSoluctions.P15;

public class Solution
{
    //https://leetcode.com/problems/3sum/description/
    // Solution 2 
    // 這類的不重複撿取，採用左右逼近
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        // 排序過有幾種效益
        // 答案的第一個值可以不重複
        // 可以用左右逼近的方式來算，降低複雜度
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int j = i + 1;
            int k = nums.Length - 1;
            while (j < k)
            {
                var target = nums[i] + nums[j] + nums[k];
                if (target > 0)
                {
                    k--;
                }
                else if (target < 0)
                {
                    j++;
                }
                else
                {
                    result.Add(new List<int>() { nums[i], nums[j], nums[k] });
                    j++;
                    while (nums[j] == nums[j - 1] && j < k) // 這個也很重要，這樣作就可以保證答案不重複
                    {
                        j++;
                    }
                }
            }
        }

        return result;
    }

    // 目前寫一半
    // 測試案例有一個有一堆 0，怎麼樣排除掉它是個問題
    public IList<IList<int>> ThreeSum2(int[] nums)
    {
        // 先排序，後面可以作重複
        Array.Sort(nums);
        Dictionary<int, int> dup = new Dictionary<int, int>();

        var candi = new Dictionary<int, List<(int, int, int, int)>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dup.ContainsKey(nums[i]))
            {
                dup[nums[i]]++;
            }
            else
            {
                dup.Add(nums[i], 1);
            }
            if (dup[nums[i]] > 2) continue;

            for (int j = i + 1; j < nums.Length; j++)
            {
                var target = 0 - nums[i] - nums[j];
                var tuple = (i, j, nums[i], nums[j]);
                if (!candi.ContainsKey(target))
                {
                    candi.Add(target, new List<(int, int, int, int)>() { tuple });
                }
                else
                {
                    candi[target].Add(tuple);
                }
            }
        }

        IList<IList<int>> result = new List<IList<int>>();
        var ans = new Dictionary<(int, int, int), bool>();
        dup = new Dictionary<int, int>();
        for (int k = 2; k < nums.Length; k++)
        {
            if (dup.ContainsKey(nums[k]))
            {
                dup[nums[k]]++;
            }
            else
            {
                dup.Add(nums[k], 1);
            }
            if (dup[nums[k]] > 3) continue;


            if (candi.ContainsKey(nums[k]))
            {
                foreach (var tp in candi[nums[k]])
                {
                    if (!ans.ContainsKey((tp.Item3, tp.Item4, nums[k]))
                        && k > tp.Item2)
                    {
                        result.Add(new List<int>() { tp.Item3, tp.Item4, nums[k] });
                        ans.Add((tp.Item3, tp.Item4, nums[k]), true);
                    }
                }
            }
        }
        return result;
    }
}

[TestFixture()]
public class Test
{
    [Test()]
    public void TestSolution()
    {
        var result = new Solution().ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
        ClassicAssert.AreEqual(2, result.Count);
        result = new Solution().ThreeSum(new int[] { 0, 0, 0 });
        ClassicAssert.AreEqual(1, result.Count);
        result = new Solution().ThreeSum(new int[] { 0, 0, 0, 0 });
        ClassicAssert.AreEqual(1, result.Count);
    }
}
