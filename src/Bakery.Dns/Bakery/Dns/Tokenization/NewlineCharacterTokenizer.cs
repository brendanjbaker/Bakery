namespace Bakery.Dns.Tokenization
{
	public class NewlineCharacterTokenizer
		: ITokenScanner
	{
		public void TryScanNextToken(TokenizationContext context)
		{
			if (context.Next == '\n')
			{
				context.ConsumeNext();
				context.AddToken(TokenType.Newline);
			}
		}
	}
}
