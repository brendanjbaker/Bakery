namespace Bakery.Security
{
	using System;

	public class BasicAuthentication
		: IBasicAuthentication
	{
		public String Password { get; set; }
		public String Username { get; set; }
	}
}
