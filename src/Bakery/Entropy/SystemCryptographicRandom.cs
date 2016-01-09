namespace Bakery.Entropy
{
	using System;
	using System.Security.Cryptography;

	public class SystemCryptographicRandom
		: IRandom
	{
		private readonly RandomNumberGenerator randomNumberGenerator;

		public SystemCryptographicRandom(RandomNumberGenerator randomNumberGenerator)
		{
			this.randomNumberGenerator = randomNumberGenerator;
		}

		public Byte GetByte()
		{
			var buffer = new Byte[1];

			randomNumberGenerator.GetBytes(buffer);

			return buffer[0];
		}
	}
}
