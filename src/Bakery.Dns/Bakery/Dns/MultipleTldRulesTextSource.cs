namespace Bakery.Dns
{
	using Bakery.Exceptions;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public class MultipleTldRulesTextSource
		: ITldRulesTextSource
	{
		private readonly ITldRulesTextSource[] tldRulesTextSources;

		public MultipleTldRulesTextSource(params ITldRulesTextSource[] tldRulesTextSources)
		{
			if (tldRulesTextSources == null)
				throw new ArgumentNullException(nameof(tldRulesTextSources));

			if (!tldRulesTextSources.Any())
				throw new ArgumentEmptyException(nameof(tldRulesTextSources));

			this.tldRulesTextSources = tldRulesTextSources;
		}

		public async Task<String> GetAsync()
		{
			var exceptions = new List<Exception>();

			foreach (var tldRulesTextSource in tldRulesTextSources)
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

			throw new AggregateException("All TLD rules text sources failed.", exceptions);
		}
	}
}
