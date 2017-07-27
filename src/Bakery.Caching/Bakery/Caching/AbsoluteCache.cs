namespace Bakery.Caching
{
	using System;
	using Time;

	public class AbsoluteCache<T>
		: ICache<T>
	{
		private readonly IClock clock;
		private readonly DateTime expiration;

		private T item;

		public AbsoluteCache(IClock clock, DateTime expiration)
		{
			if (clock == null)
				throw new ArgumentNullException(nameof(clock));

			this.clock = clock;
			this.expiration = expiration;
		}

		public T TryRead()
		{
			return item;
		}

		public void Write(T item)
		{
			this.item = item;
		}

		private Boolean IsExpired()
		{
			return clock.GetUniversalTime() >= expiration;
		}
	}
}
