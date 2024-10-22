using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetcodeSoluctions.P5;

public class Solution
{
    //https://leetcode.com/problems/longest-palindromic-substring/
    // 從頭尾減回去可以有效減少重複計算次數
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
    [Test()]
    public void TestSolution()
    {
        var result = new Solution().LongestPalindrome("babad");
        ClassicAssert.AreEqual("bab", result);
    }
}