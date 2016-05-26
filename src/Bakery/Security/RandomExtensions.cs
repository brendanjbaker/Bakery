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

		public static String GetDigit(this IRandom random)
		{
			return (random.GetUInt64() % 10).ToString();
		}

		public static Int64 GetInt64(this IRandom random)
		{
			return BitConverter.ToInt64(random.GetBytes(8), 0);
		}

		public static UInt64 GetUInt64(this IRandom random)
		{
			return BitConverter.ToUInt64(random.GetBytes(8), 0);
		}
	}
}
