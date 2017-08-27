namespace Bakery.Dns
{
	using System;
	using System.Threading.Tasks;

	public interface ITldRuleCollection
	{
		Task<ITldRule> TryGetMatchingAsync(String domainName);
	}
}
