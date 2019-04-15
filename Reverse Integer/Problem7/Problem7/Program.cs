using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = -2147483647;
            Console.WriteLine(Solution1.Reverse(x));
            Console.WriteLine(x.ToString());
        }
    }

    class Solution1
    {
        public static int Reverse(int x)
        {
            int rev = 0;

            while ( x != 0 )
            {
                //  得到个位上的数字
                int pop = x % 10;
                //  整除10，
                x /= 10;
                //  Int32.MaxValue = 2147483647
                //  Int32.MinValue = -2147483648
                if (rev > Int32.MaxValue / 10 || (rev == Int32.MaxValue / 10 && pop > 7)) return 0;
                if (rev < Int32.MinValue / 10 || (rev == Int32.MinValue / 10 && pop < -8)) return 0;
                rev = rev * 10 + pop;
            }

            return rev;
        }
    }
    

}
