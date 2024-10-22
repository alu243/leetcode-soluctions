using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Linq;
using System.Text;
using NUnit.Framework.Constraints;

namespace LeetcodeSoluctions.P10;

public class Solution
{
    // 重點在 * 的規則
    // 1 原字串比完後還要看有沒有 *，有就一路讀到 * 用完(用遞迴比較慢)
    // 2 * 要一個字一個字延伸看最遠能讀到哪

    // dp 的作法：
    // 設定 dp 為每個 s 跟 p長度的比較結果
    // * 的比較規則有個重點要考慮的是，如果比對成功，另一個可能是沒有 * 也是一樣答案
    // 另外改用 copy 上一個答案的方式可以減少判斷(dp的算法使然) f(n) = f(n-1) + f(n-2) 這樣

    public bool IsMatch(string s, string p)
    {
        int m = s.Length;
        int n = p.Length;
        bool[,] dp = new bool[m + 1, n + 1];

        // 初始化=這個很重要
        // 簡化程式比對的方向是把true複製過來就好
        dp[0, 0] = true; // 沒有來源且沒有 pattern = true;
        // 預設值，來源長度=0時
        for (int j = 1; j <= n; j++)
        {
            if (p[j - 1] == '*')
            {
                dp[0, j] = dp[0, j - 2];
            }
        }

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                //if (p[j - 1] == '.' || p[j - 1] == s[i - 1])
                //{
                //    dp[i, j] = dp[i - 1, j - 1];
                //}
                //else if (p[j - 1] == '*')
                //{
                //    dp[i, j] = dp[i, j - 2] || (dp[i - 1, j] && (s[i - 1] == p[j - 2] || p[j - 2] == '.'));
                //}

                if (p[j - 1] == '.' || p[j - 1] == s[i - 1]) // 有比中時，結果 = 兩邊都少一個字的結果
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else if (p[j - 1] == '*') //* 的規則有好幾個
                {
                    // 有比中，有 * 的條件可以當作沒有
                    // 或是比中前一個字一樣的結果
                    if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                    {
                        dp[i, j] = dp[i - 1, j] || dp[i, j - 2];
                    }
                    else // 沒比中，有 * 的條件可以當作沒有
                    {
                        dp[i, j] = dp[i, j - 2];
                    }
                }

            }
        }
        return dp[m, n];
    }




    public bool IsMatch_my(string s, string p)
    {
        return IsMatch(s, p, 0, -1);
    }

    private bool IsMatch(string s, string p, int sPos, int pPos)
    {
        int matchChar = -1;
        bool wild = false;
        GetNextChar(p);
        for (int i = sPos; i < s.Length; i++) // 終止條件改成 pattern 用完
        {
            if (matchChar == -1)
            {
                return false;
            }

            // not match
            if (matchChar != 0 && matchChar != s[i])
            {
                if (!wild)
                {
                    return false;
                }
                else
                {
                    GetNextChar(p);
                    i--;
                }
            }
            else
            {
                // match
                if (!wild)
                {
                    GetNextChar(p);
                }
                else
                {
                    var ss = (i + 1) >= s.Length ? "" : s.Substring(i + 1);
                    var pp = (pPos + 1) >= p.Length ? "" : p.Substring(pPos + 1);
                    // 用遞迴來一步一步測試 * 符號可以延伸到哪個長度
                    if (IsMatch(s, p, i, pPos)) return true;
                    if (IsMatch(s, p, i + 1, pPos)) return true;
                }
            }
        }

        // 把 pattern 的*用完
        while (wild)
        {
            GetNextChar(p);
        }
        return pPos >= p.Length;

        void GetNextChar(string p)
        {
            pPos++;
            if (pPos >= p.Length)
            {
                matchChar = -1;
                wild = false;
                return;
            }

            switch (p[pPos])
            {
                case '*':
                    matchChar = -1;
                    LoadWildChar(p);
                    break;
                case '.':
                    matchChar = 0;
                    LoadWildChar(p);
                    break;
                default:
                    matchChar = p[pPos];
                    LoadWildChar(p);
                    break;
            }
        }

        void LoadWildChar(string p)
        {
            if (pPos + 1 >= p.Length || p[pPos + 1] != '*')
            {
                wild = false;
            }
            else
            {
                wild = true;
                pPos++;
            }
        }
    }
}


[TestFixture()]
public class Test
{

    [Test()]
    public void TestSolution()
    {
        ClassicAssert.AreEqual(true, new Solution().IsMatch("a", "a*a"));
        ClassicAssert.AreEqual(true, new Solution().IsMatch("bbbba", ".*a*a"));
        ClassicAssert.AreEqual(true, new Solution().IsMatch("a", "ab*"));

        ClassicAssert.AreEqual(true, new Solution().IsMatch("aaa", "ab*a*c*a"));

        ClassicAssert.AreEqual(false, new Solution().IsMatch("aaa", "ab*a"));

        ClassicAssert.AreEqual(false, new Solution().IsMatch("mississippi", "mis*is*p*."));

        ClassicAssert.AreEqual(true, new Solution().IsMatch("aab", "c*a*b*"));

        ClassicAssert.AreEqual(false, new Solution().IsMatch("ab", ".*c"));
        ClassicAssert.AreEqual(true, new Solution().IsMatch("abc", ".*c"));
        ClassicAssert.AreEqual(true, new Solution().IsMatch("abc", "a.*c"));
        ClassicAssert.AreEqual(true, new Solution().IsMatch("abcbc", ".*c"));

        ClassicAssert.AreEqual(false, new Solution().IsMatch("aa", "a"));
        ClassicAssert.AreEqual(true, new Solution().IsMatch("aa", "a*"));
        ClassicAssert.AreEqual(true, new Solution().IsMatch("ab", ".*"));
    }
}