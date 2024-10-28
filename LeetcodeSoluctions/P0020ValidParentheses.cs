using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;

namespace LeetcodeSoluctions.P20;

public class Solution
{
    //https://leetcode.com/problems/valid-parentheses/
    public bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();
        try
        {
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '{':
                    case '(':
                    case '[':
                        stack.Push(s[i]);
                        break;
                    case '}':
                        if (stack.Pop() != '{') return false;
                        break;
                    case ')':
                        if (stack.Pop() != '(') return false;
                        break;
                    case ']':
                        if (stack.Pop() != '[') return false;
                        break;
                    default:
                        return false;
                }
            }
            return stack.Count <= 0;
        }
        catch (InvalidOperationException e)
        {
            return false;
        }
    }
}

[TestFixture()]
public class Test
{
    [Test()]
    public void TestSolution()
    {
        ClassicAssert.AreEqual(false, new Solution().IsValid("}"));
    }
}
