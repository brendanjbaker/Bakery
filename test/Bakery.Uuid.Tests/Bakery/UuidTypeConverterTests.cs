namespace Bakery
{
	using System;
	using Xunit;

	public class UuidTypeConverterTests
	{
		[Fact]
		public void CanConvertFromGuid()
		{
			Assert.True(CreateTestInstance().CanConvertFrom(typeof(Guid)));
		}

		[Fact]
		public void CanConvertFromString()
		{
			Assert.True(CreateTestInstance().CanConvertFrom(typeof(String)));
		}

		[Fact]
		public void CanConvertToUuid()
		{
			Assert.True(CreateTestInstance().CanConvertTo(typeof(Uuid)));
		}

		[Fact]
		public void CanConvertToNullableUuid()
		{
			Assert.True(CreateTestInstance().CanConvertTo(typeof(Uuid?)));
		}

		[Theory]
		[InlineData("00000000000000000000000000000000")]
		[InlineData("00000000-0000-0000-0000-000000000000")]
		public void ConvertFromString(String text)
		{
			Assert.IsType<Uuid>(CreateTestInstance().ConvertFrom(text));
		}

		[Theory]
		[InlineData("00000000-0000-0000-0000-000000000000")]
		public void ConvertFromGuid(String text)
		{
			Assert.IsType<Uuid>(CreateTestInstance().ConvertFrom(Guid.Parse(text)));
		}

		private static UuidTypeConverter CreateTestInstance()
		{
			return new UuidTypeConverter();
		}
	}
}
