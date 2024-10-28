using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;

namespace LeetcodeSoluctions.P16;

public class Solution
{
    //https://leetcode.com/problems/3sum-closest/
    public int ThreeSumClosest(int[] nums, int target)
    {
        var diff = int.MaxValue;
        var ans = int.MaxValue;

        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int j = i + 1;
            int k = nums.Length - 1;
            while (j < k)
            {
                var total = nums[i] + nums[j] + nums[k];
                if (total > target)
                {
                    if (diff > Math.Abs(target - total))
                    {
                        diff = Math.Abs(target - total);
                        ans = total;
                    }
                    k--;
                }
                else if (total < target)
                {
                    if (diff > Math.Abs(target - total))
                    {
                        diff = Math.Abs(target - total);
                        ans = total;
                    }
                    j++;
                }
                else
                {
                    return target;
                }
            }
        }

        return ans;
    }
}

[TestFixture()]
public class Test
{
    [Test()]
    public void TestSolution()
    {
        ClassicAssert.AreEqual(2, new Solution().ThreeSumClosest(new int[] { -1, 2, 1, -4 }, 1));
        ClassicAssert.AreEqual(0, new Solution().ThreeSumClosest(new int[] { 0, 0, 0 }, 1));
    }
}
