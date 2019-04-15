using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    /*
     *  Median of Two Sorted Arrays
     *  两个排序数组的中位数
     *  https://leetcode.com/problems/median-of-two-sorted-arrays/solution/
     */

    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 2, 3, 4 };
            int[] B = { 1, 2, 3, 4 };
            Console.WriteLine(Solution.FindMedianSortedArrays(A, B));
        }
    }

    //  Approach 1: Recursive Approach (递归法)
    /*  对于数组A[m], B[n], 只需保证
     *      一、
     *          i + j = m - i + n - j ( 或: m - i + n - j + 1 )
     *          如果 n >= m, 只需要使 i = 0 - m, j = (m + n + 1) / 2 - i
     *          即确保平分左右两部分
     *      二、
     *          B[j−1]≤A[i] 以及 A[i-1]≤B[j]
     *          满足中位数的条件
     */
    public class Solution
    {
        public static double FindMedianSortedArrays(int[] A, int[] B)
        {
            int m = A.Length;
            int n = B.Length;
            if (m > n)
            { // to ensure m<=n 确保 j >= 0  ( i + j = m - i + n - j + 1 )
                int[] temp = A; A = B; B = temp;
                int tmp = m; m = n; n = tmp;
            }
            int iMin = 0, iMax = m, halfLen = (m + n + 1) / 2;
            while (iMin <= iMax)
            {
                int i = (iMin + iMax) / 2;
                int j = halfLen - i;
                if (i < iMax && B[j - 1] > A[i])
                {
                    iMin = i + 1; // i is too small
                }
                else if (i > iMin && A[i - 1] > B[j])
                {
                    iMax = i - 1; // i is too big
                }
                else
                { // i is perfect
                    int maxLeft = 0;
                    if (i == 0) { maxLeft = B[j - 1]; }
                    else if (j == 0) { maxLeft = A[i - 1]; }
                    else { maxLeft = Math.Max(A[i - 1], B[j - 1]); }
                    if ((m + n) % 2 == 1) { return maxLeft; }

                    int minRight = 0;
                    if (i == m) { minRight = B[j]; }
                    else if (j == n) { minRight = A[i]; }
                    else { minRight = Math.Max(B[j], A[i]); }

                    return (maxLeft + minRight) / 2.0;
                }
            }
            return 0.0;
        }
    }
    
}
