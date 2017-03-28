namespace Bakery.Security
{
	using System;
	using System.Security.Cryptography;

	public class Pbkdf2Hasher
		: IHasher
	{
		public Byte[] Hash(Byte[] value, Byte[] salt, Int32 iterationCount, Int32 size)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			if (salt == null)
				throw new ArgumentNullException(nameof(salt));

			if (iterationCount < 0)
				throw new ArgumentOutOfRangeException(nameof(iterationCount));

			if (size <= 0)
				throw new ArgumentOutOfRangeException(nameof(size));

			using (var pbkdf2 = new Rfc2898DeriveBytes(value, salt, iterationCount))
			{
				return pbkdf2.GetBytes(size);
			}
		}
	}
}
