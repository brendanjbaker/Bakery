using Bakery.Transput;
using System;
using System.Threading;
using System.Threading.Tasks;

public static class WriterExtensions
{
	public static void Write<T>(this IWriter<T> writer, T item)
	{
		writer.WriteAsync(item, CancellationToken.None).GetAwaiter().GetResult();
		writer.Write(item, CancellationToken.None);
	}

	public static void Write<T>(this IWriter<T> writer, T item, CancellationToken cancellationToken)
	{
		writer.WriteAsync(item, cancellationToken).GetAwaiter().GetResult();
	}

	public static async Task WriteAsync<T>(this IWriter<T> writer, T item)
	{
		await writer.WriteAsync(item, CancellationToken.None);
	}

	public static async Task WriteAsync<T>(this IWriter<T> writer, T item, TimeSpan timeout)
	{
		using (var cancellationTokenSource = new CancellationTokenSource(timeout))
			await writer.WriteAsync(item, cancellationTokenSource.Token);
	}
}
