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
			if (base64Printer == null)
				throw new ArgumentNullException(nameof(base64Printer));

			if (encoding == null)
				throw new ArgumentNullException(nameof(encoding));

			this.base64Printer = base64Printer;
			this.encoding = encoding;
		}

		public String Print(IBasicAuthentication basicAuthentication)
		{
			if (basicAuthentication == null)
				throw new ArgumentNullException(nameof(basicAuthentication));

			var credentials =
				String.Format("{0}:{1}",
					basicAuthentication.Username,
					basicAuthentication.Password);

			var credentialsBase64 = base64Printer.Print(encoding.GetBytes(credentials));

			return $"Basic {credentialsBase64}";
		}
	}
}
