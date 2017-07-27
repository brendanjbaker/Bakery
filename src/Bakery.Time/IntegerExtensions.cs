using System;

public static class IntegerExtensions
{
	public static TimeSpan Days(this Int32 integer)
	{
		return TimeSpan.FromDays(integer);
	}

	public static TimeSpan Hours(this Int32 integer)
	{
		return TimeSpan.FromHours(integer);
	}

	public static TimeSpan Milliseconds(this Int32 integer)
	{
		return TimeSpan.FromMilliseconds(integer);
	}

	public static TimeSpan Minutes(this Int32 integer)
	{
		return TimeSpan.FromMinutes(integer);
	}

	public static TimeSpan Seconds(this Int32 integer)
	{
		return TimeSpan.FromSeconds(integer);
	}
}
