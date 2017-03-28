namespace Bakery.Mail
{
	using System;

	public class EmailAddress
		: IEmailAddress
	{
		private readonly String name;
		private readonly String value;

		public EmailAddress(String value, String name = null)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			this.name = name;
			this.value = value;
		}

		public String Name => name;

		public String Value => value;
	}
}
