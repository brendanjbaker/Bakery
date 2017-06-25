namespace Bakery.Processes
{
	using System;
	using System.Threading.Tasks;

	public interface IProcess
	{
		Task<Output> TryReadAsync(TimeSpan timeout);
	}
}
