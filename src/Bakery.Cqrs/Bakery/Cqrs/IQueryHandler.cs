namespace Bakery.Cqrs
{
	using System.Threading.Tasks;

	public interface IQueryHandler<TQuery, TResult>
		where TQuery : IQuery<TResult>
	{
		Task<TResult> HandleAsync(TQuery query);
	}
}
