using System;

namespace Fibonacci_Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            /*for (int i = 1; i < n; i++)
                Console.WriteLine(i+ " " + Fibonacci(i));*/

            long[] fib = new long[n+1];
            fib[1] = 1; fib[2] = 1;
            Console.Write(fib[1]+" "+fib[2]+" ");

            for (int i = 3; i <= n; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
                Console.Write(fib[i]+" ");
            }
            Console.ReadKey();
        }

        static int Fibonacci(int n)
        {
            if (n == 1 || n == 2)
                return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
