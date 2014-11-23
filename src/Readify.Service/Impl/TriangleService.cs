using knockknock.readify.net;
using Readify.Contracts;
using Readify.Service.Contracts;

namespace Readify.Impl
{
	public class TriangleService:ITriangleService
	{
		public TriangleType WhatShapeIsThis(int a, int b, int c)
		{
			long la, lb, lc;

			la = a;
			lb = b;
			lc = c;

			if (la <= 0 || lb <= 0 || lc <= 0)
			{
				return TriangleType.Error;
			}

			if (la + lb <= lc
				|| la + lc <= lb
				|| lb + lc <= la)
			{
				return TriangleType.Error;
			}

			if (la == lb && lb == lc)
			{
				return TriangleType.Equilateral;
			}

			if (la == lb || lb == lc || la == lc)
			{
				return TriangleType.Isosceles;
			}

			return TriangleType.Scalene;
		}
	}
}