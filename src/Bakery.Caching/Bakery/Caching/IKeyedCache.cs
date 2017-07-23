namespace Bakery.Caching
{
	public interface IKeyedCache<TKey, TValue>
	{
		TValue TryRead(TKey key);
		void Write(TKey key, TValue item);
	}
}
