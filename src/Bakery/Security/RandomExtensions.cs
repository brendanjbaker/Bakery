namespace Bakery.Security
{
	using System;

	public static class RandomExtensions
	{
		public static Byte[] GetBytes(this IRandom random, Int32 count)
		{
			if (count <= 0)
				throw new ArgumentOutOfRangeException(nameof(count));

			var buffer = new Byte[count];

			for (var i = 0; i < count; i++)
				buffer[i] = random.GetByte();

			return buffer;
		}
	}
}
