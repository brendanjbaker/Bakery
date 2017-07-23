using Bakery.Caching;
using System;
using System.Threading.Tasks;

public static class KeyedCacheExtensions
{
	public static TValue Read<TKey, TValue>(this IKeyedCache<TKey, TValue> cache, TKey key, Func<TValue> source)
	{
		var item = cache.TryRead(key);

		if (item == null)
		{
			item = source();

			cache.Write(key, item);
		}

		return item;
	}

	public static async Task<TValue> ReadAsync<TKey, TValue>(this IKeyedCache<TKey, TValue> cache, TKey key, Func<Task<TValue>> source)
	{
		var item = cache.TryRead(key);

		if (item == null)
		{
			item = await source();

			cache.Write(key, item);
		}

		return item;
	}
}
