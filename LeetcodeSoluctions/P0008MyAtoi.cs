using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetcodeSoluctions.P8;

public class Solution
{
    //https://leetcode.com/problems/string-to-integer-atoi/
    // 速度最佳解
    public int MyAtoi(string s)
    {
        bool isMinus = false;
        long result = 0;
        bool isLeading = false;

        for (int i = 0; i < s.Length; i++)
        {
            var type = LegalType(s[i]);

            if (type == -1) break;

            if (isLeading == false)
            {
                if (type == -2)
                {
                    isMinus = true;
                    isLeading = true;
                }
                else if (type == -3)
                {
                    isMinus = false;
                    isLeading = true;
                }
                else if (type >= 0)
                {
                    result = isMinus ? -type : type;
                    isLeading = true;
                }
            }
            else
            {
                if (type < 0) break;
                result = result * 10 + (isMinus ? -type : type);
                if (result >= int.MaxValue) return int.MaxValue;
                if (result <= int.MinValue) return int.MinValue;
            }
        }
        return (int)result;
    }

    private int LegalType(char c)
    {
        // -4  is space
        // -3  is +
        // -2  is -
        // -1  is illegal
        //  0  is 0, 
        //  1  is 1-9,
        switch (c)
        {
            case '0':
                return 0;
            case '1':
                return 1;
            case '2':
                return 2;
            case '3':
                return 3;
            case '4':
                return 4;
            case '5':
                return 5;
            case '6':
                return 6;
            case '7':
                return 7;
            case '8':
                return 8;
            case '9':
                return 9;
            case ' ':
                return -4;
            case '+':
                return -3;
            case '-':
                return -2;
            default:
                return -1;
        }
    }
}

[TestFixture()]
public class Test
{
    [Test()]
    public void TestSolution()
    {
        ClassicAssert.AreEqual(0, new Solution().MyAtoi("0-1"));
        ClassicAssert.AreEqual(42, new Solution().MyAtoi("42"));
        ClassicAssert.AreEqual(int.MaxValue, new Solution().MyAtoi("2147483651"));
        ClassicAssert.AreEqual(321, new Solution().MyAtoi("321"));
        ClassicAssert.AreEqual(-321, new Solution().MyAtoi("-321"));
        //ClassicAssert.AreEqual(-214748365, solution.Reverse(-563847412));
    }
}