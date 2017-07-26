namespace Bakery.Cqrs
{
	using Configuration;
	using SimpleInjector;
	using System;
	using System.Linq;
	using System.Threading.Tasks;

	public class SimpleInjectorCommandDispatcher
		: ICommandDispatcher
	{
		private readonly IConfiguration configuration;
		private readonly Container container;

		public SimpleInjectorCommandDispatcher(IConfiguration configuration, Container container)
		{
			if (configuration == null)
				throw new ArgumentNullException(nameof(configuration));

			if (container == null)
				throw new ArgumentNullException(nameof(container));

			this.configuration = configuration;
			this.container = container;
		}

		public async Task CommandAsync<TCommand>(TCommand command)
			where TCommand : ICommand
		{
			if (command == null)
				throw new ArgumentNullException(nameof(command));

			var handlers = container.GetAllInstances<ICommandHandler<TCommand>>().ToArray();

			if (handlers.None())
				throw new NoRegistrationFoundException(typeof(TCommand));

			if (!configuration.AllowMultipleCommandDispatch)
				if (handlers.Multiple())
					throw new MultipleRegistrationsFoundException(typeof(TCommand));

			await Task.WhenAll(
				handlers.Select(
					h => h.HandleAsync(command)));
		}
	}
}
