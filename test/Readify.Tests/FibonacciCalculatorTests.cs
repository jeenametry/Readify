using System;
using Readify.Impl;
using Xunit;
using Xunit.Extensions;

namespace Readify.Tests
{
	public class FibonacciCalculatorTests
	{

		[Theory]
		[InlineData(0, 0)]
		[InlineData(1, 1)]
		[InlineData(2, 1)]
		[InlineData(3, 2)]
		[InlineData(4, 3)]
		[InlineData(5, 5)]
		[InlineData(6, 8)]
		public void Positive_Test(long n, long result)
		{var service = GetService();

			var actual = service.FibonacciNumber(n);

			Assert.Equal(result, actual);

		}

		[Fact]
		public void MaxN_ThrowException_Test()
		{
			var service = GetService();

			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				var result = service.FibonacciNumber(93);
			});

		}

		[Fact]
		public void MaxNegativeN_ThrowException_Test()
		{
			var service = GetService();

			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				var result = service.FibonacciNumber(-93);
			});
		}

		
		[Theory]
		[InlineData(-1, 1)]
		[InlineData(-2, -1)]
		[InlineData(-3, 2)]
		[InlineData(-4, -3)]
		[InlineData(-5, 5)]
		[InlineData(-6, -8)]
		public void Negative_Test(long n, long result)
		{
			var service = GetService();

			var actual = service.FibonacciNumber(n);

			Assert.Equal(result, actual);
		}

		private FibonacciCalculator GetService()
		{
			return new FibonacciCalculator();
		}
	}
}
