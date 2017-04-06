namespace Bakery.Processes
{
	using System;
	using System.Threading.Tasks;

	public interface IStartedProcess
		: IProcess
	{
		Task WaitForExit(TimeSpan timeout);
		Task WriteAsync(String text);
	}
}
