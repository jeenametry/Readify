using System;
using Readify.Contracts;

namespace Readify.Impl
{
	public class FibonacciCalculator:IFibonacciCalculator
	{
		public long FibonacciNumber(long n)
		{
			if (n > 92 || n < -92)
			{
				throw new ArgumentOutOfRangeException();
			}

			long prev = 0;
			long next = 1;

			if (n == 0)
			{
				return 0;
			}

			if (n == 1)
			{
				return 1;
			}

			if (n == -1)
			{
				return 1;
			}

			for (long i = 2; i <= Math.Abs(n); i++)
			{
				long p = next;
				next = next + prev;

				prev = p;
			}

			if (n < 0 && Math.Abs(n) % 2 == 0)
			{
				next = -next;
			}

			return next;
		}
	}
}