using System;
using System.ServiceModel;
using log4net;
using Readify.Service.Contracts;

namespace Readify.Service.Impl
{
	[ErrorHandlerBehavior]
	public class RedPill : IRedPill
	{
		private readonly IStringReverser _stringReverser;
		private readonly IFibonacciCalculator _fibonacciCalculator;
		private readonly ITriangleService _triangleService;

		private ILog _log;

		public RedPill(IStringReverser stringReverser, IFibonacciCalculator fibonacciCalculator, ITriangleService triangleService)
		{
			_stringReverser = stringReverser;
			_fibonacciCalculator = fibonacciCalculator;
			_triangleService = triangleService;

			_log = LogManager.GetLogger(GetType());
		}

		public long FibonacciNumber(long n)
		{
			try
			{
				return _fibonacciCalculator.FibonacciNumber(n);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				throw new FaultException<ArgumentOutOfRangeException>(ex, ex.Message);
			}
		}

		public TriangleType WhatShapeIsThis(int a, int b, int c)
		{
			return _triangleService.WhatShapeIsThis(a, b, c);
		}

		public string ReverseWords(string s)
		{
			try
			{
				return _stringReverser.ReverseWords(s);
			}
			catch (ArgumentNullException ex)
			{
				throw new FaultException<ArgumentNullException>(ex, ex.Message);
			}
		}
		public Guid WhatIsYourToken()
		{
			return Guid.Parse("650ca565-b786-4ae1-b962-f72a966e9f1e");
		}
	}
}
