using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5
{
    /*
     *      Longest Palindromic Substring
     *      最长回文子串   （回文: 正反读均相同）
     *      https://leetcode.com/problems/longest-palindromic-substring/description/
     */
    class Program
    {
        static void Main(string[] args)
        {
            string str = "abc";
            Console.WriteLine(new Solution().LongestPalindrome(str));
        }
    }

    //Approach: Expand Around Center ( 中心扩展算法 )
    class Solution
    {
        public String LongestPalindrome(String s)
        {
            if (s == null || s.Length < 1) return "";
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                //  奇数回文
                int len1 = ExpandAroundCenter(s, i, i);

                //  偶数回文
                int len2 = ExpandAroundCenter(s, i, i + 1);

                int len = Math.Max(len1, len2);

                Console.WriteLine("i: " + i + "\t" + "len1: " + len1 + "\t" 
                        + "len2: " + len2 + "\t" + "len: " + len );

                if ( len > end - start )
                {
                    //  i   当前回文的中心下标
                    //  回文起始下标
                    start = i - (len - 1) / 2;
                    
                    //  回文结束下标
                    end = i + len / 2;
                }
            }
            return start == end ? s.Substring(start, 1) : s.Substring(start, end + 1); 
        }

        //  从回文中心向左右展开
        private int ExpandAroundCenter(String s, int left, int right)
        {
            int L = left, R = right;
            while (L >= 0 && R < s.Length && s[L] == s[R])
            {
                L--;
                R++;
            }
            return R - L - 1;
        }
    }
}
