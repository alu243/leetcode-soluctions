using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetcodeSoluctions.P5;

public class Solution
{
    int maxLength = 1;
    int maxStart = 0;
    public string LongestPalindrome(string s)
    {
        for (int len = s.Length; len >= 2; len--)
        {
            var numbers = s.Length - len + 1;
            for (int start = 0; start < numbers; start++)
            {
                if (true == IsPalindromic(s, start, start + len - 1))
                {
                    maxLength = len;
                    maxStart = start;
                    return s.Substring(maxStart, maxLength);
                }
            }
        }
        return s.Substring(maxStart, maxLength);
    }

    private bool IsPalindromic(string s, int start, int end)
    {
        var len = end - start + 1;
        if (len <= maxLength) return false;
        for (int i = 0; i <= len / 2; i++)
        {
            if (s[i + start] != s[end - i])
            {
                return false;
            }
        }
        return true;
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
        var result = solution.LongestPalindrome("babad");
        ClassicAssert.AreEqual("bab", result);
    }
}