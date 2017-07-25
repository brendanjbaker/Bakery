namespace Bakery.Cqrs
{
	using Caching;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class CachingConfiguration
		: ICachingConfiguration
	{
		private readonly IEnumerable<ICachingRegistration> cachingRegistrations;

		public CachingConfiguration(IEnumerable<ICachingRegistration> cachingRegistrations)
		{
			this.cachingRegistrations = cachingRegistrations;
		}

		public ICache<Object> CreateCache(Type queryType)
		{
			var registration = TryGetRegistration(queryType);

			if (registration == null)
				throw new InvalidOperationException($"No registration for query type {queryType.Name}.");

			return registration.CreateCache();
		}

		public Boolean IsEnabledForQueryType(Type queryType)
		{
			return TryGetRegistration(queryType) != null;
		}

		private ICachingRegistration TryGetRegistration(Type queryType)
		{
			return cachingRegistrations.SingleOrDefault(registration => registration.QueryType == queryType);
		}
	}
}
