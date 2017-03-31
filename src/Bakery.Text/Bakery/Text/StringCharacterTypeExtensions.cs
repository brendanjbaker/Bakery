namespace Bakery.Text
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public static class StringCharacterTypeExtensions
	{
		public static IEnumerable<Char> AlphabeticCharacters(this String @string)
		{
			return @string.Where(c => Char.IsLetter(c));
		}

		public static IEnumerable<Char> NumericCharacters(this String @string)
		{
			return @string.Where(c => Char.IsNumber(c));
		}

		public static IEnumerable<Char> SpecialCharacters(this String @string)
		{
			return @string.Where(c => !Char.IsLetter(c) && !Char.IsNumber(c));
		}
	}
}
