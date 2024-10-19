using NUnit.Framework.Legacy;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSoluctions.P3;
public class Solution
{

    // this is substring manupalte more important than compare char duplcate
    public int LengthOfLongestSubstring(string s)
    {
        if (s == null) throw new LeetCodeException("string cannot be null");
        if (s.Length > 5 * 10000) throw new LeetCodeException("string too long");

        int result = 0;
        var hash = new Queue<int>();
        foreach (int c in s)
        {
            queueChar(hash, c);
            result = result < hash.Count ? hash.Count : result;
        }
        result = result < hash.Count ? hash.Count : result;
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

    public int LengthOfLongestSubstring2(string s)
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

    private void addChar2(Dictionary<char, bool?> hash, char c)
    {
        bool result = hash.ContainsKey(c);
        while (result)
        {
            hash.Remove(hash.First().Key);
            result = hash.ContainsKey(c);
        }
        hash.Add(c, null);
    }

    private void queueChar(Queue<int> hash, int c)
    {
        bool result = hash.Contains(c);
        while (result)
        {
            hash.Dequeue();
            result = hash.Contains(c);
        }
        hash.Enqueue(c);
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
        var result = solution.LengthOfLongestSubstring("abcabcbb");
        ClassicAssert.AreEqual(3, result);
    }
}
