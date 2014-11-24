using Readify.Service.Contracts;
using Readify.Service.Impl;
using Xunit;

namespace Readify.Tests
{
	public class WhatShapeIsThisTests
	{
		[Fact]
		public void AplusBlessThenC_ReturnError_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(1, 2, 4);

			Assert.Equal(TriangleType.Error, result);
		}

		[Fact]
		public void AplusBEqualsC_ReturnError_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(1, 2, 3);

			Assert.Equal(TriangleType.Error, result);
		}
		[Fact]
		public void AplusCEqualsB_ReturnError_Test()
		{
			var service = GetService();

			var result = service.WhatShapeIsThis(1, 4, 3);
			Assert.Equal(TriangleType.Error, result);
		}

		[Fact]
		public void AplusClessB_ReturnError_Test()
		{
			var service = GetService();

			var result = service.WhatShapeIsThis(1, 4, 2);
			Assert.Equal(TriangleType.Error, result);
		}

		[Fact]
		public void BplusClessA_Resturn_Error_Test()
		{
			var service = GetService();

			var result = service.WhatShapeIsThis(4, 1, 2);
			Assert.Equal(TriangleType.Error, result);
		}

		[Fact]
		public void BplusCequalsA_Resturn_Error_Test()
		{
			var service = GetService();

			var result = service.WhatShapeIsThis(3, 1, 2);
			Assert.Equal(TriangleType.Error, result);
		}

		[Fact]
		public void AequalsBequalsC_Return_Equilateral_Test()
		{
			var service = GetService();

			var result = service.WhatShapeIsThis(1, 1, 1);
			Assert.Equal(TriangleType.Equilateral, result);
		}

		[Fact]
		public void Azero_Return_Error_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(0,1,1);

			Assert.Equal(TriangleType.Error, result);
		}

		[Fact]
		public void AlessZero_Return_Error_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(-1, 1, 1);

			Assert.Equal(TriangleType.Error, result);
		}

		[Fact]
		public void Bzero_Return_Error_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(1, 0, 1);

			Assert.Equal(TriangleType.Error, result);
		}

		[Fact]
		public void BlessZero_Return_Error_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(1, -1, 1);

			Assert.Equal(TriangleType.Error, result);
		}



		[Fact]
		public void Czero_Return_Error_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(1, 1, 0);

			Assert.Equal(TriangleType.Error, result);
		}

		[Fact]
		public void ClessZero_Return_Error_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(1, 1, -1);

			Assert.Equal(TriangleType.Error, result);
		}

		[Fact]
		public void AequalsB_Return_Isosceles_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(2,2,1);

			Assert.Equal(TriangleType.Isosceles, result);
		}

		[Fact]
		public void BequalsC_Return_Isosceles_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(1, 2, 2);

			Assert.Equal(TriangleType.Isosceles, result);
		}

		[Fact]
		public void AequalsC_Return_Isosceles_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(2, 1, 2);

			Assert.Equal(TriangleType.Isosceles, result);
		}

		[Fact]
		public void AequalsBequalsClessZero_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(-1, -1, -1);

			Assert.Equal(TriangleType.Error, result);
		}

		[Fact]
		public void ScaleneTriangle_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(2, 3, 4);

			Assert.Equal(TriangleType.Scalene, result);
		}

		[Fact]
		public void BigNumbers1_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(2147483647, 2147483647, 2147483647);

			Assert.Equal(TriangleType.Equilateral, result);
		}

		[Fact]
		public void BigNegative_Test()
		{
			var service = GetService();
			var result = service.WhatShapeIsThis(-2147483648, -2147483648, -2147483648);

			Assert.Equal(TriangleType.Error, result);
		}


		private TriangleService GetService()
		{
			return new TriangleService();
		}
	}
}
