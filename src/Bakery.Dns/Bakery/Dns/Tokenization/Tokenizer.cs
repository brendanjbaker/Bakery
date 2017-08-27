namespace Bakery.Dns.Tokenization
{
	using System;
	using System.Collections.Generic;

	public class Tokenizer
		: ITokenizer
	{
		private readonly ITokenScanner characterTokenizer;

		public Tokenizer(ITokenScanner characterTokenizer)
		{
			this.characterTokenizer = characterTokenizer ?? throw new ArgumentNullException(nameof(characterTokenizer));
		}

		public Token[] Tokenize(String @string)
		{
			if (@string == null)
				throw new ArgumentNullException(nameof(@string));

			var tokens = new List<Token>();
			var context = new TokenizationContext(@string, tokens);

			while (context.HasNext)
				characterTokenizer.TryScanNextToken(context);

			return tokens.ToArray();
		}
	}
}
