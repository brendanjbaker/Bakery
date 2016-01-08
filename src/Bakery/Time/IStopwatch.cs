namespace Bakery.Time
{
	using System;

	public interface IStopwatch
	{
		void Start();
		void Stop();

		TimeSpan Elapsed { get; }
	}
}
