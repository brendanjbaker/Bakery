namespace Bakery.Security
{
	using System;
	using System.Text;
	using Text;

	public class BasicAuthenticationParser
		: IBasicAuthenticationParser
	{
		private readonly IBase64Parser base64Parser;
		private readonly Encoding encoding;

		public BasicAuthenticationParser(IBase64Parser base64Parser, Encoding encoding)
		{
			if (base64Parser == null)
				throw new ArgumentNullException(nameof(base64Parser));

			if (encoding == null)
				throw new ArgumentNullException(nameof(encoding));

			this.base64Parser = base64Parser;
			this.encoding = encoding;
		}

		public IBasicAuthentication Parse(String @string)
		{
			// Consistent with .NET Framework methods, TryParse() won't throw an
			// ArgumentNullException if the supplied input is null.

			if (@string == null)
				return null;

			if (!@string.StartsWith("BASIC ", StringComparison.OrdinalIgnoreCase))
				return null;

			var basicAuthenticationBase64 = @string.Substring(6);
			var basicAuthenticationBytes = base64Parser.Parse(basicAuthenticationBase64);

			if (basicAuthenticationBytes == null)
				return null;

			var basicAuthenticationText = TryGetString(basicAuthenticationBytes);

			if (basicAuthenticationText == null)
				return null;

			var parts = basicAuthenticationText.Split(new Char[] { ':' }, 2);

			if (parts.Length != 2)
				return null;

			return new BasicAuthentication()
			{
				Password = parts[1],
				Username = parts[0]
			};
		}

		private String TryGetString(Byte[] bytes)
		{
			try
			{
				return encoding.GetString(bytes);
			}
			catch { return null; }
		}
	}
}
