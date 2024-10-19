using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Linq;
using System.Text;

namespace LeetcodeSoluctions.P7;

public class Solution
{
    // 調速度的話，也要考慮 new class 的速度(有點偷雞)
    private StringBuilder reverse = new StringBuilder();
    public int Reverse(int x)
    {
        if (reverse.Length > 0) reverse.Length = 0;
        var xs = x.ToString();
        var isMinus = xs[0] == '-';

        var max = isMinus ? "2147483648" : "2147483647";
        var start = isMinus ? 1 : 0;
        var len = isMinus ? 11 : 10;

        for (int i = len; i > xs.Length; i--)
        {
            reverse.Append('0');
        }

        for (int i = xs.Length - 1; i >= start; i--)
        {
            reverse.Append(xs[i]);
        }

        var result = reverse.ToString();
        if (IsLargeThan(result, max))
        {
            return 0;
        }

        return isMinus ? -int.Parse(result) : int.Parse(result);
    }

    private bool IsLargeThan(string strA, string strB)
    {
        for (int i = 0; i < strA.Length; i++)
        {
            if (strA[i] > strB[i]) return true;
            if (strA[i] < strB[i]) return false;
        }
        return false;
    }

    // 比較慢
    public int Reverse2(int x)
    {
        var xs = x.ToString();
        var isMinus = xs[0] == '-';

        var reverse = new string(xs.Reverse().ToArray());
        try
        {
            return isMinus ? -int.Parse(reverse.TrimEnd('-')) : int.Parse(reverse);
        }
        catch
        {
            return 0;
        }

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
        ClassicAssert.AreEqual(2147483651, solution.Reverse(1563847412));
        ClassicAssert.AreEqual(321, solution.Reverse(123));
        ClassicAssert.AreEqual(-321, solution.Reverse(-123));
        ClassicAssert.AreEqual(0, solution.Reverse(1534236469));
        ClassicAssert.AreEqual(0, solution.Reverse(1563847412));
        ClassicAssert.AreEqual(0, solution.Reverse(-1563847412));
        ClassicAssert.AreEqual(-214748365, solution.Reverse(-563847412));



    }
}