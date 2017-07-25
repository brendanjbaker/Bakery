namespace Bakery.Cqrs
{
	using System;

	public interface ICachingConfiguration
	{
		Boolean IsEnabledForQueryType(Type queryType);
	}
}
