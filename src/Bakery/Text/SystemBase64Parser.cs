namespace Bakery.Text
{
	using System;

	public class SystemBase64Parser
		: IBase64Parser
	{
		public Byte[] TryParse(String @string)
		{
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
