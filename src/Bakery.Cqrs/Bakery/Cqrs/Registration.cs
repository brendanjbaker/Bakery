namespace Bakery.Cqrs
{
	using System;
	using System.Threading.Tasks;

	public class Registration
		: IRegistration
	{
		private readonly Func<Object, Task<Object>> function;
		private readonly Type type;

		private Registration(Type type, Func<Object, Task<Object>> function)
		{
			if (type == null)
				throw new ArgumentNullException(nameof(type));

			if (function == null)
				throw new ArgumentNullException(nameof(function));

			this.function = function;
			this.type = type;
		}

		public static Registration Create<TCommand>(Func<ICommandHandler<TCommand>> factory)
			where TCommand : ICommand
		{
			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			return new Registration(typeof(TCommand), async command =>
			{
				var handler = factory();

				await handler.HandleAsync((TCommand)command);

				return null;
			});
		}

		public static Registration Create<TCommandHandler>(Type commandType, Func<TCommandHandler> factory)
		{
			if (commandType == null)
				throw new ArgumentNullException(nameof(commandType));

			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			return new Registration(commandType, async command =>
			{
				dynamic handler = factory();

				await handler.HandleAsync(command as dynamic);

				return null;
			});
		}

		public static Registration Create<TQuery, TResult>(Func<IQueryHandler<TQuery, TResult>> factory)
			where TQuery : IQuery<TResult>
		{
			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			return new Registration(typeof(TQuery), async query =>
			{
				var handler = factory();

				return await handler.HandleAsync((TQuery)query);
			});
		}

		public static Registration Create<TQueryHandler>(Type queryType, Type resultType, Func<TQueryHandler> factory)
		{
			if (queryType == null)
				throw new ArgumentNullException(nameof(queryType));

			if (resultType == null)
				throw new ArgumentNullException(nameof(resultType));

			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			return new Registration(queryType, async query =>
			{
				dynamic handler = factory();
				dynamic result = await handler.HandleAsync(query as dynamic);

				return result;
			});
		}

		public Type Type => type;

		public async Task<Object> ExecuteAsync(Object @object)
		{
			if (@object == null)
				throw new ArgumentNullException(nameof(@object));

			return await function(@object);
		}
	}
}
