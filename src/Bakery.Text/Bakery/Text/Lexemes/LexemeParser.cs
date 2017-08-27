namespace Bakery.Text.Lexemes
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class LexemeParser
		: ILexemeParser
	{
		public IEnumerable<Lexeme> Parse(String @string)
		{
			if (@string == null)
				throw new ArgumentNullException(nameof(@string));

			var lexemes = new List<Lexeme>();
			var buffer = new StringBuilder();
			var line = 0;
			var column = 0;

			for (var position = 0; position < @string.Length; position++)
			{
				var candidateLength = 1;

				if (@string[position] == '\n')
				{
					lexemes.Add(new Lexeme("\n", LexemeType.Newline, new LexemeSource(position, line, column)));

					line++;
					column = 0;
				}
				else if (Char.IsWhiteSpace(@string[position]))
				{
					for (; position + candidateLength < @string.Length; candidateLength++)
					{
						if (@string[position + candidateLength] == '\n' || !Char.IsWhiteSpace(@string[position + candidateLength]))
						{
							break;
						}
					}

					lexemes.Add(new Lexeme(@string.Substring(position, candidateLength), LexemeType.Whitespace, new LexemeSource(position, line, column)));

					column += candidateLength;
					position += candidateLength - 1;
				}
				else
				{
					for (; position + candidateLength < @string.Length; candidateLength++)
					{
						if (@string[position + candidateLength] == '\n' || Char.IsWhiteSpace(@string[position + candidateLength]))
						{
							break;
						}
					}

					lexemes.Add(new Lexeme(@string.Substring(position, candidateLength), LexemeType.Text, new LexemeSource(position, line, column)));

					column += candidateLength;
					position += candidateLength - 1;
				}
			}

			return lexemes;
		}
	}
}
