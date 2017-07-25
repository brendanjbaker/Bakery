namespace Bakery.Cqrs
{
	using System;
	using System.Threading.Tasks;

	public class Dispatcher
		: IDispatcher
	{
		private readonly ICommandDispatcher commandDispatcher;
		private readonly IQueryDispatcher queryDispatcher;

		public Dispatcher(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
		{
			if (commandDispatcher == null)
				throw new ArgumentNullException(nameof(commandDispatcher));

			if (queryDispatcher == null)
				throw new ArgumentNullException(nameof(queryDispatcher));

			this.commandDispatcher = commandDispatcher;
			this.queryDispatcher = queryDispatcher;
		}

		public async Task CommandAsync<TCommand>(TCommand command)
			where TCommand : ICommand
		{
			await commandDispatcher.CommandAsync(command);
		}

		public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
		{
			return await queryDispatcher.QueryAsync(query);
		}
	}
}
