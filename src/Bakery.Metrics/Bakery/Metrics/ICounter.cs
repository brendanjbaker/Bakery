namespace Bakery.Metrics
{
	using System;
	using System.Threading.Tasks;

	public interface ICounter
	{
		Task IncrementAsync(Object key, Int64 count = 1);
		Task<Int64> ReadAsync(Object key);
	}
}
