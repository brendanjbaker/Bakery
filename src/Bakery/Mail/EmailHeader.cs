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
