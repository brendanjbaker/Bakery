namespace Bakery.Text
{
	using System;
	using Xunit;

	public class SystemUuidParserTests
	{
		[Fact]
		public void Construct()
		{
			Create();
		}

		[Fact]
		public void ParsingNullIsNull()
		{
			Assert.Null(Create().TryParse(null));
		}

		[Theory]
		[InlineData("")]
		[InlineData("Test")]
		public void ParsingInvalidIsNull(String text)
		{
			Assert.Null(Create().TryParse(text));
		}

		[Theory]
		[InlineData("00000000-0000-0000-0000-000000000000")]
		[InlineData("11112222-3333-4444-5555-666677778888")]
		public void Parse(String text)
		{
			var uuid = Create().TryParse(text);
			var guid = Guid.Parse(text);

			Assert.True(uuid == guid);
		}

		private static SystemUuidParser Create()
		{
			return new SystemUuidParser();
		}
	}
}
