namespace Bakery.Cqrs
{
	public interface IDispatcher
		: ICommandDispatcher
		, IQueryDispatcher
	{ }
}
