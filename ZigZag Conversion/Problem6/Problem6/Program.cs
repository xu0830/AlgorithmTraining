using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6
{
    /*
     *      ZigZag Conversion
     *      Z字形变换
     *      https://leetcode.com/problems/zigzag-conversion/solution/
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution1.Convert("PAYPALISHIRING", 3));
            Console.WriteLine(Solution2.Convert("PAYPALISHIRING", 3));
        }
    }

    //  Sort by Row ( 按行排序 )
    public class Solution1
    {
        public static string Convert(string s, int numRows)
        {

            if (numRows == 1) return s;

            List<StringBuilder> rows = new List<StringBuilder>();
            for (int i = 0; i < Math.Min(numRows, s.Length); i++)
            {
                rows.Add(new StringBuilder());
            }

            int curRow = 0;
            bool goingDown = false;

            foreach (char c in s.ToCharArray())
            {
                rows[curRow].Append(c);
                //  最上面的行或者最下面的行，改变方向
                if (curRow == 0 || curRow == numRows - 1)
                {
                    goingDown = !goingDown;
                }
                curRow += goingDown ? 1 : -1;
            }

            StringBuilder ret = new StringBuilder();
            foreach (StringBuilder row in rows)
            {
                ret.Append(row);
            }
            return ret.ToString();
        }
    }

    //  Visit by Row ( 按行访问 )
    /*
     *  行 0 中的字符位于索引 k * ( 2 * numRows − 2 ) 处
     *  行 numRows−1 中的字符位于索引 k * ( 2 * numRows − 2) + numRows − 1 处
     *  内部的 行 i 中的字符位于索引 k * ( 2 * numRows − 2 ) + i 以及 ( k + 1 )( 2 * numRows − 2 ) − i 处
     */
    public class Solution2
    {
        public static string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            StringBuilder ret = new StringBuilder();
            int n = s.Length;
            int cycleLen = 2 * numRows - 2;

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j + i < n; j += cycleLen)
                {
                    ret.Append( s[j + i] );
                    if (i != 0 && i != numRows - 1 && j + cycleLen - i < n)
                        ret.Append(s[j + cycleLen - i]);
                }
            }
            return ret.ToString();
        }
    }
}
