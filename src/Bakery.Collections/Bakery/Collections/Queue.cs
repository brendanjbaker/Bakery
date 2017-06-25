namespace Bakery.Collections
{
	using Exceptions;
	using Nito.AsyncEx;
	using System;
	using System.Threading.Tasks;

	public class Queue<T>
		: IQueue<T>
	{
		private readonly AsyncSemaphore gate;
		private readonly System.Collections.Generic.Queue<T> queue;

		public Queue()
		{
			queue = new System.Collections.Generic.Queue<T>();
			gate = new AsyncSemaphore(0);
		}

		public void Enqueue(T item)
		{
			lock (queue)
				queue.Enqueue(item);

			gate.Release();
		}

		public async Task<T> TryDequeueAsync(TimeSpan timeout)
		{
			if (timeout < TimeSpan.Zero)
				throw new ArgumentNegativeException(nameof(timeout));

			if (await gate.WaitAsync(timeout))
				lock (queue)
					return queue.Dequeue();

			return default(T);
		}
	}
}
