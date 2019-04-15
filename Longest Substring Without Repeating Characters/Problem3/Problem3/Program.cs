using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    /*
     *  Check all the substring one by one to see if it has no duplicate character.Algorithm
     *  无重复字符的最长子串
     *  https://leetcode.com/problems/longest-substring-without-repeating-characters/solution/
     */

    class Program
    {
        static void Main(string[] args)
        {
            int result;

            //  Solution1 Test
            result = Solution1.LengthOfLongestSubstring("pwwkew");
            Console.WriteLine($"Approach 1: Brute Force\nresult: {result}");

            //  Solution2 Test
            result = Solution2.LengthOfLongestSubstring("pwwkew");
            Console.WriteLine($"Approach 2: Sliding Window\nresult: {result}");

            //Solution3 Test
            result = Solution3.LengthOfLongestSubstring("pwwkew");
            Console.WriteLine($"Approach 3: Sliding Window optimized\nresult: {result}");
        }

        /// <summary>
        /// Approach 1: Brute Force(暴力法）
        /// </summary>
        public class Solution1
        {
            public static int LengthOfLongestSubstring(String s)
            {
                int n = s.Length;
                int ans = 0;

                //  循环遍历所有存在的每一种子串
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j <= n; j++)
                    {
                        //  子串中是否含有重复字符
                        if (AllUnique(s, i, j))
                        {
                            ans = Math.Max(ans, j - i);
                        }
                    }
                }
                return ans;
            }

            //  判断子串中是否含有重复的字符
            public static bool AllUnique(String s, int start, int end)
            {
                //  存储子串的每个字符
                ISet<char> set = new HashSet<char>();
                for (int i = start; i < end; i++)
                {
                    char ch = s[i];
                    if (set.Contains(ch)) return false;
                    set.Add(ch);
                }
                return true;
            }
        }

        /// <summary>
        /// Approach 2: Sliding Window(滑动窗口)
        /// </summary>
        public class Solution2
        {
            public static int LengthOfLongestSubstring(String s)
            {
                int n = s.Length;
                ISet<char> set = new HashSet<char>();

                int ans = 0, i = 0, j = 0;

                while (i < n && j < n)
                {
                    // try to extend the range [i, j]
                    if (!set.Contains(s[j]))
                    {
                        set.Add(s[j++]);
                        ans = Math.Max(ans, j - i);
                    }
                    else
                    {
                        set.Remove(s[i++]);
                    }
                }
                return ans;
            }
        }

        /// <summary>
        /// Approach 3: Sliding Window Optimized(优化的滑动窗口)
        /// </summary>
        public class Solution3
        {
            public static int LengthOfLongestSubstring(String s)
            {
                int n = s.Length, ans = 0;
                
                Dictionary<char, int> map = new Dictionary<char, int>(); // current index of character
                // try to extend the range [i, j]

                for (int j = 0, i = 0; j < n; j++)
                {
                    if (map.ContainsKey(s[j]))
                    {
                        i = Math.Max(map[s[j]], i);
                        
                    }
                    ans = Math.Max(ans, j - i + 1);
                    map[s[j]] = j + 1;
                }
                return ans;
            }
        }

        /*  方法2和3的区别在于
         *      当遇到重复的字符时，
         *          方法2先进行窗口缩小，再滑动窗口
         *          方法3将窗口的左起点设置为当前索引值
         */
    }
}
