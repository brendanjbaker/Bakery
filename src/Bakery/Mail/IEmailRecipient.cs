namespace Bakery.Mail
{
	public interface IEmailRecipient
	{
		IEmailAddress EmailAddress { get; }
		RecipientType RecipientType { get; }
	}
}
