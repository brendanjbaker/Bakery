namespace Bakery.Cqrs
{
	using System.Threading.Tasks;

	public interface ICommandHandler<TCommand>
		: ICommandHandler

		where TCommand : ICommand
	{
		Task HandleAsync(TCommand command);
	}
}
