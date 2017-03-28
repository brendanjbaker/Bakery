namespace Bakery.Mail
{
	using System;

	public class EmailHeader
		: IEmailHeader
	{
		private readonly String name;
		private readonly String value;

		public EmailHeader(String name, String value)
		{
			if (name == null)
				throw new ArgumentNullException(nameof(name));

			if (value == null)
				throw new ArgumentNullException(nameof(value));

			this.name = name;
			this.value = value;
		}

		public String Name => name;

		public String Value => value;
	}
}
