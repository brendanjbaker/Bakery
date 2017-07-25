namespace Bakery.Caching
{
	public class InfiniteCache<T>
		: ICache<T>
	{
		private T item;

		public T TryRead()
		{
			return item;
		}

		public void Write(T item)
		{
			this.item = item;
		}
	}
}
