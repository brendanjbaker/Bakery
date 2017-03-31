namespace Bakery.Security
{
	using System;

	public interface ITextHasher
	{
		Byte[] Hash(String value, Byte[] salt, Int32 iterationCount, Int32 size);
	}
}
