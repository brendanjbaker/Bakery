namespace Bakery.Security
{
	using System;

	public interface IBasicAuthentication
	{
		String Password { get; set; }
		String Username { get; set; }
	}
}
