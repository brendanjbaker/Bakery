namespace Bakery.Processes.Specification.Builder
{
	using System;

	public interface IProcessSpecificationBuilder
	{
		IProcessSpecificationBuilderWithProgram WithProgram(String program);
	}
}
