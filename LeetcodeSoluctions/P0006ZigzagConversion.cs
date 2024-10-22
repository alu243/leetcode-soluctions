using NUnit.Framework.Legacy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSoluctions.P6;

public class Solution
{
    //https://leetcode.com/problems/zigzag-conversion/
    // 最佳解~~~
    public string Convert(string s, int numRows)
    {
        if (numRows <= 1) return s;
        List<StringBuilder> r = new List<StringBuilder>();
        for (int i = 0; i < numRows; i++) r.Add(new StringBuilder());
        for (int i = 0; i < s.Length; i++)
        {
            var m = i % (numRows + numRows - 2);
            if (m >= numRows)
            {
                m = numRows + numRows - m - 2;
            }
            r[m].Append(s[i]);
        }

        for (int i = 1; i < numRows; i++)
        {
            r[0].Append(r[i]);
        }
        return r[0].ToString();
    }
}

[TestFixture()]
public class Test
{
    [Test()]
    public void TestSolution()
    {
        var result = new Solution().Convert("A", 1);
        ClassicAssert.AreEqual("A", result);
    }
}