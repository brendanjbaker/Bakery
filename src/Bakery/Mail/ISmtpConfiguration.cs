namespace Bakery.Mail
{
	using System;

	public interface ISmtpConfiguration
	{
		String Password { get; }
		Int32 Port { get; }
		String Server { get; }
		String Username { get; }
	}
}
