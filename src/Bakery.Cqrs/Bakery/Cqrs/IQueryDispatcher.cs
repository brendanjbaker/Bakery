namespace Bakery.Cqrs
{
	using System.Threading.Tasks;

	public interface IQueryDispatcher
	{
		Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
	}
}
