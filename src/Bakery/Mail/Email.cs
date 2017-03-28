namespace Bakery.Mail
{
	using System;
	using System.Collections.Generic;

	public class Email
		: IEmail
	{
		private readonly String body;
		private readonly IEnumerable<IEmailHeader> headers;
		private readonly IEnumerable<IEmailRecipient> recipients;
		private readonly IEmailAddress sender;
		private readonly String subject;

		public Email(IEmailAddress sender, IEnumerable<IEmailRecipient> recipients, IEnumerable<IEmailHeader> headers, String subject, String body)
		{
			if (sender == null)
				throw new ArgumentNullException(nameof(sender));

			if (recipients == null)
				throw new ArgumentNullException(nameof(recipients));

			if (headers == null)
				throw new ArgumentNullException(nameof(headers));

			this.body = body;
			this.headers = headers;
			this.recipients = recipients;
			this.sender = sender;
			this.subject = subject;
		}

		public String Body => body;

		public IEnumerable<IEmailHeader> Headers => headers;

		public IEnumerable<IEmailRecipient> Recipients => recipients;

		public IEmailAddress Sender => sender;

		public String Subject => subject;
	}
}
