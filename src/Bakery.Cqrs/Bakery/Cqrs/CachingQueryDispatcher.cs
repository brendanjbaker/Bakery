namespace Bakery.Cqrs
{
	using Configuration;
	using System;
	using System.Threading.Tasks;

	public class CachingQueryDispatcher
		: IQueryDispatcher
	{
		private readonly ICachingConfiguration cachingConfiguration;
		private readonly IQueryDispatcher queryDispatcher;

		public CachingQueryDispatcher(ICachingConfiguration cachingConfiguration, IQueryDispatcher queryDispatcher)
		{
			if (cachingConfiguration == null)
				throw new ArgumentNullException(nameof(cachingConfiguration));

			if (queryDispatcher == null)
				throw new ArgumentNullException(nameof(queryDispatcher));

			this.cachingConfiguration = cachingConfiguration;
			this.queryDispatcher = queryDispatcher;
		}

		public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
		{
			if (query == null)
				throw new ArgumentNullException(nameof(query));

			var queryCachingConfiguration = GetQueryCachingConfiguration(query.GetType());

			if (queryCachingConfiguration == null)
				return await queryDispatcher.QueryAsync(query);

			var cachedResult = cachingConfiguration.Read(query);

			if (cachedResult != null)
				return (TResult)cachedResult;

			var result = await queryDispatcher.QueryAsync(query);
			var lifetime = queryCachingConfiguration.Lifetime ?? cachingConfiguration.DefaultLifetime;
			var priority = queryCachingConfiguration.Priority ?? cachingConfiguration.DefaultPriority;

			cachingConfiguration.Write(query, result, lifetime, priority);

			return result;
		}

		private IQueryCachingConfiguration GetQueryCachingConfiguration(Type queryType)
		{
			IQueryCachingConfiguration configuration;

			if (cachingConfiguration.QueryCachingConfigurations.TryGetValue(queryType, out configuration))
				return configuration;

			return null;
		}
	}
}
