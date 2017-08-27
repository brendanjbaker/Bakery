namespace Bakery.Dns
{
	using System;

	public interface ITldRuleLineParser
	{
		ITldRule Parse(String @string);
	}
}
