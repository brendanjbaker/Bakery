namespace Bakery.Metrics
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class MemoryCounter
		: ICounter
	{
		private readonly IDictionary<Object, Int64> counts;

		public MemoryCounter()
			: this(new Dictionary<Object, Int64>()) { }

		private MemoryCounter(IDictionary<Object, Int64> counts)
		{
			this.counts = counts ?? throw new ArgumentNullException(nameof(counts));
		}

		public Task IncrementAsync(Object key, Int64 count = 1)
		{
			lock (counts)
			{
				if (!counts.ContainsKey(key))
					counts.Add(key, 0);

				counts[key] += count;
			}

			return Task.CompletedTask;
		}

		public Task<Int64> ReadAsync(Object key)
		{
			Int64 count;

			lock (counts)
				if (!counts.TryGetValue(key, out count))
					count = 0;

			return Task.FromResult(count);
		}
	}
}
