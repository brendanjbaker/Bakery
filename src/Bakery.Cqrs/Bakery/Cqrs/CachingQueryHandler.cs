namespace Bakery.Cqrs
{
	using Caching;
	using System;
	using System.Threading.Tasks;

	public class CachingQueryHandler<TQuery, TResult>
		: IQueryHandler<TQuery, TResult>

		where TQuery : IQuery<TResult>
	{
		private readonly IKeyedCache<Object, TResult> cache;
		private readonly IQueryHandler<TQuery, TResult> queryHandler;

		public CachingQueryHandler(
			IKeyedCache<Object, TResult> cache,
			IQueryHandler<TQuery, TResult> queryHandler)
		{
			this.cache = cache;
			this.queryHandler = queryHandler;
		}

		public async Task<TResult> HandleAsync(TQuery query)
		{
			return await cache.ReadAsync(query, async () =>
			{
				return await queryHandler.HandleAsync(query);
			});
		}
	}
}
