namespace Bakery.Cqrs
{
	using SimpleInjector;
	using System;
	using System.Linq;
	using System.Threading.Tasks;

	public class SimpleInjectorQueryDispatcher
		: IQueryDispatcher
	{
		private readonly Container container;

		public SimpleInjectorQueryDispatcher(Container container)
		{
			if (container == null)
				throw new ArgumentNullException(nameof(container));

			this.container = container;
		}

		public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
		{
			if (query == null)
				throw new ArgumentNullException(nameof(query));

			var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
			var handlers = container.GetAllInstances(handlerType).ToArray();

			if (handlers.None())
				throw new NoRegistrationFoundException(query.GetType());

			if (handlers.Multiple())
				throw new MultipleRegistrationsFoundException(query.GetType());

			dynamic handler = handlers.Single();

			return await handler.HandleAsync(query as dynamic);
		}
	}
}
