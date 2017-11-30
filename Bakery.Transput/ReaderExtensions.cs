using Bakery.Transput;
using System;
using System.Threading;
using System.Threading.Tasks;

public static class ReaderExtensions
{
	public static T Read<T>(this IReader<T> reader)
	{
		return reader.ReadAsync(CancellationToken.None).GetAwaiter().GetResult();
	}

	public static T Read<T>(this IReader<T> reader, CancellationToken cancellationToken)
	{
		return reader.ReadAsync(cancellationToken).GetAwaiter().GetResult();
	}

	public static async Task<T> ReadAsync<T>(this IReader<T> reader)
	{
		return await reader.ReadAsync(CancellationToken.None);
	}

	public static async Task<T> ReadAsync<T>(this IReader<T> reader, TimeSpan timeout)
	{
		using (var cancellationTokenSource = new CancellationTokenSource(timeout))
			return await reader.ReadAsync(cancellationTokenSource.Token);
	}
}
