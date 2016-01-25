namespace Bakery.Text
{
	using System;

	public class SystemBase64Printer
		: IBase64Printer
	{
		public String Print(Byte[] bytes)
		{
			return Convert.ToBase64String(bytes);
		}
	}
}
