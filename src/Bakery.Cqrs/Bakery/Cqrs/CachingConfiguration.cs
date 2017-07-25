namespace Bakery.Cqrs
{
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

		public Boolean IsEnabledForQueryType(Type queryType)
		{
			return cachingRegistrations.Any(registration => registration.QueryType == queryType);
		}
	}
}
