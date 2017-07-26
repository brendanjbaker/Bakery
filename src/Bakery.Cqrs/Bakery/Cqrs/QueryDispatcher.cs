namespace Bakery.Cqrs
{
	using Exception;
	using System;
	using System.Linq;
	using System.Threading.Tasks;

	public class QueryDispatcher
		: IQueryDispatcher
	{
		private readonly IHandlerResolver handlerResolver;

		public QueryDispatcher(IHandlerResolver handlerResolver)
		{
			if (handlerResolver == null)
				throw new ArgumentNullException(nameof(handlerResolver));

			this.handlerResolver = handlerResolver;
		}

		public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
		{
			if (query == null)
				throw new ArgumentNullException(nameof(query));

			var queryType = query.GetType();
			var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, typeof(TResult));
			var handlers = handlerResolver.GetHandlers(handlerType);

			if (handlers.None())
				throw new MissingRegistrationException(queryType);

			if (handlers.Multiple())
				throw new DuplicateRegistrationException(queryType);

			var handler = handlers.Single() as dynamic;

			return await handler.HandleAsync(query as dynamic);
		}
	}
}
