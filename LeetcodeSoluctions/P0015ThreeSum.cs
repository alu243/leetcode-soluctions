using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using NUnit.Framework.Constraints;
using NUnit.Framework.Legacy;

namespace LeetcodeSoluctions.P15;

public class Solution
{
    //https://leetcode.com/problems/3sum/description/
    // 目前寫一半
    // 測試案例有一個有一堆 0，怎麼樣排除掉它是個問題
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        // 先排序，後面可以作重複
        Array.Sort(nums);
        List<List<int>> result = new List<List<int>>();
        Dictionary<int, Dictionary<(int, int), (int, int)>> candi = new Dictionary<int, Dictionary<(int, int), (int, int)>>();
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                var target = 0 - nums[i] - nums[j];
                var tuple = (i, j);
                var tuple2 = (nums[i], nums[j]);
                if (!candi.ContainsKey(target))
                {
                    var l = new Dictionary<(int, int), (int, int)>();
                    l.Add(tuple2, tuple);
                    candi.Add(target, l);
                }
                else if(!candi[target].ContainsKey(tuple2))
                {
                    candi[target].Add(tuple2, tuple);
                }
            }
        }

        Dictionary<(int, int, int), IList<int>> realAns = new Dictionary<(int, int, int), IList<int>>();
        for (int k = 2; k < nums.Length; k++)
        {
            if (candi.ContainsKey(nums[k]))
            {
                foreach (var tp in candi[nums[k]])
                {
                    if (!realAns.ContainsKey((tp.Key.Item1, tp.Key.Item2, nums[k]))
                        && k > tp.Value.Item1 && k > tp.Value.Item2)
                    {
                        realAns.Add((tp.Key.Item1, tp.Key.Item2, nums[k]), new List<int>() { tp.Key.Item1, tp.Key.Item2, nums[k] });
                    }
                }
            }
        }

        return realAns.Values.ToList();
    }
}

[TestFixture()]
public class Test
{
    [Test()]
    public void TestSolution()
    {
        //ClassicAssert.AreEqual(1994, new Solution().LongestCommonPrefix("MCMXCIV"));
    }
}
