namespace Bakery.Time
{
	using System;

	public class SystemClock
		: IClock
	{
		public DateTime GetUniversalTime()
		{
			return DateTime.UtcNow;
		}
	}
}
