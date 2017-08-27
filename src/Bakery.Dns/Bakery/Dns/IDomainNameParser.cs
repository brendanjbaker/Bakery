namespace Bakery.Dns
{
	using System;
	using System.Threading.Tasks;

	public interface IDomainNameParser
	{
		Task<DomainName> ParseAsync(String domainName);
	}
}
