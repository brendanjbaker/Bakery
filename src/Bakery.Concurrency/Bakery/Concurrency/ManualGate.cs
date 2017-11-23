namespace Bakery.Concurrency
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public class ManualGate
		: IGate
	{
		private readonly ManualResetEventSlim gate;
		private readonly Boolean isGateOwner;

		public ManualGate()
			: this(new ManualResetEventSlim(), true) { }

		public ManualGate(ManualResetEventSlim gate)
			: this(gate, false) { }

		public ManualGate(ManualResetEventSlim gate, Boolean isGateOwner)
		{
			this.gate = gate ?? throw new ArgumentNullException(nameof(gate));
			this.isGateOwner = isGateOwner;
		}

		public void Close()
		{
			gate.Reset();
		}

		public void Dispose()
		{
			if (isGateOwner)
				gate.Dispose();
		}

		public void Open()
		{
			gate.Set();
		}

		public async Task<Boolean> WaitAsync(TimeSpan timeout, CancellationToken cancellationToken)
		{
			if (gate.Wait(TimeSpan.Zero))
				return true;

			if (timeout == TimeSpan.MaxValue)
				timeout = TimeSpan.FromMilliseconds(-1);

			return await Task.Run(() =>
			{
				try
				{
					return gate.Wait(timeout, cancellationToken);
				}
				catch (OperationCanceledException)
				{
					return false;
				}
			});
		}
	}
}
