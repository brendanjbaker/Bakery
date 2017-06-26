namespace Bakery.Mail.MailKit
{
	using global::MailKit.Net.Smtp;
	using global::MailKit.Security;
	using System;
	using System.Threading.Tasks;

	public class MailKitEmailClient
		: IEmailClient
	{
		private readonly IMimeMessageFactory mimeMessageFactory;
		private readonly Func<SmtpClient> smtpClientFactory;
		private readonly ISmtpConfiguration smtpConfiguration;

		public MailKitEmailClient(
			IMimeMessageFactory mimeMessageFactory,
			Func<SmtpClient> smtpClientFactory,
			ISmtpConfiguration smtpConfiguration)
		{
			if (mimeMessageFactory == null)
				throw new ArgumentNullException(nameof(mimeMessageFactory));

			if (smtpClientFactory == null)
				throw new ArgumentNullException(nameof(smtpClientFactory));

			if (smtpConfiguration == null)
				throw new ArgumentNullException(nameof(smtpConfiguration));

			this.mimeMessageFactory = mimeMessageFactory;
			this.smtpClientFactory = smtpClientFactory;
			this.smtpConfiguration = smtpConfiguration;
		}

		public async Task SendAsync(IEmail email)
		{
			if (email == null)
				throw new ArgumentNullException(nameof(email));

			var mimeMessage = mimeMessageFactory.Create(email);

			using (var smtpClient = smtpClientFactory())
			{
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
}
