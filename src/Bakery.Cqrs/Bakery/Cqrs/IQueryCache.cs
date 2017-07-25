namespace Bakery.Cqrs
{
	using Caching;
	using System;

	public interface IQueryCache
		: IKeyedCache<Object, Object>
	{ }
}
