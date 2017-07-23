namespace Bakery.Cqrs
{
	using System.Threading.Tasks;

	public interface IDispatcher
	{
		Task CommandAsync<TCommand>(TCommand command)
			where TCommand : ICommand;

		Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
	}
}
