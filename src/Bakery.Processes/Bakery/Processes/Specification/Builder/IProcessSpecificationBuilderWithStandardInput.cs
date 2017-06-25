namespace Bakery.Processes.Specification.Builder
{
	public interface IProcessSpecificationBuilderWithStandardInput
		: IProcessSpecificationBuilderComplete
		, IProcessSpecificationBuilderWithStandardOutput
	{
		IProcessSpecificationBuilderComplete WithCombinedOutput();
		IProcessSpecificationBuilderWithStandardOutput WithStandardOutput();
	}
}
