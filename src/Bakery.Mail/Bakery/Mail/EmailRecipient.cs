namespace Bakery.Mail
{
	using System;

	public class EmailRecipient
		: IEmailRecipient
	{
		private readonly IEmailAddress emailAddress;
		private readonly RecipientType recipientType;

		public EmailRecipient(IEmailAddress emailAddress, RecipientType recipientType = RecipientType.To)
		{
			if (emailAddress == null)
				throw new ArgumentNullException(nameof(emailAddress));

			this.emailAddress = emailAddress;
			this.recipientType = recipientType;
		}

		public IEmailAddress EmailAddress => emailAddress;

		public RecipientType RecipientType => recipientType;
	}
}
