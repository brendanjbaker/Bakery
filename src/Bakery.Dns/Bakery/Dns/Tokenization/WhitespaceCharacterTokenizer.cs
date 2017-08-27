namespace Bakery.Dns.Tokenization
{
	using System;

	public class WhitespaceCharacterTokenizer
		: ITokenScanner
	{
		public void TryScanNextToken(TokenizationContext context)
		{
			if (!Char.IsWhiteSpace(context.Next))
				return;

			while (context.HasNext && Char.IsWhiteSpace(context.Next))
				context.ConsumeNext();

			context.AddToken(TokenType.Whitespace);
		}
	}
}
