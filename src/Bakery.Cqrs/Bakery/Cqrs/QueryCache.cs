namespace Bakery.Cqrs
{
	using Caching;
	using System;

	public class QueryCache
		: IQueryCache
	{
		private readonly IKeyedCache<Object, Object> cache;
		private readonly ICachingConfiguration cachingConfiguration;

		public QueryCache(IKeyedCache<Object, Object> cache, ICachingConfiguration cachingConfiguration)
		{
			if (cache == null)
				throw new ArgumentNullException(nameof(cache));

			if (cachingConfiguration == null)
				throw new ArgumentNullException(nameof(cachingConfiguration));

			this.cache = cache;
			this.cachingConfiguration = cachingConfiguration;
		}

		public Object TryRead(Object query)
		{
			if (query == null)
				throw new ArgumentNullException(nameof(query));

			if (!cachingConfiguration.IsEnabledForQueryType(query.GetType()))
				return null;

			return cache.TryRead(query);
		}

		public void Write(Object query, Object result)
		{
			if (query == null)
				throw new ArgumentNullException(nameof(query));

			if (!cachingConfiguration.IsEnabledForQueryType(query.GetType()))
				return;

			cache.Write(query, result);
		}
	}
}
