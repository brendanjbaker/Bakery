namespace Bakery.Dns.Tokenization
{
	using Bakery.Exceptions;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class TokenizationContext
	{
		private readonly String characters;
		private readonly ICollection<Token> tokens;

		private Int32 lastPosition, position;

		public TokenizationContext(String characters, ICollection<Token> tokens)
		{
			this.characters = characters ?? throw new ArgumentNullException(nameof(characters));
			this.tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
		}

		public String Characters => characters;

		public Boolean HasNext => position < characters.Length;

		public Char Next => characters[position];

		public Int32 Position => position;

		public Token? PreviousToken
		{
			get
			{
				if (!tokens.Any())
					return null;

				return tokens.Last();
			}
		}

		public void AddToken(TokenType tokenType)
		{
			if (position == lastPosition)
				throw new InvalidOperationException("No characters have been added to the current token.");

			var text = characters.Substring(lastPosition, position - lastPosition);

			lastPosition = position;

			tokens.Add(new Token(text, tokenType));
		}

		public void ConsumeNext()
		{
			position++;
		}

		public Boolean IsNext(Char character, Int32 offset)
		{
			if (offset < 0)
				throw new ArgumentNegativeException(nameof(offset));

			if (position + offset >= characters.Length)
				return false;

			return characters[position + offset] == character;
		}

		public Boolean IsNext(Char character)
		{
			return IsNext(character, 0);
		}

		public Boolean IsNext(String @string)
		{
			for (var i = 0; i < @string.Length; i++)
				if (!IsNext(@string[i], i))
					return false;

			return true;
		}
	}
}
