namespace Bakery.Collections
{
	using Bakery.Concurrency;
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public class Queue<T>
		: IQueue<T>
	{
		private readonly AutomaticGate gate;
		private readonly System.Collections.Generic.Queue<T> queue;

		public Queue()
		{
			queue = new System.Collections.Generic.Queue<T>();
			gate = new AutomaticGate();
		}

		public Task EnqueueAsync(T item, CancellationToken cancellationToken)
		{
			lock (queue)
				queue.Enqueue(item);

			gate.Open();

			return Task.CompletedTask;
		}

		public async Task<T> DequeueAsync(TimeSpan timeout, CancellationToken cancellationToken)
		{
			await gate.WaitAsync(timeout, cancellationToken);

			lock (queue)
				return queue.Dequeue();
		}
	}
}
