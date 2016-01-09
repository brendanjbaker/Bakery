namespace Bakery.Time
{
	using System;

	public class FriendlyDateTimePrinter
		: IDateTimePrinter
	{
		public String Print(DateTime instance)
		{
			return instance.ToString("d-MMM-yyyy h:mm tt");
		}
	}
}
