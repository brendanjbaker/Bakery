namespace Bakery.Text.Lexemes
{
	using System;

	public struct Lexeme
	{
		private readonly LexemeSource source;
		private readonly LexemeType type;
		private readonly String value;

		public Lexeme(String value, LexemeType type, LexemeSource source)
		{
			this.value = value;
			this.type = type;
			this.source = source;
		}

		public LexemeSource Source => source;

		public LexemeType Type => type;

		public String Value => value;
    }
}
