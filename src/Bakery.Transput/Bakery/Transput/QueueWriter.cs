namespace Bakery.Transput
{
	using Bakery.Collections;
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public class QueueWriter<T>
		: IWriter<T>
	{
		private readonly IQueue<T> queue;

		public QueueWriter(IQueue<T> queue)
		{
			this.queue = queue ?? throw new ArgumentNullException(nameof(queue));
		}

		public async Task WriteAsync(T item, CancellationToken cancellationToken)
		{
			await queue.EnqueueAsync(item);
		}
	}
}
