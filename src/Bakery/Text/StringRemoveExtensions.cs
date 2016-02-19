namespace Bakery.Text
{
	using System;

	public static class StringRemoveExtensions
	{
		public static String Remove(this String @string, String @remove)
		{
			return @string.Replace(@remove, String.Empty);
		}
	}
}
