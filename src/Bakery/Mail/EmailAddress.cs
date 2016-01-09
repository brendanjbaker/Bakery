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
			this.name = name;
			this.value = value;
		}

		public String Name
		{
			get { return name; }
		}

		public String Value
		{
			get { return value; }
		}
	}
}
