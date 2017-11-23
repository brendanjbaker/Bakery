namespace Bakery.Concurrency
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public class AutomaticGate
		: IGate
	{
		private readonly Boolean isGateOwner;
		private readonly SemaphoreSlim gate;

		public AutomaticGate()
			: this(new SemaphoreSlim(0, Int32.MaxValue), true) { }

		public AutomaticGate(SemaphoreSlim gate)
			: this(gate, false) { }

		private AutomaticGate(SemaphoreSlim gate, Boolean isGateOwner)
		{
			this.isGateOwner = isGateOwner;
			this.gate = gate ?? throw new ArgumentNullException(nameof(gate));
		}

		public void Dispose()
		{
			if (isGateOwner)
				gate.Dispose();
		}

		public void Open(Int32 count)
		{
			if (count <= 0)
				throw new ArgumentOutOfRangeException(nameof(count));

			gate.Release(count);
		}

		public async Task<Boolean> WaitAsync(TimeSpan timeout, CancellationToken cancellationToken)
		{
			if (gate.Wait(TimeSpan.Zero))
				return true;

			if (timeout == TimeSpan.MaxValue)
				timeout = TimeSpan.FromMilliseconds(-1);

			return await gate.WaitAsync(timeout, cancellationToken);
		}
	}
}
