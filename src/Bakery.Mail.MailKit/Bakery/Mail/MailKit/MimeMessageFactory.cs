namespace Bakery.Mail.MailKit
{
	using MimeKit;
	using System;

	public class MimeMessageFactory
		: IMimeMessageFactory
	{
		public MimeMessage Create(IEmail email)
		{
			if (email == null)
				throw new ArgumentNullException(nameof(email));

			var mimeMessage = new MimeMessage();

			mimeMessage.From.Add(
				new MailboxAddress(
					email.Sender.Name,
					email.Sender.Value));

			foreach (var emailRecipient in email.Recipients)
				AddRecipient(mimeMessage, emailRecipient);

			foreach (var emailHeader in email.Headers)
				mimeMessage.Headers.Add(emailHeader.Name, emailHeader.Value);

			mimeMessage.Subject = email.Subject;

			mimeMessage.Body = new TextPart()
			{
				Text = email.Body
			};

			return mimeMessage;
		}

		private static void AddRecipient(MimeMessage mimeMessage, IEmailRecipient emailRecipient)
		{
			var mailboxAddress = new MailboxAddress(emailRecipient.EmailAddress.Name, emailRecipient.EmailAddress.Value);

			switch (emailRecipient.RecipientType)
			{
				case RecipientType.Bcc:
					mimeMessage.Bcc.Add(mailboxAddress);
					break;

				case RecipientType.Cc:
					mimeMessage.Cc.Add(mailboxAddress);
					break;

				case RecipientType.To:
					mimeMessage.To.Add(mailboxAddress);
					break;
			}
		}
	}
}
