namespace Bakery.Cqrs
{
	using Caching;
	using System;

	public class CachingRegistration
		: ICachingRegistration
	{
		private readonly Func<ICache<Object>> cacheFunction;
		private readonly Type queryType;

		public CachingRegistration(Type queryType, Func<ICache<Object>> cacheFunction)
		{
			this.queryType = queryType;
			this.cacheFunction = cacheFunction;
		}

		public Type QueryType => queryType;

		public ICache<Object> CreateCache()
		{
			return cacheFunction();
		}
	}
}
