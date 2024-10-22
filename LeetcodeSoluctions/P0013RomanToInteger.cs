using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetcodeSoluctions.P13;

public class Solution
{
    //https://leetcode.com/problems/roman-to-integer/
    // 思考的重點： 暴力解，但是用 tuple 這類的資料依序排下來會很好處理
    public int RomanToInt(string s)
    {
        var num = 0;
        var dic = new Dictionary<char, int>();
        dic['M'] = 1000;
        //dic["CM"] = 900;
        dic['D'] = 500;
        //dic["CD"] = 400;
        dic['C'] = 100;
        //dic["XC"] = 90;
        dic['L'] = 50;
        //dic["XL"] = 40;
        dic['X'] = 10;
        //dic["IX"] = 9;
        dic['V'] = 5;
        //dic["IV"] = 4;
        dic['I'] = 1;
        // M D L V
        // CM CD C
        // XC XL X
        // IX IV I
        int i = 0;
        for (i = 0; i < s.Length - 1; i++)
        {
            switch (s[i])
            {
                case 'C':
                    switch (s[i + 1])
                    {
                        case 'M':
                            num += 900;
                            i++;
                            break;
                        case 'D':
                            num += 400;
                            i++;
                            break;
                        default:
                            num += 100;
                            break;
                    }
                    break;
                case 'X':
                    switch (s[i + 1])
                    {
                        case 'C':
                            num += 90;
                            i++;
                            break;
                        case 'L':
                            num += 40;
                            i++;
                            break;
                        default:
                            num += 10;
                            break;
                    }
                    break;
                case 'I':
                    switch (s[i + 1])
                    {
                        case 'X':
                            num += 9;
                            i++;
                            break;
                        case 'V':
                            num += 4;
                            i++;
                            break;
                        default:
                            num += 1;
                            break;
                    }
                    break;
                default:
                    num += dic[s[i]];
                    break;
            }

        }

        if (i <= s.Length - 1) num += dic[s[s.Length - 1]];

        return num;
    }
}


[TestFixture()]
public class Test
{

    [Test()]
    public void TestSolution()
    {
        ClassicAssert.AreEqual(1994, new Solution().RomanToInt("MCMXCIV"));

    }
}