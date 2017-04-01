namespace Bakery.Time
{
	using System;
	using System.Threading.Tasks;
	using Xunit;

	public class SystemClockTests
	{
		[Fact]
		public async Task IsAdvancing()
		{
			var time1 = CreateTestInstance().GetUniversalTime();

			await Task.Delay(TimeSpan.FromMilliseconds(25));

			var time2 = CreateTestInstance().GetUniversalTime();

			Assert.True(time2 > time1);
		}

		[Fact]
		public void IsReasonablyAccurate()
		{
			var time1 = DateTime.UtcNow;
			var time2 = CreateTestInstance().GetUniversalTime();

			var span = time2 - time1;

			Assert.True(span < TimeSpan.FromSeconds(1));
		}

		[Fact]
		public void IsUsingUniversalTime()
		{
			Assert.True(CreateTestInstance().GetUniversalTime().Kind == DateTimeKind.Utc);
		}

		private static SystemClock CreateTestInstance()
		{
			return new SystemClock();
		}
	}
}
