using System;

public static class DateTimeExtensions
{
	private static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	public static Int64 ToUnixTimestamp(this DateTime instance, Boolean useMilliseconds = false)
	{
		var elapsed = instance.ToUniversalTime() - UNIX_EPOCH;

		return useMilliseconds
			? (Int64)elapsed.TotalMilliseconds
			: (Int64)elapsed.TotalSeconds;
	}
}
