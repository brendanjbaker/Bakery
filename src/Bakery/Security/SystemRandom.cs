namespace Bakery.Security
{
	using System;

	public class SystemRandom
		: IRandom
	{
		private readonly Random random;

		public SystemRandom(Random random)
		{
			this.random = random;
		}

		public Byte GetByte()
		{
			var buffer = new Byte[1];

			random.NextBytes(buffer);

			return buffer[0];
		}
	}
}
