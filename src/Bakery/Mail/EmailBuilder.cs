namespace Bakery.Mail
{
	using System;
	using System.Collections.Generic;

	public class EmailBuilder
	{
		private String body;
		private ICollection<IEmailHeader> headers;
		private ICollection<IEmailRecipient> recipients;
		private IEmailAddress sender;
		private String subject;

		private EmailBuilder()
		{
			headers = new List<IEmailHeader>();
			recipients = new List<IEmailRecipient>();
		}

		public static EmailBuilder Create()
		{
			return new EmailBuilder();
		}

		public EmailBuilder Body(String body)
		{
			this.body = body;

			return this;
		}

		public IEmail Build()
		{
			return new Email(sender, recipients, headers, subject, body);
		}

		public EmailBuilder Header(String name, String value)
		{
			headers.Add(new EmailHeader(name, value));

			return this;
		}

		public EmailBuilder Recipient(String emailAddress, RecipientType recipientType = RecipientType.To)
		{
			return Recipient(emailAddress, null, recipientType);
		}

		public EmailBuilder Recipient(String emailAddress, String name, RecipientType recipientType = RecipientType.To)
		{
			return Recipient(new EmailAddress(emailAddress, name), recipientType);
		}

		public EmailBuilder Recipient(IEmailAddress emailAddress, RecipientType recipientType = RecipientType.To)
		{
			recipients.Add(new EmailRecipient(emailAddress, recipientType));

			return this;
		}

		public EmailBuilder Sender(String emailAddress, String name = null)
		{
			sender = new EmailAddress(emailAddress, name);

			return this;
		}

		public EmailBuilder Sender(IEmailAddress emailAddress)
		{
			sender = emailAddress;

			return this;
		}

		public EmailBuilder Subject(String subject)
		{
			this.subject = subject;

			return this;
		}
	}
}
