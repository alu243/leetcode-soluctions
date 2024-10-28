using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;

namespace LeetcodeSoluctions.P22;

public class Solution
{
    //https://leetcode.com/problems/generate-parentheses/

    // solution 的答案
    // 解題方向：
    // 遞迴解，上一層的方式就是至少各加一個 "(" and ")"，所以呼叫2次遞迴(why?)
    // 類似跑樹的方式去跑遞迴 (backtrack)， open 跟 close 的參數很重要
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        GenerateCombinations(result, "", 0, 0, n);
        return result;
    }

    private void GenerateCombinations(IList<string> result, string current, int open, int close, int max)
    {
        if (current.Length == max * 2)
        {
            result.Add(current);
            return;
        }

        if (open < max)
        {
            GenerateCombinations(result, current + "(", open + 1, close, max);
        }

        if (close < open)
        {
            GenerateCombinations(result, current + ")", open, close + 1, max);
        }
    }

    public IList<string> GenerateParenthesis2(int n)
    {
        Dictionary<string, bool> dup = new Dictionary<string, bool>();
        List<string> result = new List<string>();
        var list = new List<string>();
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                result.Add("()");
                dup.Add("()", true);
            }
            else
            {
                List<string> newResult = new List<string>();
                for (int j = 0; j < result.Count; j++)
                {
                    for (int k = 0; k < result[j].Length; k++)
                    {
                        var s = result[j];
                        var newS = s.Substring(0, k) + "()" + s.Substring(k, s.Length - k);
                        if (!dup.ContainsKey(newS))
                        {
                            newResult.Add(newS);
                            dup.Add(newS, true);

                        }
                    }
                }
                result = newResult;
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
        ClassicAssert.AreEqual(5, new Solution().GenerateParenthesis(3).Count);
        //ClassicAssert.AreEqual(4, new Solution().MergeTwoLists(l1, l2).next.next.next.next.next.val);

    }
}
