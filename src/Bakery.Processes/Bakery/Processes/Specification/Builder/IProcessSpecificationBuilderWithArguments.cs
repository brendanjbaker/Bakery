namespace Bakery.Processes.Specification.Builder
{
	public interface IProcessSpecificationBuilderWithArguments
		: IProcessSpecificationBuilderComplete
	{
		IProcessSpecificationBuilderWithEnvironment WithEnvironment();
	}
}
