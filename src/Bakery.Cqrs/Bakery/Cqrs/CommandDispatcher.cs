namespace Bakery.Cqrs
{
	using Configuration;
	using Exception;
	using System;
	using System.Threading.Tasks;

	public class CommandDispatcher
		: ICommandDispatcher
	{
		private readonly IConfiguration configuration;
		private readonly IHandlerResolver handlerResolver;

		public CommandDispatcher(IConfiguration configuration, IHandlerResolver handlerResolver)
		{
			if (configuration == null)
				throw new ArgumentNullException(nameof(configuration));

			if (handlerResolver == null)
				throw new ArgumentNullException(nameof(handlerResolver));

			this.configuration = configuration;
			this.handlerResolver = handlerResolver;
		}

		public async Task CommandAsync<TCommand>(TCommand command)
			where TCommand : ICommand
		{
			if (command == null)
				throw new ArgumentNullException(nameof(command));

			var commandType = typeof(TCommand);
			var handlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);
			var handlers = handlerResolver.GetHandlers(handlerType);

			if (!configuration.AllowVoidCommandDispatch)
				if (handlers.None())
					throw new MissingRegistrationException(commandType);

			if (!configuration.AllowMultipleCommandDispatch)
				if (handlers.Multiple())
					throw new DuplicateRegistrationException(commandType);

			foreach (dynamic handler in handlers)
				await handler.HandleAsync(command as dynamic);
		}
	}
}
