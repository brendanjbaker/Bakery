using System;

public static class IntegerExtensions
{
	private static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

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

	public static DateTime ToDateTime(this Int64 integer, Boolean useMilliseconds = false)
	{
		return useMilliseconds
			? UNIX_EPOCH.AddMilliseconds(integer)
			: UNIX_EPOCH.AddSeconds(integer);
	}
}
