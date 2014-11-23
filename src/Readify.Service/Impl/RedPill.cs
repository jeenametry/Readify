﻿using System;
using System.ServiceModel;
using log4net;
using Readify.Contracts;

namespace knockknock.readify.net
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

		public ContactDetails WhoAreYou()
		{
			var whoAreYou = new ContactDetails()
			{
				EmailAddress = "dekko.ru@gmail.com",
				FamilyName = "Kudelia",
				GivenName = "Aleksei",
				PhoneNumber = "+79671821163"
			};
			
			return whoAreYou;
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
			return Guid.Parse("43163b51-7e56-4497-b7f5-c57789a8c6b4");
		}
	}
}