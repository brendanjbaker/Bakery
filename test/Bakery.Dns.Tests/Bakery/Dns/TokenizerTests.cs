namespace Bakery.Dns
{
	using Bakery.Dns.Tokenization;
	using Bakery.Text;
	using System;
	using System.IO;
	using System.Linq;
	using System.Net.Http;
	using System.Threading.Tasks;
	using Xunit;

	public class TokenizerTests
	{
		[Fact]
		public void Tokenize_Null_ThrowsArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => CreateInstance().Tokenize(null));
		}

		[Fact]
		public void Tokenize_EmptyString_ReturnsEmptySet()
		{
			Assert.Empty(CreateInstance().Tokenize(String.Empty));
		}

		[Theory]
		[InlineData(WhitespaceCharacter.CARRAIGE_RETURN)]
		[InlineData(WhitespaceCharacter.NEXT_LINE)]
		[InlineData(WhitespaceCharacter.NON_BREAKING_SPACE)]
		[InlineData(WhitespaceCharacter.SPACE)]
		[InlineData(WhitespaceCharacter.TAB)]
		[InlineData(WhitespaceCharacter.VERTICAL_TAB)]
		public void Tokenize_WhitespaceCharacter_ReturnsSingleToken(Char whitespaceCharacter)
		{
			Assert.Equal(1, CreateInstance().Tokenize(whitespaceCharacter.ToString()).Count());
		}

		[Theory]
		[InlineData(WhitespaceCharacter.CARRAIGE_RETURN)]
		[InlineData(WhitespaceCharacter.NEXT_LINE)]
		[InlineData(WhitespaceCharacter.NON_BREAKING_SPACE)]
		[InlineData(WhitespaceCharacter.SPACE)]
		[InlineData(WhitespaceCharacter.TAB)]
		[InlineData(WhitespaceCharacter.VERTICAL_TAB)]
		public void Tokenize_WhitespaceCharacter_ReturnsWhitespaceToken(Char whitespaceCharacter)
		{
			Assert.Equal(TokenType.Whitespace, CreateInstance().Tokenize(whitespaceCharacter.ToString()).Single().Type);
		}

		[Theory]
		[InlineData(WhitespaceCharacter.CARRAIGE_RETURN)]
		[InlineData(WhitespaceCharacter.NEXT_LINE)]
		[InlineData(WhitespaceCharacter.NON_BREAKING_SPACE)]
		[InlineData(WhitespaceCharacter.SPACE)]
		[InlineData(WhitespaceCharacter.TAB)]
		[InlineData(WhitespaceCharacter.VERTICAL_TAB)]
		public void Tokenize_WhitespaceCharacter_ReturnsSourceText(Char whitespaceCharacter)
		{
			Assert.Equal(whitespaceCharacter.ToString(), CreateInstance().Tokenize(whitespaceCharacter.ToString()).Single().Text);
		}

		[Fact]
		public void Tokenize_MultipleWhitespaceCharacters_ReturnsSingleToken()
		{
			Assert.Equal(1, CreateInstance().Tokenize("  ").Count());
		}

		[Fact]
		public void Tokenize_Exclamation_ReturnsSingleToken()
		{
			Assert.Equal(1, CreateInstance().Tokenize("!").Count());
		}

		[Fact]
		public void Tokenize_Exclamation_ReturnsExclamationToken()
		{
			Assert.Equal(TokenType.Exclamation, CreateInstance().Tokenize("!").Single().Type);
		}

		[Fact]
		public void Tokenize_Exclamation_ReturnsSourceText()
		{
			Assert.Equal("!", CreateInstance().Tokenize("!").Single().Text);
		}

		[Fact]
		public void Tokenize_MultipleExclamations_ReturnsMultipleTokens()
		{
			Assert.Equal(2, CreateInstance().Tokenize("!!").Count());
		}

		[Fact]
		public void Tokenize_Asterisk_ReturnsSingleToken()
		{
			Assert.Equal(1, CreateInstance().Tokenize("*").Count());
		}

		[Fact]
		public void Tokenize_Asterisk_ReturnsAsteriskToken()
		{
			Assert.Equal(TokenType.Asterisk, CreateInstance().Tokenize("*").Single().Type);
		}

		[Fact]
		public void Tokenize_Asterisk_ReturnsSourceText()
		{
			Assert.Equal("*", CreateInstance().Tokenize("*").Single().Text);
		}

		[Fact]
		public void Tokenize_MultipleAsterisks_ReturnsMultipleTokens()
		{
			Assert.Equal(2, CreateInstance().Tokenize("**").Count());
		}

		[Fact]
		public async Task Abc()
		{
			var rules = File.ReadAllText(@"C:\Users\baker\Downloads\public_suffix_list.dat");
			var begin = DateTime.UtcNow;
			var tokens = CreateInstance().Tokenize(rules);
			var end = DateTime.UtcNow;
			var elapsed = end - begin;

			Assert.True(tokens.Length > 0);
		}

		private static ITokenizer CreateInstance()
		{
			return new Tokenizer(
				new MultipleCharacterTokenizer(
					new AsteriskCharacterTokenizer(),
					new ExclamationCharacterTokenizer(),
					new WhitespaceCharacterTokenizer(),
					new CommentCharacterTokenizer(),
					new TextCharacterTokenizer()));
		}
	}
}
