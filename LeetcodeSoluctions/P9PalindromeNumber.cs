using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Linq;
using System.Text;
using NUnit.Framework.Constraints;

namespace LeetcodeSoluctions.P9;

public class Solution
{
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
        ClassicAssert.AreEqual(true, solution.IsPalindrome(121));
        ClassicAssert.AreEqual(false, solution.IsPalindrome(-121));
        ClassicAssert.AreEqual(false, solution.IsPalindrome(10));
    }
}