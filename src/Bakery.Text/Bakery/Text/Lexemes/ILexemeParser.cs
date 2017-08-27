namespace Bakery.Text.Lexemes
{
	using System.Collections.Generic;

	public interface ILexemeParser
		: IParser<IEnumerable<Lexeme>>
	{ }
}
