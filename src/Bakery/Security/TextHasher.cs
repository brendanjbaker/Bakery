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
			if (encoding == null)
				throw new ArgumentNullException(nameof(encoding));

			if (hasher == null)
				throw new ArgumentNullException(nameof(hasher));

			this.encoding = encoding;
			this.hasher = hasher;
		}

		public Byte[] Hash(String value, Byte[] salt, Int32 iterationCount, Int32 size)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			if (salt == null)
				throw new ArgumentNullException(nameof(salt));

			return hasher.Hash(encoding.GetBytes(value), salt, iterationCount, size);
		}
	}
}
