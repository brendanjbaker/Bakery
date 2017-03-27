namespace Bakery.Time
{
	using System;
	using System.Diagnostics;

	public class SystemStopwatch
		: IStopwatch
	{
		private readonly Stopwatch stopwatch;

		public SystemStopwatch(Stopwatch stopwatch)
		{
			if (stopwatch == null)
				throw new ArgumentNullException(nameof(stopwatch));

			this.stopwatch = stopwatch;
		}

		public TimeSpan Elapsed
		{
			get { return stopwatch.Elapsed; }
		}

		public void Start()
		{
			stopwatch.Start();
		}

		public void Stop()
		{
			stopwatch.Stop();
		}
	}
}
