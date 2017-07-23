namespace Bakery.Cqrs
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public class Dispatcher
		: IDispatcher
	{
		private readonly IEnumerable<IRegistration> registrations;

		public Dispatcher(IEnumerable<IRegistration> registrations)
		{
			this.registrations = registrations;
		}

		public async Task CommandAsync<TCommand>(TCommand command)
			where TCommand : ICommand
		{
			await GetRegistration(typeof(TCommand)).ExecuteAsync(command);
		}

		public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
		{
			var result = await GetRegistration(query.GetType()).ExecuteAsync(query);

			return (TResult)result;
		}

		private IRegistration GetRegistration(Type type)
		{
			var candidates =
				registrations
					.Where(r => r.Type == type)
					.ToArray();

			if (!candidates.Any())
				throw new NoRegistrationFoundException(type);

			if (candidates.Multiple())
				throw new MultipleRegistrationsFoundException(type);

			return candidates.Single();
		}
	}
}
