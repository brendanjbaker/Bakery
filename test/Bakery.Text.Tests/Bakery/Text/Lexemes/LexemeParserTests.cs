namespace Bakery.Text.Lexemes
{
	using System;
	using System.Linq;
	using Xunit;

	public class LexemeParserTests
	{
		[Fact]
		public void Parse_ThrowsNullArgumentException_IfArgumentIsNull()
		{
			Assert.Throws<ArgumentNullException>(() => CreateInstance().Parse(null));
		}

		[Fact]
		public void Parse_EmptyString_ReturnsEmptySet()
		{
			Assert.Empty(CreateInstance().Parse(String.Empty));
		}

		[Theory]
		[InlineData(" ", LexemeType.Whitespace, 0)]
		[InlineData("  ", LexemeType.Whitespace, 0)]
		[InlineData(" a", LexemeType.Text, 1)]
		[InlineData("a", LexemeType.Text, 0)]
		[InlineData("aa", LexemeType.Text, 0)]
		[InlineData("\n", LexemeType.Newline, 0)]
		[InlineData("\n\n", LexemeType.Newline, 0)]
		[InlineData("\n\n", LexemeType.Newline, 1)]
		public void Parse_ReturnsCorrectType(String @string, LexemeType type, Int32 index)
		{
			Assert.Equal(type, CreateInstance().Parse(@string).ToArray()[index].Type);
		}

		[Theory]
		[InlineData(" ")]
		[InlineData("  ")]
		[InlineData("   ")]
		[InlineData(" \t")]
		[InlineData(" \r")]
		[InlineData("a")]
		[InlineData("ab")]
		[InlineData("abc")]
		[InlineData("ab-c")]
		[InlineData("\n")]
		public void Parse_SingleLexeme_ReturnsSingleLexeme(String @string)
		{
			Assert.Single(CreateInstance().Parse(@string));
		}

		private static LexemeParser CreateInstance()
		{
			return new LexemeParser();
		}
	}
}
