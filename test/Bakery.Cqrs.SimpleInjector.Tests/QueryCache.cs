using Bakery.Caching;
using Bakery.Time;
using System;
using System.Collections.Generic;

public class QueryCache
{
	private readonly IDictionary<Object, ICache<Object>> cache;
	private readonly IClock clock;

	public QueryCache(IClock clock)
		: this(clock, new Dictionary<Object, ICache<Object>>()) { }

	public QueryCache(IClock clock, IDictionary<Object, ICache<Object>> cache)
	{
		this.cache = cache;
		this.clock = clock;
	}

	public Object TryRead(Object query)
	{
		if (!cache.ContainsKey(query))
			return null;

		return cache[query].TryRead();
	}

	public void Write(Object query, Object result, TimeSpan lifetime)
	{
		if (!cache.ContainsKey(query))
			cache[query] = new DurationCache<Object>(clock, lifetime);

		cache[query].Write(result);
	}
}
