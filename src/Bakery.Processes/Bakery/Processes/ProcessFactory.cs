namespace Bakery.Processes
{
	using Specification;

	public class ProcessFactory
		: IProcessFactory
	{
		public IStartedProcess Start(IProcessSpecification processSpecification)
		{
			return SystemDiagnosticsProcess.Create(processSpecification);
		}
	}
}
