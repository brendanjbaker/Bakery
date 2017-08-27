namespace Bakery.Dns
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class TldRulesSource
		: ITldRulesSource
	{
		private readonly ITldRulesTextParser tldRulesTextParser;
		private readonly ITldRulesTextSource tldRulesTextSource;

		public TldRulesSource(ITldRulesTextParser tldRulesTextParser, ITldRulesTextSource tldRulesTextSource)
		{
			this.tldRulesTextParser = tldRulesTextParser;
			this.tldRulesTextSource = tldRulesTextSource;
		}

		public async Task<IEnumerable<ITldRule>> ListAsync()
		{
			var text = await tldRulesTextSource.GetAsync();

			return tldRulesTextParser.Parse(text);
		}
	}
}
