namespace Bakery.Processes.Specification.Builder
{
	public interface IProcessSpecificationBuilderWithStandardOutput
		: IProcessSpecificationBuilderComplete
	{
		IProcessSpecificationBuilderWithStandardError WithStandardError();
	}
}
