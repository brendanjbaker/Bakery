namespace Bakery.Cqrs
{
	using Caching;
	using System;

	public interface ICachingConfiguration
	{
		Boolean IsEnabledForQueryType(Type queryType);
		ICache<Object> CreateCache(Type queryType);
	}
}
