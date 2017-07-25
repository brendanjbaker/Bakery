namespace Bakery.Cqrs
{
	using SimpleInjector;
	using System;
	using System.Linq;
	using System.Threading.Tasks;

	public class SimpleInjectorCommandDispatcher
		: ICommandDispatcher
	{
		private readonly Container container;

		public SimpleInjectorCommandDispatcher(Container container)
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

			if (handlers.None())
				throw new NoRegistrationFoundException(typeof(TCommand));

			await Task.WhenAll(
				handlers.Select(
					h => h.HandleAsync(command)));
		}
	}
}
