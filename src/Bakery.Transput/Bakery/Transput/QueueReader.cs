namespace Bakery.Transput
{
	using Bakery.Collections;
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public class QueueReader<T>
		: IReader<T>
	{
		private readonly IQueue<T> queue;

		public QueueReader(IQueue<T> queue)
		{
			this.queue = queue ?? throw new ArgumentNullException(nameof(queue));
		}

		public async Task<T> ReadAsync(CancellationToken cancellationToken)
		{
			return await queue.DequeueAsync(cancellationToken);
		}
	}
}
