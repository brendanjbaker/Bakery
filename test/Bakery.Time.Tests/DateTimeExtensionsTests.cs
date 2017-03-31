using System;
using Xunit;

public class DateTimeExtensionsTests
{
	[Fact]
	public void UnixEpochIsZero()
	{
		var unixEpoch = new DateTime(1970, 1, 1, 00, 00, 00, DateTimeKind.Utc);

		Assert.True(unixEpoch.ToUnixTimestamp() == 0);
	}

	[Fact]
	public void OneSecondAfterUnixEpochIsOne()
	{
		var unixEpoch = new DateTime(1970, 1, 1, 00, 00, 01, DateTimeKind.Utc);

		Assert.True(unixEpoch.ToUnixTimestamp() == 1);
	}

	[Fact]
	public void OneSecondAfterUnixEpochInMillisecondsIsOneThousand()
	{
		var unixEpoch = new DateTime(1970, 1, 1, 00, 00, 01, DateTimeKind.Utc);

		Assert.True(unixEpoch.ToUnixTimestamp(true) == 1000);
	}

	[Fact]
	public void OneSecondBeforeUnixEpochIsNegativeOne()
	{
		var unixEpoch = new DateTime(1969, 12, 31, 23, 59, 59, DateTimeKind.Utc);

		Assert.True(unixEpoch.ToUnixTimestamp() == -1);
	}
}
