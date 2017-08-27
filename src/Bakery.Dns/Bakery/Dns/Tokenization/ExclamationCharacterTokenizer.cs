namespace Bakery.Dns.Tokenization
{
	public class ExclamationCharacterTokenizer
		: ITokenScanner
	{
		public void TryScanNextToken(TokenizationContext context)
		{
			if (context.IsNext('!'))
			{
				context.ConsumeNext();
				context.AddToken(TokenType.Exclamation);
			}
		}
	}
}
