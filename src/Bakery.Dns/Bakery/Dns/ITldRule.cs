namespace Bakery.Dns
{
	using System;

	public interface ITldRule
	{
		String[] Labels { get; }
		TldRuleType Type { get; }

		DomainName Parse(String domainName);
	}
}
