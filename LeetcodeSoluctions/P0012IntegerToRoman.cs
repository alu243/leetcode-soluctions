using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSoluctions.P12;

public class Solution
{
    //https://leetcode.com/problems/integer-to-roman/
    // 思考的重點： 暴力解，但是用 tuple 這類的資料依序排下來會很好處理
    public string IntToRoman(int num)
    {
        //I   1
        //V   5
        //X   10
        //L   50
        //C   100
        //D   500
        //M   1000
        StringBuilder sb = new StringBuilder();
        var dic = new Dictionary<int, string>();
        dic[1000] = "M";
        dic[900] = "CM";
        dic[500] = "D";
        dic[400] = "CD";
        dic[100] = "C";
        dic[90] = "XC";
        dic[50] = "L";
        dic[40] = "XL";
        dic[10] = "X";
        dic[9] = "IX";
        dic[5] = "V";
        dic[4] = "IV";
        dic[1] = "I";

        foreach (var item in dic)
        {
            var div = num / item.Key;
            for (int i = 0; i < div; i++)
            {
                sb.Append(item.Value);
            }

            num = num % item.Key;
            if (num == 0) break;
        }

        return sb.ToString();
    }
}


[TestFixture()]
public class Test
{

    [Test()]
    public void TestSolution()
    {
        //ClassicAssert.AreEqual(true, new Solution().IntToRoman("a", "a*a"));

    }
}