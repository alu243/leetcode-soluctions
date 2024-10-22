using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace LeetcodeSoluctions.P3;
public class Solution
{
    // https://leetcode.com/problems/longest-substring-without-repeating-characters/
    // this is substring manupalte more important than compare char duplcate
    // 解法：用 queue 判斷是否重複字串
    public int LengthOfLongestSubstring(string s)
    {
        if (s == null) throw new LeetCodeException("string cannot be null");
        if (s.Length > 5 * 10000) throw new LeetCodeException("string too long");

        int result = 0;
        var hash = new Queue<int>();
        foreach (int c in s)
        {
            queueChar(hash, c);
            result = Math.Max(result, hash.Count);
        }
        result = Math.Max(result, hash.Count);
        return result;
    }


    public int LengthOfLongestSubstring3(string s)
    {
        if (s == null) throw new LeetCodeException("string cannot be null");
        if (s.Length > 5 * 10000) throw new LeetCodeException("string too long");

        int result = 0;
        var hash = new HashSet<char>();
        for (int i = s.Length - 1; i >= 0; i--)
        {
            for (int j = i; j >= 0; j--)
            {
                var c = (char)s[j];
                if (false == hash.Add(c))
                {
                    result = result < hash.Count ? hash.Count : result;
                    hash.Clear();
                    break;
                }
            }
        }
        result = result < hash.Count ? hash.Count : result;
        return result;
    }



    private void queueChar(Queue<int> queue, int c)
    {
        while (queue.Contains(c))
        {
            queue.Dequeue();
        }
        queue.Enqueue(c);
    }
}

public class Solution2
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s == null) throw new LeetCodeException("string cannot be null");
        if (s.Length > 5 * 10000) throw new LeetCodeException("string too long");

        int result = 0;
        var hash = new OrderedDictionary();
        foreach (char c in s)
        {
            addChar(hash, c);
            result = result < hash.Count ? hash.Count : result;
        }
        return result;
    }

    private void addChar(OrderedDictionary hash, char c)
    {
        bool result = hash.Contains(c);
        while (result)
        {
            hash.RemoveAt(0);
            result = hash.Contains(c);
        }
        hash.Add(c, null);
    }

}


[TestFixture()]
public class Test
{
    [Test()]
    public void TestSolution()
    {
        var result = new Solution().LengthOfLongestSubstring("abcabcbb");
        ClassicAssert.AreEqual(3, result);
    }
}
