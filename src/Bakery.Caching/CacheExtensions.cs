using Bakery.Caching;
using System;
using System.Threading.Tasks;

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

	public static async Task<T> ReadAsync<T>(this ICache<T> cache, Func<Task<T>> source)
	{
		var item = cache.TryRead();

		if (item == null)
		{
			item = await source();

			cache.Write(item);
		}

		return item;
	}
}
