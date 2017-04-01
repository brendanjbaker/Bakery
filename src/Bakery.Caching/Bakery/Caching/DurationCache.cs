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
			if (clock == null)
				throw new ArgumentNullException(nameof(clock));

			if (duration < TimeSpan.Zero)
				throw new ArgumentOutOfRangeException(nameof(duration));

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
			if (expiration == null)
				return true;

			return clock.GetUniversalTime() >= expiration;
		}
	}
}
