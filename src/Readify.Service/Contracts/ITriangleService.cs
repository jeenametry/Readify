namespace Readify.Service.Contracts
{
	public interface ITriangleService
	{
		TriangleType WhatShapeIsThis(int a, int b, int c);
	}
}