namespace Bakery.Cqrs
{
	using System;
	using System.Threading.Tasks;

	public interface IQueryHandlerRegistration<TQuery>
		: IRegistration
	{
		Task<Object> HandleAsync(TQuery query);
	}
}
