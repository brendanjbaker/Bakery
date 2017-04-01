namespace Bakery.Text
{
	using System;

	public class SystemBase64Printer
		: IBase64Printer
	{
		public String Print(Byte[] bytes)
		{
			if (bytes == null)
				throw new ArgumentNullException(nameof(bytes));

			return Convert.ToBase64String(bytes);
		}
	}
}
