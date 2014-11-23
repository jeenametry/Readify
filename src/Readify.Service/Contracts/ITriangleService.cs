using knockknock.readify.net;

namespace Readify.Contracts
{
	public interface ITriangleService
	{
		TriangleType WhatShapeIsThis(int a, int b, int c);
	}
}