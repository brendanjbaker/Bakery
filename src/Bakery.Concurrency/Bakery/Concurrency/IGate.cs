namespace Bakery.Concurrency
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public interface IGate
		: IDisposable
	{
		Task<Boolean> WaitAsync(TimeSpan timeout, CancellationToken cancellationToken);
	}
}
