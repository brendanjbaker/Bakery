namespace Bakery.Dns.Tokenization
{
	public class CommentCharacterTokenizer
		: ITokenScanner
	{
		public void TryScanNextToken(TokenizationContext context)
		{
			if (context.PreviousToken == null)
			{
				if (context.IsNext("//"))
					ScanComment(context);
			}
			else
			{
				if (context.PreviousToken.Value.Type == TokenType.Whitespace)
				{
					ScanComment(context);
				}
				else if (context.PreviousToken.Value.Type == TokenType.Newline)
				{
					if (context.IsNext("//"))
						ScanComment(context);
				}
			}
		}

		private static void ScanComment(TokenizationContext context)
		{
			while (context.HasNext && context.Next != '\n')
				context.ConsumeNext();

			context.AddToken(TokenType.Comment);
		}
	}
}
