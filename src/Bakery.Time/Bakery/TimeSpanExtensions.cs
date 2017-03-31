namespace Bakery
{
	using System;

	public static class TimeSpanExtensions
	{
		public static Int64 Microseconds(this TimeSpan timeSpan)
		{
			const Int32 MICROSECONDS_PER_MILLISECOND = 1000;

			var ticksPerMicrosecond = TimeSpan.TicksPerMillisecond / MICROSECONDS_PER_MILLISECOND;

			return timeSpan.Ticks / ticksPerMicrosecond;
		}
	}
}
