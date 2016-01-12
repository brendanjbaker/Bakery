namespace Bakery.Security
{
	using System;
	using System.Security.Cryptography;

	public class Pbkdf2Hasher
		: IHasher
	{
		public Byte[] Hash(Byte[] value, Byte[] salt, Int32 iterationCount, Int32 size)
		{
			using (var pbkdf2 = new Rfc2898DeriveBytes(value, salt, iterationCount))
			{
				return pbkdf2.GetBytes(size);
			}
		}
	}
}
