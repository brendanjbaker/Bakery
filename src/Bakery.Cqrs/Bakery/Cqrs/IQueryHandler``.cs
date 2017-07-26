namespace Bakery.Cqrs
{
	using System.Threading.Tasks;

	public interface IQueryHandler<TQuery, TResult>
		: IQueryHandler

		where TQuery : IQuery<TResult>
	{
		Task<TResult> HandleAsync(TQuery query);
	}
}
