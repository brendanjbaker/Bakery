namespace Bakery.Security
{
	using System;
	using System.Text;
	using Text;

	public class BasicAuthenticationPrinter
		: IBasicAuthenticationPrinter
	{
		private readonly IBase64Printer base64Printer;
		private readonly Encoding encoding;

		public BasicAuthenticationPrinter(IBase64Printer base64Printer, Encoding encoding)
		{
			this.base64Printer = base64Printer;
			this.encoding = encoding;
		}

		public String Print(IBasicAuthentication basicAuthentication)
		{
			return $"Basic {base64Printer.Print(encoding.GetBytes($"{basicAuthentication.Username}:{basicAuthentication.Password}"))}";
		}
	}
}
