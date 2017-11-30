namespace Bakery.Transput
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public class ConsoleWriter<T>
		: IWriter<T>
	{
		public async Task WriteAsync(T item, CancellationToken cancellationToken)
		{
			await Console.Out.WriteLineAsync(item.ToString());
		}
	}
}
