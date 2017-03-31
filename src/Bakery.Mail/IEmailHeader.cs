namespace Bakery.Mail
{
	using System;

	public interface IEmailHeader
	{
		String Name { get; }
		String Value { get; }
	}
}
