using System;
using Xunit;

public class TimeSpanExtensionsTests
{
	[Fact]
	public void ZeroSecondsIsZeroMicroseconds()
	{
		Assert.True(TimeSpan.Zero.Microseconds() == 0);
	}

	[Fact]
	public void OneSecondIsOneMillionMicroseconds()
	{
		Assert.True(TimeSpan.FromSeconds(1).Microseconds() == 1000000);
	}

	[Fact]
	public void NegativeOneSecondIsNegativeOneMillionMicroseconds()
	{
		Assert.True(TimeSpan.FromSeconds(-1).Microseconds() == -1000000);
	}
}
