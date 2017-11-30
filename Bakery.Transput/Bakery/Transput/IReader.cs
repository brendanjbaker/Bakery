namespace Bakery.Transput
{
	using System.Threading;
	using System.Threading.Tasks;

	public interface IReader<T>
	{
		Task<T> ReadAsync(CancellationToken cancellationToken);
	}
}
