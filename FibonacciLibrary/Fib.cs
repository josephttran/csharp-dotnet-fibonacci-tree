using System.Collections.Generic;

namespace FibonacciLibrary
{
    public class Fibonacci
    {
        public static int nthFib(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return nthFib(n - 1) + nthFib(n - 2);
        }

        public static List<int> FibSequence(int n)
        {
            List<int> fibList = new List<int>();

            for (int i = 0; i <= n; i++)
            {
                fibList.Add(nthFib(i));
            }

            return fibList;
        }
    }
}
