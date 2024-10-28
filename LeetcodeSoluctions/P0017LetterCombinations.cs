using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetcodeSoluctions.P17;

public class Solution
{
    //https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/
    // 速度夠快，但規則有點麻煩
    // todo: 未處理：試試用 backtracking 方式列舉

    public IList<string> LetterCombinations(string digits)
    {
        Dictionary<char, string> dic = new Dictionary<char, string>
        {
            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mon" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" }
        };

        List<string> result = new List<string>();
        for (int i = 0; i < digits.Length; i++)
        {
            if (i == 0)
            {
                for (int j = 0; j < dic[digits[i]].Length; j++)
                {
                    result.Add(dic[digits[i]][j].ToString());
                }
            }
            else
            {
                var len = dic[digits[i]].Length;
                var temp = result.ToList();
                for (int j = 1; j < dic[digits[i]].Length; j++)
                {
                    result.AddRange(temp.ToList());
                }

                for (int j = 0; j < result.Count; j++)
                {
                    var div = j / len;
                    result[(j * temp.Count + div) % result.Count] += (dic[digits[i]][j % len]);
                }
            }
        }

        var r = result.ToArray();
        Array.Sort(r);
        return r;
    }
}

[TestFixture()]
public class Test
{
    [Test()]
    public void TestSolution()
    {
        ClassicAssert.AreEqual(27, new Solution().LetterCombinations("234").Count);
        ClassicAssert.AreEqual(3, new Solution().LetterCombinations("2").Count);
        ClassicAssert.AreEqual(9, new Solution().LetterCombinations("23").Count);
        ClassicAssert.AreEqual(0, new Solution().LetterCombinations("").Count);
    }
}
