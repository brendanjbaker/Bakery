namespace Bakery.Time
{
	using System;
	using System.Diagnostics;
	using System.Threading.Tasks;
	using Xunit;

	public class SystemStopwatchTests
	{
		[Fact]
		public async Task Advances()
		{
			var stopwatch = CreateTestInstance();

			stopwatch.Start();

			await Task.Delay(TimeSpan.FromMilliseconds(25));

			var elapsed1 = stopwatch.Elapsed;

			await Task.Delay(TimeSpan.FromMilliseconds(25));

			var elapsed2 = stopwatch.Elapsed;

			Assert.True(elapsed2 > elapsed1);
		}

		[Fact]
		public async Task ReasonablyAccurate()
		{
			var stopwatch = CreateTestInstance();

			stopwatch.Start();

			await Task.Delay(TimeSpan.FromMilliseconds(25));

			stopwatch.Stop();

			Assert.True(stopwatch.Elapsed < TimeSpan.FromSeconds(1));
		}

		[Fact]
		public async Task Restarts()
		{
			var stopwatch = CreateTestInstance();

			stopwatch.Start();

			await Task.Delay(TimeSpan.FromMilliseconds(25));

			stopwatch.Stop();

			var elapsed1 = stopwatch.Elapsed;

			stopwatch.Start();

			await Task.Delay(TimeSpan.FromMilliseconds(25));

			stopwatch.Stop();

			var elapsed2 = stopwatch.Elapsed;

			Assert.True(elapsed2 > elapsed1);
		}

		[Fact]
		public async Task SameAfterStopping()
		{
			var stopwatch = CreateTestInstance();

			stopwatch.Start();

			await Task.Delay(TimeSpan.FromMilliseconds(25));

			stopwatch.Stop();

			await Task.Delay(TimeSpan.FromMilliseconds(25));

			var elapsed1 = stopwatch.Elapsed.TotalMilliseconds;

			await Task.Delay(TimeSpan.FromMilliseconds(25));

			var elapsed2 = stopwatch.Elapsed.TotalMilliseconds;

			Assert.True(elapsed1 == elapsed2);
		}

		[Fact]
		public void StartRepeatedly()
		{
			var stopwatch = CreateTestInstance();

			stopwatch.Start();
			stopwatch.Start();
		}

		[Fact]
		public void StopRepeatedly()
		{
			var stopwatch = CreateTestInstance();

			stopwatch.Stop();
			stopwatch.Stop();
		}

		[Fact]
		public void ZeroBeforeStarting()
		{
			Assert.True(CreateTestInstance().Elapsed == TimeSpan.Zero);
		}

		private static SystemStopwatch CreateTestInstance()
		{
			return new SystemStopwatch(new Stopwatch());
		}
	}
}
