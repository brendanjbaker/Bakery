namespace Bakery.Dns.Tokenization
{
	using System;

	public struct Token
	{
		private readonly String text;
		private readonly TokenType type;

		public Token(String text, TokenType type)
		{
			if (text == null)
				throw new ArgumentNullException(nameof(text));

			this.text = text;
			this.type = type;
		}

		public String Text => text;

		public TokenType Type => type;
	}
}
