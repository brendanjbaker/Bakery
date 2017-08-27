namespace Bakery.Dns.Tokenization
{
	public interface ITokenScanner
	{
		void TryScanNextToken(TokenizationContext context);
	}
}
