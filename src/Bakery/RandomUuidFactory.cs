namespace Bakery
{
	using Entropy;
	using System;

	public class RandomUuidFactory
		: IUuidFactory
	{
		private readonly IRandom random;

		public RandomUuidFactory(IRandom random)
		{
			this.random = random;
		}

		public Uuid Create()
		{
			var bytes = random.GetBytes(16);

			bytes[6] |= 0x40;
			bytes[6] &= 0x4f;
			bytes[8] |= 0x80;
			bytes[8] &= 0xbf;

			return new Uuid(new Guid(bytes));
		}
	}
}
