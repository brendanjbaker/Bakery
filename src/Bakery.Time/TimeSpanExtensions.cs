using System;

public static class TimeSpanExtensions
{
	public static Int64 Microseconds(this TimeSpan timeSpan)
	{
		const Int32 MICROSECONDS_PER_MILLISECOND = 1000;
		const Int64 TICKS_PER_MICROSECOND = TimeSpan.TicksPerMillisecond / MICROSECONDS_PER_MILLISECOND;

		return timeSpan.Ticks / TICKS_PER_MICROSECOND;
	}
}
