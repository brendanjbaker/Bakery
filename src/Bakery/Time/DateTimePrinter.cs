namespace Bakery.Time
{
	using System;
	using Text;

	public class DateTimePrinter
		: IPrinter<DateTime>
	{
		private readonly String format;

		public DateTimePrinter(String format)
		{
			this.format = format;
		}

		public String Print(DateTime instance)
		{
			return instance.ToString(format);
		}
	}
}
