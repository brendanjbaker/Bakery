namespace Bakery.Dns
{
	using Bakery.Caching;
	using System;
	using System.Threading.Tasks;

	public class CachingDomainNameParser
		: IDomainNameParser
	{
		private readonly IKeyedCache<String, DomainName> cache;
		private readonly IDomainNameParser domainNameParser;

		public CachingDomainNameParser(IKeyedCache<String, DomainName> cache, IDomainNameParser domainNameParser)
		{
			this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
			this.domainNameParser = domainNameParser ?? throw new ArgumentNullException(nameof(domainNameParser));
		}

		public async Task<DomainName> ParseAsync(String domainName)
		{
			if (domainName == null)
				throw new ArgumentNullException(nameof(domainName));

			return await cache.ReadAsync(domainName, async () =>
			{
				return await domainNameParser.ParseAsync(domainName);
			});
		}
	}
}
