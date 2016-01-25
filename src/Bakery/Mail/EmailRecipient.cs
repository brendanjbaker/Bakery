namespace Bakery.Mail
{
	public class EmailRecipient
		: IEmailRecipient
	{
		private readonly IEmailAddress emailAddress;
		private readonly RecipientType recipientType;

		public EmailRecipient(IEmailAddress emailAddress, RecipientType recipientType = RecipientType.To)
		{
			this.emailAddress = emailAddress;
			this.recipientType = recipientType;
		}

		public IEmailAddress EmailAddress
		{
			get { return emailAddress; }
		}

		public RecipientType RecipientType
		{
			get { return recipientType; }
		}
	}
}
