namespace Bakery.Time
{
	using System;
	using Xunit;

	public class FriendlyDateTimePrinterTests
	{
		[Theory]
		[InlineData("0005-01-01T00:00:00Z", "1-Jan-0005 12:00 AM")]
		[InlineData("2000-01-01T00:00:00Z", "1-Jan-2000 12:00 AM")]
		[InlineData("2000-01-01T06:00:00Z", "1-Jan-2000 6:00 AM")]
		[InlineData("2000-01-01T12:00:00Z", "1-Jan-2000 12:00 PM")]
		[InlineData("2000-05-01T00:00:00Z", "1-May-2000 12:00 AM")]
		[InlineData("2000-05-10T00:00:00Z", "10-May-2000 12:00 AM")]
		[InlineData("9999-12-31T23:59:59Z", "31-Dec-9999 11:59 PM")]
		public void MatchesExpectedFormat(String input, String expected)
		{
			var printer = CreateTestInstance();
			var time = DateTime.Parse(input).ToUniversalTime();

			Assert.Equal(expected, printer.Print(time));
		}

		private static FriendlyDateTimePrinter CreateTestInstance()
		{
			return new FriendlyDateTimePrinter();
		}
	}
}
