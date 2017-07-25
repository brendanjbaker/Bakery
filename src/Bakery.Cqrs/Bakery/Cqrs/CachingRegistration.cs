namespace Bakery.Cqrs
{
	using System;

	public class CachingRegistration
		: ICachingRegistration
	{
		private readonly Type queryType;

		public CachingRegistration(Type queryType)
		{
			this.queryType = queryType;
		}

		public Type QueryType => queryType;
	}
}
