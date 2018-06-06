using System.Collections.Generic;

public static class DictionaryExtensions
{
	public static IDictionary<TKey, TValue> Clone<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
	{
		return new Dictionary<TKey, TValue>(dictionary);
	}
}
