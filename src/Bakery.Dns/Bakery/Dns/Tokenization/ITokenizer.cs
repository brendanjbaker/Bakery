namespace Bakery.Dns.Tokenization
{
	using System;

	public interface ITokenizer
	{
		Token[] Tokenize(String @string);
	}
}
