namespace Bakery.Dns
{
	using System;

	public class InvalidDomainNameException
		: Exception
	{
		public InvalidDomainNameException(String domainName)
			: base($@"Invalid domain name: ""{domainName}"".") { }
	}
}
