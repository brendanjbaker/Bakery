namespace Bakery.Mail
{
	using System;
	using System.Collections.Generic;

	public interface IEmail
	{
		String Body { get; }
		IEnumerable<IEmailHeader> Headers { get; }
		IEnumerable<IEmailRecipient> Recipients { get; }
		IEmailAddress Sender { get; }
		String Subject { get; }
	}
}
