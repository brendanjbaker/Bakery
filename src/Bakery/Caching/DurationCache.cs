namespace Bakery.Caching
{
	using System;
	using Time;

	public class DurationCache<T>
		: ICache<T>
	{
		private readonly IClock clock;
		private readonly TimeSpan duration;

		private DateTime? expiration;
		private T item;

		public DurationCache(IClock clock, TimeSpan duration)
		{
			this.clock = clock;
			this.duration = duration;
		}

		public T TryRead()
		{
			if (IsExpired())
				return default(T);

			return item;
		}

		public void Write(T item)
		{
			this.item = item;

			expiration = clock.GetUniversalTime() + duration;
		}

		private Boolean IsExpired()
		{
			return clock.GetUniversalTime() >= expiration;
		}
	}
}
