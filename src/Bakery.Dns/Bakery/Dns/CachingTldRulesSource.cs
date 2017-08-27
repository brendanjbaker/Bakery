namespace Bakery.Dns
{
	using Bakery.Caching;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class CachingTldRulesSource
		: ITldRulesSource
	{
		private readonly ICache<IEnumerable<ITldRule>> tldRulesCache;
		private readonly ITldRulesSource tldRulesSource;

		public CachingTldRulesSource(ICache<IEnumerable<ITldRule>> tldRulesCache, ITldRulesSource tldRulesSource)
		{
			this.tldRulesCache = tldRulesCache ?? throw new ArgumentNullException(nameof(tldRulesCache));
			this.tldRulesSource = tldRulesSource ?? throw new ArgumentNullException(nameof(tldRulesSource));
		}

		public async Task<IEnumerable<ITldRule>> ListAsync()
		{
			return await tldRulesCache.ReadAsync(async () =>
			{
				return await tldRulesSource.ListAsync();
			});
		}
	}
}
