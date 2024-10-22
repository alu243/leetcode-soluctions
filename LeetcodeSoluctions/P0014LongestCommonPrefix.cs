using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetcodeSoluctions.P14;

public class Solution
{
    //https://leetcode.com/problems/longest-common-prefix/
    public string LongestCommonPrefix(string[] strs)
    {
        var shortIdx = 0;
        for (int i = 1; i < strs.Length; i++)
        {
            if (strs[shortIdx].Length > strs[i].Length) shortIdx = i;
        }

        var len = 0;
        for (int i = 0; i < strs[shortIdx].Length; i++)
        {
            for (int j = 0; j < strs.Length; j++)
            {
                if (strs[j][i] != strs[shortIdx][i]) return strs[shortIdx].Substring(0, len);
            }
            len++;
        }

        return strs[shortIdx];
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