namespace Bakery.Cqrs
{
	using Caching;
	using System;

	public interface ICachingRegistration
	{
		Type QueryType { get; }

		ICache<Object> CreateCache();
	}
}
