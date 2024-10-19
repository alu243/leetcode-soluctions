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
        var result = solution.Convert("A", 1);
        ClassicAssert.AreEqual("A", result);
    }
}