using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetcodeSoluctions.P9;

public class Solution
{
    //https://leetcode.com/problems/palindrome-number/
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;
        if (x == 0) return true;
        return IsPalindromic(x.ToString());
    }

    private bool IsPalindromic(string s)
    {
        for (int i = 0; i <= s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - i - 1])
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
        ClassicAssert.AreEqual(true, new Solution().IsPalindrome(121));
        ClassicAssert.AreEqual(false, new Solution().IsPalindrome(-121));
        ClassicAssert.AreEqual(false, new Solution().IsPalindrome(10));
    }
}