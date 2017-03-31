namespace Bakery.Caching
{
	public interface ICache<T>
	{
		T TryRead();
		void Write(T item);
	}
}
