using Nito.AsyncEx;
using System;
using System.Threading;
using System.Threading.Tasks;

internal static class AsyncSemaphoreExtensions
{
	public static async Task<Boolean> WaitAsync(this AsyncSemaphore asyncSemaphore, TimeSpan timeout)
	{
		var cancellationTokenSource = new CancellationTokenSource(timeout);
		var cancellationToken = cancellationTokenSource.Token;
		var waitTask = asyncSemaphore.WaitAsync(cancellationToken);

		return await waitTask.ContinueWith(t =>
		{
			return !t.IsCanceled;
		});
	}
}
