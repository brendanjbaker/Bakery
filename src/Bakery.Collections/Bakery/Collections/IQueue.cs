namespace Bakery.Collections
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public interface IQueue<T>
	{
		Task EnqueueAsync(T item, CancellationToken cancellationToken);
		Task<T> DequeueAsync(TimeSpan timeout, CancellationToken cancellationToken);
	}
}
