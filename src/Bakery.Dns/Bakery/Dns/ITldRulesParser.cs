namespace Bakery.Dns
{
	using System;
	using System.Collections.Generic;

	public interface ITldRulesTextParser
	{
		IEnumerable<ITldRule> Parse(String @string);
	}
}
