namespace Bakery.Cqrs
{
	using SimpleInjector;
	using System;
	using System.Linq;
	using System.Threading.Tasks;

	public class SimpleInjectorDispatcher
		: IDispatcher
	{
		private readonly Container container;

		public SimpleInjectorDispatcher(Container container)
		{
			if (container == null)
				throw new ArgumentNullException(nameof(container));

			this.container = container;
		}

		public async Task CommandAsync<TCommand>(TCommand command)
			where TCommand : ICommand
		{
			if (command == null)
				throw new ArgumentNullException(nameof(command));

			var handlers = container.GetAllInstances<ICommandHandler<TCommand>>().ToArray();

			if (!handlers.Any())
				throw new NoRegistrationFoundException(typeof(TCommand));

			foreach (var handler in handlers)
				await handler.HandleAsync(command);
		}

		public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
		{
			if (query == null)
				throw new ArgumentNullException(nameof(query));

			var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
			var handlers = container.GetAllInstances(handlerType).ToArray();

			if (!handlers.Any())
				throw new NoRegistrationFoundException(query.GetType());

			if (handlers.Multiple())
				throw new MultipleRegistrationsFoundException(query.GetType());

			dynamic handler = handlers.Single();

			return await handler.HandleAsync(query as dynamic);
		}
	}
}
