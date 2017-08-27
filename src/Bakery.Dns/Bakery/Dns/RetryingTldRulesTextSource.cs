namespace Bakery.Dns
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public class RetryingTldRulesTextSource
		: ITldRulesTextSource
	{
		private readonly Int32 retryCount;
		private readonly ITldRulesTextSource tldRulesTextSource;

		public RetryingTldRulesTextSource(Int32 retryCount, ITldRulesTextSource tldRulesTextSource)
		{
			if (retryCount <= 0)
				throw new ArgumentOutOfRangeException(nameof(retryCount));

			if (tldRulesTextSource == null)
				throw new ArgumentNullException(nameof(tldRulesTextSource));

			this.retryCount = retryCount;
			this.tldRulesTextSource = tldRulesTextSource;
		}

		public async Task<String> GetAsync()
		{
			var exceptions = new List<Exception>();

			for (var i = 0; i < retryCount + 1; i++)
			{
				try
				{
					return await tldRulesTextSource.GetAsync();
				}
				catch (Exception e)
				{
					exceptions.Add(e);
				}
			}

			if (exceptions.Count == 1)
				throw exceptions.Single();

			throw new AggregateException("Retrieving the TLD rules text failed, and all retry attempts also failed.", exceptions);
		}
	}
}
