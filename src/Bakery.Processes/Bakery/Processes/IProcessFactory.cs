namespace Bakery.Processes
{
	using System.Diagnostics;

	public interface IProcessFactory
	{
		IStartedProcess Start(ProcessStartInfo processStartInfo);
	}
}
