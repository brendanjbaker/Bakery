using System;
using System.Linq;

public static class StringContainsWhitespaceExtensions
{
	public static Boolean ContainsWhitespace(this String @string)
	{
		return @string.WhitespaceCharacters().Any();
	}
}
