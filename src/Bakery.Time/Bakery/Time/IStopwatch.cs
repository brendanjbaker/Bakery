namespace Bakery.Time
{
	using System;

	public interface IStopwatch
	{
		TimeSpan Elapsed { get; }

		void Start();
		void Stop();
	}
}
