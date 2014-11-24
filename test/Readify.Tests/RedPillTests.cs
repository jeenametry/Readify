using System;
using System.ServiceModel;
using Moq;
using Readify.Service.Contracts;
using Readify.Service.Impl;
using Xunit;

namespace Readify.Tests
{
	public class RedPillTests
	{
		private Mock<IStringReverser> _stringReverserMock = new Mock<IStringReverser>();
		private Mock<IFibonacciCalculator> _fibonacciCalculatorMock = new Mock<IFibonacciCalculator>();
		private Mock<ITriangleService> _triangleServiceMock = new Mock<ITriangleService>();

		[Fact]
		public void ReverseWords_ShouldInvoke_StringReverser_Test()
		{
			var service = GetService();

			var result = service.ReverseWords("test");

			_stringReverserMock.Verify(x => x.ReverseWords("test"));
		}

		[Fact]
		public void Fibonacci_ShouldInvoke_FibonacciCalculator_Test()
		{
			var service = GetService();

			var result = service.FibonacciNumber(1);

			_fibonacciCalculatorMock.Verify(x => x.FibonacciNumber(1));
		}

		[Fact]
		public void WhatShapeIsThis_ShouldInvokeTriangleService_Test()
		{
			var service = GetService();

			var result = service.WhatShapeIsThis(1, 2, 3);

			_triangleServiceMock.Verify(x => x.WhatShapeIsThis(1, 2, 3));
		}

		[Fact]
		public void FaultException_Fibonnaci_Test()
		{
			var service = GetService();

			_fibonacciCalculatorMock
				.Setup(x => x.FibonacciNumber(1))
				.Throws<ArgumentOutOfRangeException>();

			Assert.Throws<FaultException<ArgumentOutOfRangeException>>(() =>
			{
				service.FibonacciNumber(1);
			});
		}

		[Fact]
		public void FaultException_WordReverse_Test()
		{
			var service = GetService();

			_stringReverserMock
				.Setup(x => x.ReverseWords("word"))
				.Throws<ArgumentNullException>();

			Assert.Throws<FaultException<ArgumentNullException>>(() =>
			{
				service.ReverseWords("word");
			});
		}

		private RedPill GetService()
		{
			return new RedPill(_stringReverserMock.Object, _fibonacciCalculatorMock.Object, _triangleServiceMock.Object);
		}

	}
}