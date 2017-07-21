using Bakery.Caching;
using System;

public static class CacheExtensions
{
	public static T Read<T>(this ICache<T> cache, Func<T> source)
	{
		var item = cache.TryRead();

		if (item == null)
		{
			item = source();

			cache.Write(item);
		}

		return item;
	}
}
