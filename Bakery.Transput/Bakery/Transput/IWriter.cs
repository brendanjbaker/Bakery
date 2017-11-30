namespace Bakery.Transput
{
	using System.Threading;
	using System.Threading.Tasks;

	public interface IWriter<T>
	{
		Task WriteAsync(T item, CancellationToken cancellationToken);
	}
}
