using System;

public static class StringIsEmptyExtensions
{
	public static Boolean IsEmpty(this String @string)
	{
		return @string == String.Empty;
	}
}
