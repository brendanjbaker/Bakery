namespace Bakery.Processes.Specification.Builder
{
	public interface IProcessSpecificationBuilderWithEnvironment
		: IProcessSpecificationBuilderComplete
		, IProcessSpecificationBuilderWithStandardInput
	{
		IProcessSpecificationBuilderWithStandardInput WithStandardInput();
	}
}
