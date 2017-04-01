using System;

public static class StringRemoveExtensions
{
	public static String Remove(this String @string, String remove)
	{
		if (remove == null)
			throw new ArgumentNullException(nameof(remove));

		return @string.Replace(remove, String.Empty);
	}
}
