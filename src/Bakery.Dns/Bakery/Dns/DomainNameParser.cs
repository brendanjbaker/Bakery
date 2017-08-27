namespace Bakery.Dns
{
	using System;
	using System.Threading.Tasks;

	public class DomainNameParser
		: IDomainNameParser
	{
		private readonly ITldRuleCollection tldRuleCollection;

		public DomainNameParser(ITldRuleCollection tldRuleCollection)
		{
			this.tldRuleCollection = tldRuleCollection ?? throw new ArgumentNullException(nameof(tldRuleCollection));
		}

		public async Task<DomainName> ParseAsync(String domainName)
		{
			var tldRule = await tldRuleCollection.TryGetMatchingAsync(domainName);

			if (tldRule == null)
				throw new InvalidDomainNameException(domainName);

			return tldRule.Parse(domainName);
		}
	}
}
