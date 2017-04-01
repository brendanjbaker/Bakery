namespace Bakery.Security
{
	using System;

	public interface IHasher
	{
		Byte[] Hash(Byte[] value, Byte[] salt, Int32 iterationCount, Int32 size);
	}
}
