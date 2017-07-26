namespace Bakery.Cqrs
{
	using System;

	public struct Priority
	{
		public static readonly Priority
			Low = 0.25m,
			Normal = 0.5m,
			High = 0.75m;

		private readonly Decimal value;

		public Priority(Decimal value)
		{
			if (value < Decimal.Zero)
				throw new ArgumentOutOfRangeException(nameof(value), "Must not be less than 0.");

			if (value > Decimal.One)
				throw new ArgumentOutOfRangeException(nameof(value), "Must not be greater than 1.");

			this.value = value;
		}

		public static implicit operator Priority(Decimal value)
		{
			return new Priority(value);
		}

		public Decimal Value => value;
	}
}
