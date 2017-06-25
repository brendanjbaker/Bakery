namespace Bakery.Processes.Specification.Builder
{
	using System;

	public interface IProcessSpecificationBuilderWithProgram
		: IProcessSpecificationBuilderComplete
		, IProcessSpecificationBuilderWithArguments
	{
		IProcessSpecificationBuilderWithArguments WithArguments(params String[] arguments);
	}
}
