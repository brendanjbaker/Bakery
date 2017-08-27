namespace Bakery.Dns.Tokenization
{
	using System;

	public class TextCharacterTokenizer
		: ITokenScanner
	{
		public void TryScanNextToken(TokenizationContext context)
		{
			var charactersAdded = 0;

			while (context.HasNext && !Char.IsWhiteSpace(context.Next))
			{
				context.ConsumeNext();

				charactersAdded++;
			}

			if (charactersAdded > 0)
				context.AddToken(TokenType.Text);
		}
	}
}
