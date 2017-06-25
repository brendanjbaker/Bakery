namespace Bakery.Processes
{
	using Specification;

	public interface IProcessFactory
	{
		IStartedProcess Start(IProcessSpecification processSpecification);
	}
}
