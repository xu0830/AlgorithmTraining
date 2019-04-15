using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10
{
    //  Regular Expression Matching
    //  正则表达式匹配
    //  https://leetcode-cn.com/problems/regular-expression-matching/description/
    class Program
    {
        static void Main(string[] args)
        {
            string text = "aab";
            string pattern = "c*a*b";
            Console.WriteLine(Solution.IsMatch(text, pattern));
        }
    }

    //Approach 1: Recursion ( 递归 )
    class Solution
    {
        //  匹配整个text字符
        public static bool IsMatch(String text, String pattern)
        {
            if (pattern.IsNullOrEmpty())
            {
                return text.IsNullOrEmpty();
            }
            //  s s i s s i p p i
            //  s * i s * p * .
            //  判断首个字符是否匹配
            bool first_match = (!text.IsNullOrEmpty() &&
                                   (pattern[0] == text[0] || pattern[0] == '.'));

            //  下一个为通配符，可以匹配零个或多个首字符
            if (pattern.Length >= 2 && pattern[1] == '*')
            {
                return (IsMatch(text, pattern.Substring(2)) //  满足情况: 首个字符不匹配，且第二个字符为*
                    ||  (first_match && IsMatch(text.Substring(1), pattern)));
                //  满足情况: 首个字符匹配，判断字符 * 是否匹配多个字符
            }
            else
            {
                return first_match && IsMatch(text.Substring(1), pattern.Substring(1));
            }
        }
    }
}
