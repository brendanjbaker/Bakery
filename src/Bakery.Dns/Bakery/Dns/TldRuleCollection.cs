namespace Bakery.Dns
{
	using System;
	using System.Linq;
	using System.Threading.Tasks;

	public class TldRuleCollection
		: ITldRuleCollection
	{
		private readonly ITldRulesSource tldRulesSource;

		public TldRuleCollection(ITldRulesSource tldRulesSource)
		{
			this.tldRulesSource = tldRulesSource ?? throw new ArgumentNullException(nameof(tldRulesSource));
		}

		public async Task<ITldRule> TryGetMatchingAsync(String domainName)
		{
			var rules = await tldRulesSource.ListAsync();
			var domainNameLabels = domainName.Split('.');

			var matching = rules
				.Where(r =>
				{
					var a = domainNameLabels.Reverse().ToArray();
					var b = r.Labels.Reverse().ToArray();

					if (a.Length < b.Length)
						return false;

					for (var i = 0; i < b.Length; i++)
					{
						if (b[i] == "*")
							continue;

						if (a[i] != b[i])
							return false;
					}

					return true;
				})
				.OrderByDescending(r => r.Type == TldRuleType.WildcardException ? 1 : 0)
				.ThenByDescending(r => r.Labels.Length)
				.ThenByDescending(r => r.Type == TldRuleType.Wildcard ? 0 : 1)
				.FirstOrDefault();

			return matching;
		}
	}
}
