namespace Bakery.Cqrs
{
	using Caching;
	using System;
	using System.Collections.Generic;

	public class QueryCache
		: IQueryCache
	{
		private readonly IDictionary<Object, ICache<Object>> cache;
		private readonly ICachingConfiguration cachingConfiguration;

		public QueryCache(ICachingConfiguration cachingConfiguration)
		{
			if (cachingConfiguration == null)
				throw new ArgumentNullException(nameof(cachingConfiguration));

			this.cache = new Dictionary<Object, ICache<Object>>();
			this.cachingConfiguration = cachingConfiguration;
		}

		public Object TryRead(Object query)
		{
			ICache<Object> cache;

			if (query == null)
				throw new ArgumentNullException(nameof(query));

			if (!cachingConfiguration.IsEnabledForQueryType(query.GetType()))
				return null;

			if (this.cache.TryGetValue(query, out cache))
				return cache.TryRead();

			return null;
		}

		public void Write(Object query, Object result)
		{
			if (query == null)
				throw new ArgumentNullException(nameof(query));

			var queryType = query.GetType();

			if (!cachingConfiguration.IsEnabledForQueryType(query.GetType()))
				return;

			if (!cache.ContainsKey(query))
				cache[query] = cachingConfiguration.CreateCache(queryType);

			cache[query].Write(result);
		}
	}
}
