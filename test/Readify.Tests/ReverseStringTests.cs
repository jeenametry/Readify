using System;
using System.ServiceModel;
using Readify.Contracts;
using Readify.Impl;
using Readify.Service.Contracts;
using Xunit;

namespace Readify.Tests
{
	public class ReverseStringTests
	{
		[Fact]
		public void InputNull_ThrowException_Test()
		{
			var service = GetService();

			Assert.Throws<ArgumentNullException>(() =>
			{
				var result = service.ReverseWords(null);
			});

		}

		[Fact]
		public void EmptyInput_ReturnEmptyString_Test()
		{
			var service = GetService();
			var result = service.ReverseWords("");

			Assert.Equal("", result);
		}

		[Fact]
		public void ReverseOneWord_Test()
		{
			var service = GetService();
			var result = service.ReverseWords("abc");

			Assert.Equal("cba", result);
		}

		[Fact]
		public void Bangs_Test()
		{
			var service = GetService();
			var result = service.ReverseWords("!B!A!N!G!S!");

			Assert.Equal("!S!G!N!A!B!", result);
		}

		[Fact]
		public void LeadingSpace_Test()
		{
			var service = GetService();
			var result = service.ReverseWords("  abc");

			Assert.Equal("  cba", result);
		}

		[Fact]
		public void Bang_Test()
		{
			var service = GetService();
			var result = service.ReverseWords("Bang!");

			Assert.Equal("!gnaB", result);
		}

		[Fact]
		public void Spacey_Test()
		{
			var service = GetService();
			var result = service.ReverseWords("  S  P  A  C  E  Y  ");

			Assert.Equal("  S  P  A  C  E  Y  ", result);
		}

		

		[Fact]
		public void TwoSpaces_Test()
		{
			var service = GetService();
			var result = service.ReverseWords("abc  cba");

			Assert.Equal("cba  abc", result);
		}


		private IStringReverser GetService()
		{
			return new StringReverser();
		}
	}
}
