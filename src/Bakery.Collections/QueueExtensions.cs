namespace Bakery.Collections
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public static class QueueExtensions
	{
		public static async Task<T> DequeueAsync<T>(this IQueue<T> queue, CancellationToken cancellationToken)
		{
			return await queue.DequeueAsync(TimeSpan.MaxValue, cancellationToken);
		}

		public static async Task<T> DequeueAsync<T>(this IQueue<T> queue, TimeSpan timeout)
		{
			return await queue.DequeueAsync(timeout, CancellationToken.None);
		}

		public static void Enqueue<T>(this IQueue<T> queue, T item)
		{
			queue
				.EnqueueAsync(item, CancellationToken.None)
				.GetAwaiter()
				.GetResult();
		}

		public static async Task EnqueueAsync<T>(this IQueue<T> queue, T item)
		{
			await queue.EnqueueAsync(item, CancellationToken.None);
		}
	}
}
