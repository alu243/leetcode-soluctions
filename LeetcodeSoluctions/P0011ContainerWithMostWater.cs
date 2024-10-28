using NUnit.Framework;
using System;

namespace LeetcodeSoluctions.P11;

public class Solution
{
    // https://leetcode.com/problems/container-with-most-water/
    // 思考的重點： O(n^2) 是暴力解
    // 但是題目可以限制成 O(n)
    // 思考方向：往最高點跑(為什麼？)(左右逼近法)
    // 應該是圖學的問題

    // 正解
    public int MaxArea(int[] height)
    {
        int left = 0, right = height.Length - 1, maxArea = 0;
        while (left < right)
        {
            maxArea = Math.Max(maxArea, (right - left) * Math.Min(height[left], height[right]));
            if (height[left] < height[right]) left++;
            else right--;
        }
        return maxArea;
    }

    public int MaxArea2(int[] height)
    {
        var max = 0;
        for (int i = 0; i < height.Length; i++)
        {
            for (int j = i + 1; j < height.Length; j++)
            {
                max = Math.Max(max, Math.Min(height[i], height[j]));
            }
        }
        return max;
    }
}


[TestFixture()]
public class Test
{

    [Test()]
    public void TestSolution()
    {

    }
}