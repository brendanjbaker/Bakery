namespace Bakery.Transput
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public class Writer<T>
		: IWriter<T>
	{
		private readonly Func<T, CancellationToken, Task> writer;

		public Writer(Func<T, CancellationToken, Task> writer)
		{
			this.writer = writer ?? throw new ArgumentNullException(nameof(writer));
		}

		public async Task WriteAsync(T item, CancellationToken cancellationToken)
		{
			await writer(item, cancellationToken);
		}
	}
}
