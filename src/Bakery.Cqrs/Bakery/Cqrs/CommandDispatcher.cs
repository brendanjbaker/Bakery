namespace Bakery.Cqrs
{
	using Exception;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public class CommandDispatcher
		: ICommandDispatcher
	{
		private readonly IEnumerable<IRegistration> registrations;

		public CommandDispatcher(IEnumerable<IRegistration> registrations)
		{
			if (registrations == null)
				throw new ArgumentNullException(nameof(registrations));

			this.registrations = registrations;
		}

		public async Task CommandAsync<TCommand>(TCommand command)
			where TCommand : ICommand
		{
			if (command == null)
				throw new ArgumentNullException(nameof(command));

			var matching = GetMatchingRegistrations<TCommand>();

			if (matching.None())
				throw new MissingRegistrationException(typeof(TCommand));

			await Task.WhenAll(
				matching.Select(
					m => m.ExecuteAsync(command)));
		}

		private IRegistration[] GetMatchingRegistrations<TCommand>()
		{
			return registrations.Where(r => r.Type == typeof(TCommand)).ToArray();
		}
	}
}
