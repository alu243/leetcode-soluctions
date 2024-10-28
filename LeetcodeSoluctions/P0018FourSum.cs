using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetcodeSoluctions.P18;

public class Solution
{
    //https://leetcode.com/problems/3sum/description/
    // Solution 2 
    // 這類的不重複撿取，採用左右逼近
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        // 排序過有幾種效益
        // 答案的第一個值可以不重複
        // 可以用左右逼近的方式來算，降低複雜度
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();
        for (int i = 0; i < nums.Length - 3; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            for (int j = i + 1; j < nums.Length-2; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1]) continue;

                int k = j + 1;
                int l = nums.Length - 1;
                while (k < l)
                {
                    var total = (long)nums[i] + nums[j] + nums[k] + nums[l];
                    if (total > target)
                    {
                        l--;
                    }
                    else if (total < target)
                    {
                        k++;
                    }
                    else
                    {
                        result.Add(new List<int>() { nums[i], nums[j], nums[k], nums[l] });
                        k++;
                        while (nums[k] == nums[k - 1] && k < l) // 這個也很重要，這樣作就可以保證答案不重複
                        {
                            k++;
                        }
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
        var result = new Solution().FourSum(new int[] { 1000000000, 1000000000, 1000000000, 1000000000 }, -294967296);
        //ClassicAssert.AreEqual(2, result.Count);
        //result = new Solution().FourSum(new int[] { 0, 0, 0 });
        //ClassicAssert.AreEqual(1, result.Count);
        //result = new Solution().FourSum(new int[] { 0, 0, 0, 0 });
        //ClassicAssert.AreEqual(1, result.Count);
    }
}
