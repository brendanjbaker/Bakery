namespace Bakery.Mail.MailKit
{
	using global::MailKit.Net.Smtp;
	using global::MailKit.Security;
	using System.Threading.Tasks;

	public class MailKitEmailClient
		: IEmailClient
	{
		private readonly IMimeMessageFactory mimeMessageFactory;
		private readonly SmtpClient smtpClient;
		private readonly ISmtpConfiguration smtpConfiguration;

		public MailKitEmailClient(
			IMimeMessageFactory mimeMessageFactory,
			SmtpClient smtpClient,
			ISmtpConfiguration smtpConfiguration)
		{
			this.mimeMessageFactory = mimeMessageFactory;
			this.smtpClient = smtpClient;
			this.smtpConfiguration = smtpConfiguration;
		}

		public async Task SendAsync(IEmail email)
		{
			var mimeMessage = mimeMessageFactory.Create(email);

			await smtpClient.ConnectAsync(
				smtpConfiguration.Server,
				smtpConfiguration.Port,
				SecureSocketOptions.StartTls);

			await smtpClient.AuthenticateAsync(
				smtpConfiguration.Username,
				smtpConfiguration.Password);

			await smtpClient.SendAsync(mimeMessage);

			await smtpClient.DisconnectAsync(true);
		}
	}
}
