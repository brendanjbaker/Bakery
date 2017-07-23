namespace Bakery.Caching
{
	using System;
	using System.Collections.Generic;

	public class KeyedCache<TKey, TValue>
		: IKeyedCache<TKey, TValue>
	{
		private readonly IDictionary<TKey, ICache<TValue>> cache;
		private readonly Func<ICache<TValue>> cacheFactory;

		public KeyedCache(Func<ICache<TValue>> cacheFactory)
			: this(new Dictionary<TKey, ICache<TValue>>(), cacheFactory) { }

		public KeyedCache(IDictionary<TKey, ICache<TValue>> cache, Func<ICache<TValue>> cacheFactory)
		{
			this.cache = cache;
			this.cacheFactory = cacheFactory;
		}

		public TValue TryRead(TKey key)
		{
			if (!cache.ContainsKey(key))
				return default(TValue);

			return cache[key].TryRead();
		}

		public void Write(TKey key, TValue item)
		{
			if (!cache.ContainsKey(key))
				cache[key] = cacheFactory();

			cache[key].Write(item);
		}
	}
}
