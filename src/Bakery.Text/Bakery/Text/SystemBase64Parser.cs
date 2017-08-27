namespace Bakery.Text
{
	using System;

	public class SystemBase64Parser
		: IBase64Parser
	{
		public Byte[] Parse(String @string)
		{
			// Consistent with .NET Framework methods, TryParse() won't throw an
			// ArgumentNullException if the supplied input is null.

			if (@string == null)
				return null;

			try
			{
				return Convert.FromBase64String(@string);
			}
			catch
			{
				return null;
			}
		}
	}
}
