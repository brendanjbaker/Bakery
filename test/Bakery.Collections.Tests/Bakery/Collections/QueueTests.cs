namespace Bakery.Collections
{
	using System;
	using System.Threading.Tasks;
	using Xunit;

	public class QueueTests
	{
		[Theory]
		[InlineData(0)]
		[InlineData(100)]
		public async Task NotAvailableWhenNoItems(Int32 timeoutMilliseconds)
		{
			var queue = new Queue<String>();

			var dequeued = await queue.DequeueAsync(TimeSpan.FromMilliseconds(timeoutMilliseconds));

			Assert.Null(dequeued);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(100)]
		public async Task AvailableWhenAlreadyQueued(Int32 timeoutMilliseconds)
		{
			var queue = new Queue<String>();

			queue.Enqueue("Test");

			var dequeued = await queue.DequeueAsync(TimeSpan.FromMilliseconds(timeoutMilliseconds));

			Assert.Equal(dequeued, "Test");
		}

		[Theory]
		[InlineData(100, 500)]
		public async Task AvailableWhenQueuedAfterwards(Int32 enqueueDelayMilliseconds, Int32 dequeueTimeoutMilliseconds)
		{
			var queue = new Queue<String>();

			Queue(queue, "Test", TimeSpan.FromMilliseconds(enqueueDelayMilliseconds));

			var dequeued = await queue.DequeueAsync(TimeSpan.FromMilliseconds(dequeueTimeoutMilliseconds));

			Assert.Equal(dequeued, "Test");
		}

		[Theory]
		[InlineData(500, 100)]
		public async Task NotAvailableWhenQueuedTooLate(Int32 enqueueDelayMilliseconds, Int32 dequeueTimeoutMilliseconds)
		{
			var queue = new Queue<String>();

			Queue(queue, "Test", TimeSpan.FromMilliseconds(enqueueDelayMilliseconds));

			var dequeued = await queue.DequeueAsync(TimeSpan.FromMilliseconds(dequeueTimeoutMilliseconds));

			Assert.Null(dequeued);
		}

		private static async void Queue<T>(IQueue<T> queue, T item, TimeSpan delay)
		{
			await Task.Delay(delay);

			queue.Enqueue(item);
		}
	}
}
