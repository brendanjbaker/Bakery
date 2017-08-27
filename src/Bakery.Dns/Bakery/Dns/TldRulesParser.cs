namespace Bakery.Dns
{
	using Bakery.Exceptions;
	using Bakery.Text;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class TldRulesParser
		: ITldRulesTextParser
	{
		private readonly ILineSplitter lineSplitter;
		private readonly ITldRuleLineParser tldRuleLineParser;

		public TldRulesParser(ILineSplitter lineSplitter, ITldRuleLineParser tldRuleLineParser)
		{
			this.lineSplitter = lineSplitter ?? throw new ArgumentNullException(nameof(lineSplitter));
			this.tldRuleLineParser = tldRuleLineParser ?? throw new ArgumentNullException(nameof(tldRuleLineParser));
		}

		public IEnumerable<ITldRule> Parse(String @string)
		{
			if (@string == null)
				throw new ArgumentNullException(nameof(@string));

			foreach (var line in lineSplitter.SplitLines(@string))
			{
				var tldRule = tldRuleLineParser.Parse(line);

				if (tldRule != null)
					yield return tldRule;
			}
		}
	}
}
