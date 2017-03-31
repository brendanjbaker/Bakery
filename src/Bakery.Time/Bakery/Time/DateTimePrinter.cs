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
			if (format == null)
				throw new ArgumentNullException(nameof(format));

			this.format = format;
		}

		public String Print(DateTime instance)
		{
			if (instance == null)
				throw new ArgumentNullException(nameof(instance));

			return instance.ToString(format);
		}
	}
}
