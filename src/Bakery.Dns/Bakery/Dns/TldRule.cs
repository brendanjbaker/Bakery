namespace Bakery.Dns
{
	using System;
	using System.Linq;

	public class TldRule
		: ITldRule
	{
		private readonly String[] labels;
		private readonly TldRuleType type;

		public TldRule(String[] labels, TldRuleType type)
		{
			this.labels = labels ?? throw new ArgumentNullException(nameof(labels));
			this.type = type;
		}

		public String[] Labels => labels;

		public TldRuleType Type => type;

		public DomainName Parse(String domainName)
		{
			if (domainName == null)
				throw new ArgumentNullException(nameof(domainName));

			if (!domainName.Contains("."))
				throw new InvalidDomainNameException(domainName);

			var domainNameLabels = domainName.Split('.');

			if (domainNameLabels.Length < labels.Length + 1)
				throw new InvalidDomainNameException(domainName);

			var tld = new Tld(String.Join(".", labels));
			var sld = domainNameLabels.Reverse().Skip(labels.Length).Take(1).Single();
			var subdomains = domainNameLabels.Reverse().Skip(labels.Length + 1).Reverse().ToArray();

			return new DomainName(subdomains, sld, tld);
		}
	}
}
