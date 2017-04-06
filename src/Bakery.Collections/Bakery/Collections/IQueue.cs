namespace Bakery.Collections
{
	using System;
	using System.Threading.Tasks;

	public interface IQueue<T>
	{
		void Enqueue(T item);
		Task<T> TryDequeueAsync(TimeSpan timeout);
	}
}
