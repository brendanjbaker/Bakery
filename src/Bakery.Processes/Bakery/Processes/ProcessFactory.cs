namespace Bakery.Processes
{
	using System.Diagnostics;

	public class ProcessFactory
		: IProcessFactory
	{
		public IStartedProcess Start(ProcessStartInfo processStartInfo)
		{
			return SystemDiagnosticsProcess.Create(processStartInfo);
		}
	}
}
