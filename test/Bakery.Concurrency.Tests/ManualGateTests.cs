namespace Bakery.Concurrency.Tests
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using Xunit;

	public class ManualGateTests
	{
		[Fact]
		public async Task Close_PreventsThreads()
		{
			var gate = new ManualGate();

			gate.Close();

			var waitResult = await gate.WaitAsync(TimeSpan.FromSeconds(1));

			Assert.False(waitResult);
		}

		[Fact]
		public async Task Close_PreventsThreads_AfterBeginOpen()
		{
			var gate = new ManualGate();

			gate.Open();

			await gate.WaitAsync();

			gate.Close();

			var waitResult = await gate.WaitAsync(TimeSpan.FromSeconds(1));

			Assert.False(waitResult);
		}

		[Fact]
		public async Task Open_AllowsMultipleThreads()
		{
			var gate = new ManualGate();

			gate.Open();

			var waitResult1 = await gate.WaitAsync(TimeSpan.Zero);
			var waitResult2 = await gate.WaitAsync(TimeSpan.Zero);

			Assert.True(waitResult1 && waitResult2);
		}

		[Fact]
		public void WaitAsync_DoesNotBlock()
		{
			var beginTime = DateTime.UtcNow;
			var threshold = TimeSpan.FromSeconds(10);
			var gate = new ManualGate();
			var waitTask = gate.WaitAsync(threshold);

			Assert.True(DateTime.UtcNow < beginTime + threshold);
		}

		[Fact]
		public async Task WaitAsync_ReturnsFalse_AfterCancellationRequested()
		{
			var cancellationTokenSource = new CancellationTokenSource();
			var cancellationToken = cancellationTokenSource.Token;
			var gate = new ManualGate();

			var waitTask = gate.WaitAsync(TimeSpan.MaxValue, cancellationToken);

			cancellationTokenSource.Cancel();

			var result = await waitTask;

			Assert.False(result);
		}

		[Fact]
		public async Task WaitAsync_ReturnsFalse_AfterTimeoutElapsed()
		{
			var threshold = TimeSpan.FromMilliseconds(1);
			var gate = new ManualGate();

			var wasOpened = await gate.WaitAsync(threshold);

			Assert.False(wasOpened);
		}

		[Fact]
		public async Task WaitAsync_ReturnsTrue_WhenOpened_AfterWaiting()
		{
			var threshold = TimeSpan.FromSeconds(1);
			var gate = new ManualGate();

			var waitTask = gate.WaitAsync(threshold);

			gate.Open();

			var wasOpened = await waitTask;

			Assert.True(wasOpened);
		}

		[Fact]
		public async Task WaitAsync_ReturnsTrue_WhenOpened_BeforeWaiting()
		{
			var threshold = TimeSpan.FromSeconds(1);
			var gate = new ManualGate();

			gate.Open();

			var wasOpened = await gate.WaitAsync(threshold);

			Assert.True(wasOpened);
		}

		[Fact]
		public async Task WaitAsync_TimesOut_AfterTimeoutElapsed()
		{
			var beginTime = DateTime.UtcNow;
			var threshold = TimeSpan.FromSeconds(1);
			var gate = new ManualGate();

			await gate.WaitAsync(threshold);

			Assert.True(DateTime.UtcNow >= beginTime + threshold);
		}
	}
}
