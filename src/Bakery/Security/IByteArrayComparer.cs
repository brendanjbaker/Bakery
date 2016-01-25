namespace Bakery.Security
{
	using System;

	public interface IByteArrayComparer
	{
		Boolean IsEqual(Byte[] alpha, Byte[] beta);
	}
}
