namespace Bakery.Dns.Tokenization
{
	public class AsteriskCharacterTokenizer
		: ITokenScanner
	{
		public void TryScanNextToken(TokenizationContext context)
		{
			if (context.IsNext('*'))
			{
				context.ConsumeNext();
				context.ConsumeNext();
				context.AddToken(TokenType.Asterisk);
			}
		}
	}
}
