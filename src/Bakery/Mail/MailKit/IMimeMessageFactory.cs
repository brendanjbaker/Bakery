namespace Bakery.Mail.MailKit
{
	using MimeKit;

	public interface IMimeMessageFactory
	{
		MimeMessage Create(IEmail email);
	}
}
