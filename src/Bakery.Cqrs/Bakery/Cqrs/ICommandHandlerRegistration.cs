namespace Bakery.Cqrs
{
	using System.Threading.Tasks;

	public interface ICommandHandlerRegistration<TCommand>
		: IRegistration
	{
		Task HandleAsync(TCommand command);
	}
}
