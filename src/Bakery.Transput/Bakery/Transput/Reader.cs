namespace Bakery.Transput
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public class Reader<T>
		: IReader<T>
	{
		private readonly Func<CancellationToken, Task<T>> reader;

		public Reader(Func<CancellationToken, Task<T>> reader)
		{
			this.reader = reader ?? throw new ArgumentNullException(nameof(reader));
		}

		public async Task<T> ReadAsync(CancellationToken cancellationToken)
		{
			return await reader(cancellationToken);
		}
	}
}
