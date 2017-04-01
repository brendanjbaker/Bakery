namespace Bakery.Security
{
	using System;

	public class SecureByteArrayComparer
		: IByteArrayComparer
	{
		public Boolean IsEqual(Byte[] alpha, Byte[] beta)
		{
			if (alpha == null)
				throw new ArgumentNullException(nameof(alpha));

			if (beta == null)
				throw new ArgumentNullException(nameof(beta));

			if (alpha.Length != beta.Length)
				return false;

			var delta = 0;

			for (var i = 0; i < alpha.Length; i++)
			{
				delta |= alpha[i] ^ beta[i];
			}

			return delta == 0;
		}
	}
}
