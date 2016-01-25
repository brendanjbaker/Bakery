namespace Bakery.Security
{
	using System;
	using System.Text;

	public class TextHasher
		: ITextHasher
	{
		private readonly Encoding encoding;
		private readonly IHasher hasher;

		public TextHasher(Encoding encoding, IHasher hasher)
		{
			this.encoding = encoding;
			this.hasher = hasher;
		}

		public Byte[] Hash(String value, Byte[] salt, Int32 iterationCount, Int32 size)
		{
			return hasher.Hash(encoding.GetBytes(value), salt, iterationCount, size);
		}
	}
}
