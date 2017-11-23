using Bakery.Concurrency;
using System;
using System.Threading;
using System.Threading.Tasks;

public static class GateExtensions
{
	public static async Task WaitAsync(this IGate gate)
	{
		await gate.WaitAsync(TimeSpan.MaxValue, CancellationToken.None);
	}

	public static async Task<Boolean> WaitAsync(this IGate gate, TimeSpan timeout)
	{
		return await gate.WaitAsync(timeout, CancellationToken.None);
	}

	public static async Task<Boolean> WaitAsync(this IGate gate, CancellationToken cancellationToken)
	{
		return await gate.WaitAsync(TimeSpan.MaxValue, cancellationToken);
	}
}
