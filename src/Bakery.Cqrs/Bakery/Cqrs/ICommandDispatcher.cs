namespace Bakery.Cqrs
{
	using System.Threading.Tasks;

	public interface ICommandDispatcher
	{
		Task CommandAsync<TCommand>(TCommand command)
			where TCommand : ICommand;
	}
}
