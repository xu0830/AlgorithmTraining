using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem9
{
    //  Palindrome Number   回文数
    //  https://leetcode.com/problems/palindrome-number/description/
    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            Console.WriteLine(MySolution.IsPalindrome(input));
            Console.WriteLine(new Solution().IsPalindrome(input));
        }
    }
    class MySolution
    {
        public static bool IsPalindrome(int x)
        {
            int temp = x;

            int palindrome = 0;

            int curNumber = 0;

            while( temp > 0 )
            {
                curNumber = temp % 10;
                palindrome = palindrome * 10 + curNumber;
                temp /= 10;
            }

            return palindrome == x;
        }

        public static int GetPalindrome(int x)
        {
            int temp = x;

            int palindrome = 0;

            int curNumber = 0;

            while (temp > 0)
            {
                curNumber = temp % 10;
                palindrome = palindrome * 10 + curNumber;
                temp /= 10;
            }

            return palindrome;
        }

    }

    //  Revert half of the number 反转一半数字
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            // 特殊情况：
            // 如上所述，当 x < 0 时，x 不是回文数。
            // 同样地，如果数字的最后一位是 0，为了使该数字为回文，
            // 则其第一位数字也应该是 0
            // 只有 0 满足这一属性
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            // 当数字长度为奇数时，我们可以通过 revertedNumber/10 去除处于中位的数字。
            // 例如，当输入为 12321 时，在 while 循环的末尾我们可以得到 x = 12，revertedNumber = 123，
            // 由于处于中位的数字不影响回文（它总是与自己相等），所以我们可以简单地将其去除。
            return x == revertedNumber || x == revertedNumber/10;
        }
    }
}
