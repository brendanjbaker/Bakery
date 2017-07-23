namespace Bakery.Cqrs
{
	using System.Threading.Tasks;

	public interface ICommandHandler<TCommand>
		where TCommand : ICommand
	{
		Task HandleAsync(TCommand command);
	}
}
