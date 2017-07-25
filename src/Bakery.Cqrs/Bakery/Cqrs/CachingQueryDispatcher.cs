namespace Bakery.Cqrs
{
	using System;
	using System.Threading.Tasks;

	public class CachingQueryDispatcher
		: IQueryDispatcher
	{
		private readonly IQueryCache queryCache;
		private readonly IQueryDispatcher queryDispatcher;

		public CachingQueryDispatcher(IQueryCache queryCache, IQueryDispatcher queryDispatcher)
		{
			if (queryCache == null)
				throw new ArgumentNullException(nameof(queryCache));

			if (queryDispatcher == null)
				throw new ArgumentNullException(nameof(queryDispatcher));

			this.queryCache = queryCache;
			this.queryDispatcher = queryDispatcher;
		}

		public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
		{
			if (query == null)
				throw new ArgumentNullException(nameof(query));

			var result = await queryCache.ReadAsync<Object, Object>(query, async () =>
			{
				return await queryDispatcher.QueryAsync(query);
			});

			return (TResult)result;
		}
	}
}
